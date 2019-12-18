using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using TranslationServices.DataLayer.ServiceAgents.TranslationAgents;
using Xunit;

namespace TranslationServices.DataLayer.ServiceAgentsTests
{
    public class AzureCognitiveAuthenticationTests
    {
        [Fact]
        public void AzCogniveWellSetupInWorkstation()
        {
            //DOC https://docs.microsoft.com/en-us/azure/cognitive-services/translator/quickstart-translate?pivots=programming-language-csharp#set-up
            const string key_var = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
            var subscriptionKey = Environment.GetEnvironmentVariable(key_var);

            const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
            var endpoint = Environment.GetEnvironmentVariable(endpoint_var);

            //if (null == subscriptionKey)
            //{
            //    throw new Exception("Please set/export the environment variable: " + key_var);
            //}
            //if (null == endpoint)
            //{
            //    throw new Exception("Please set/export the environment variable: " + endpoint_var);
            //}
            Assert.NotNull(subscriptionKey);
            Assert.NotNull(endpoint);
        }

        [Fact]
        public async Task MainDemoTranslationToMakeWork()
        {

            // This is our main function.
            // Output languages are defined in the route.
            // For a complete list of options, see API reference.
            // https://docs.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate
            // Prompts you for text to translate. If you'd prefer, you can
            // provide a string as textToTranslate.
            Console.Write("Type the phrase you'd like to translate? ");

            string textToTranslate = "Type the phrase you'd like to translate? ";

            string route = "&from=en&to=nl";
            //var seriLog = new Mock<Serilog.ILogger>();
            //string route = "/translate?api-version=3.0&to=de&to=it&to=ja&to=th";

            //var TranslatorAgent = new AzureCognitiveAgent(seriLog.Object, TestHelper.AzCognitiveArgs) ;

           await AzureCognitiveAgent.TranslateTextRequest(TestHelper.AzCognitiveArgs, route, textToTranslate);

           Console.WriteLine("Press any key to continue.");
           //Console.ReadKey();
            Assert.False(false);
        }

        private async Task Main(AzureCognitiveArgs subscriptionConfig, string route, string textToTranslate)
        {

            AzureCognitiveAgent.TranslateTextRequest(subscriptionConfig,  route, textToTranslate);
        }
        //[Theory(Skip = "Run Only to Test Google Authentification")]
        //[InlineData(@"C:\TFS\OnlineServices-d9921f8e5f21.json")]//TODO Students: Put your projectIdHere
        //public void AzCognitiveServicesAuthenticationImplicit(string JSONFile)
        //{
        //    // If you don't specify credentials when constructing the client, the
        //    // client library will look for credentials in the environment.
        //    var credential = GoogleCredential.FromFile(JSONFile);

        //    using (var client = TranslationClient.Create(credential, TranslationModel.NeuralMachineTranslation))
        //    {

        //        var ReturnedValue = client.DetectLanguage("Bonjour Google!").Language;
        //        Console.WriteLine(ReturnedValue);
        //        Assert.Equal("fr", ReturnedValue);
        //    }

        //}
    }
}
