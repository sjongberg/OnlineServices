using OnlineServices.Shared.Exceptions;
using OnlineServices.Shared.Extensions;
using Serilog;
using System;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

using Language = OnlineServices.Shared.Enumerations.Language;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using TranslationServices.DataLayer.ServiceAgents.Extensions;
using TranslationServices.DataLayer.ServiceAgents.Domain.AzureCognitive;
using OnlineServices.Shared.Enumerations;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using System.Linq;

namespace TranslationServices.DataLayer.ServiceAgents.TranslationAgents
{
    public class AzureCognitiveAgent : ITRSTranslationServiceV2
    {
        private readonly AzureCognitiveArgs cognitiveServiceConfig;
        private readonly ILogger iLogger;

        public AzureCognitiveAgent(ILogger iLogger, AzureCognitiveArgs SubscriptionConfig)
        {
            this.iLogger = iLogger ?? throw new ArgumentNullException($"{nameof(iLogger) } @ CTOR in AzureCognitiveAgent");

            if (SubscriptionConfig is null)
            {
                var exceptionMSG = $"{nameof(SubscriptionConfig)} @ CTOR in AzureCognitiveAgent";
                iLogger.Error(exceptionMSG);
                throw new ArgumentNullException($"{nameof(SubscriptionConfig) }.SubscriptionKey  @ CTOR in AzureCognitiveAgent");
            }

            if (SubscriptionConfig.SubscriptionKey.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"You should provide a valid AzureCognitive AzureCognitivsArgs. {nameof(SubscriptionConfig)}.SubscriptionKey @ CTOR in AzureCognitiveAgent";
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            if (SubscriptionConfig.Endpoint.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"You should provide a valid AzureCognitive AzureCognitivsArgs. {nameof(SubscriptionConfig)}.Endpoint @ CTOR in AzureCognitiveAgent";
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            this.cognitiveServiceConfig = SubscriptionConfig;
        }



        Tuple<Language, string>[] ITRSTranslationServiceV2.Translate(TranslationArgs Args)
        {
            //CHECKS
            Args.IsValidWithThrow(iLogger);

            //IMPLEMENTATION
            string route = Args.ComposeRoute(iLogger);

            //Task task = Task.Run( async () => await TranslateTextRequest(apiKey, endpoint, route, StringToTranslate));
            var task = TranslateTextRequest(cognitiveServiceConfig, route, Args.TextToTranslate);

            //LOGIC TO IMPLEMENT HERE
            //task.Start();//.WaitAndUnwrapException();
            task.Wait();
            var r = task.Result;

            return r;

        }

        // This sample requires C# 7.1 or later for async/await.
        // Async call to the Translator Text API
        static public async Task<Tuple<Language, string>[]> TranslateTextRequest(AzureCognitiveArgs cognitiveServiceConfig, string route, string inputText)
        {
            //DOC https://docs.microsoft.com/en-us/azure/cognitive-services/translator/quickstart-translate?pivots=programming-language-csharp#set-up
            /*
             * The code for your call to the translation service will be added to this
             * function in the next few sections.
             */

            List<Tuple<Language, string>> ReturnValue = new List<Tuple<Language, string>>();

            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonSerializer.Serialize(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // In the next few sections you'll add code to construct the request.
                // Build the request.
                // Set the method to Post.
                request.Method = HttpMethod.Post;
                // Construct the URI and add headers.
                request.RequestUri = new Uri(cognitiveServiceConfig.Endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", cognitiveServiceConfig.SubscriptionKey);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string result = await response.Content.ReadAsStringAsync();
                // Deserialize the response using the classes created earlier.
                Console.WriteLine(result);
                //var resultT = JsonSerializer.Deserialize<List<Dictionary<string, List<Dictionary<string, string>>>>>(result);
                //var translationT = resultT[0]["translations"][0]["text"];

                TranslationResult[] deserializedOutput = JsonSerializer.Deserialize<TranslationResult[]>(result);
                Console.WriteLine(result);
                // Iterate over the deserialized results.
                foreach (var o in deserializedOutput)
                {
                    // Print the detected input language and confidence score.
                    //var detected = String.Format("Detected input language: {0}\nConfidence score: {1}\n", o.DetectedLanguage.Language, o.DetectedLanguage.Score);
                    //Console.WriteLine(detected);
                    // Iterate over the results and print each translation.
                    foreach (var t in o.translations)
                    {
                        if (!(t is null))
                        {
                            ReturnValue.Add(new Tuple<Language, string>(t.to.ToLanguage(), t.text));
                            var trnalation = String.Format("Translated to {0}: {1}", t.to, t.text);
                            Console.WriteLine(trnalation);
                        }
                    }
                }
            }

            return ReturnValue.ToArray();
        }

        Task<Tuple<Language, string>[]> ITRSTranslationServiceV2.TranslateAsync(TranslationArgs Args)
        {
            throw new NotImplementedException();
        }
    }
}
