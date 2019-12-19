using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using OnlineServices.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace TranslationServices.DataLayer.ServiceAgents.Extensions
{
    public static class TupleLanguageExtensions
    {
        /// <summary>
        /// This method serialize the text to Azure Cognitive service to be used with the HttpClient request.
        /// </summary>
        /// <param name="TupleText"></param>
        /// <returns></returns>
        public static string ToJsonObject(this Tuple<Language, string> TupleText)
        {
            object[] body = new object[] { new { Text = TupleText.Item2 } };
            return JsonSerializer.Serialize(body);
        }

        /// <summary>
        /// This method compose the route element of the Azure Cognitive service to be used as part of the URL the HttpClient request.
        /// </summary>
        /// <param name="OriginalText"></param>
        /// <returns></returns>
        public static string ComposeRoute(this Tuple<Language, string> OriginalText)
        {
            //Checks
            OriginalText.IsValidWithThrow();

            var other = OriginalText.Item1.GetOthersValues();
            var ReturnValue = $"&from={OriginalText.Item1.ToAzureLanguage()}&"
                + String.Join('&', OriginalText.Item1.GetOthersValues()
                                    .Distinct()
                                    .Select(x => $"to={x.ToAzureLanguage()}")
                                    );

            return ReturnValue;
        }

        /// <summary>
        /// The class validades that the fields has all the values as specifyed by the translation service.
        /// </summary>
        /// <returns>
        ///     void. This method throw a exception when LanguageTuple is not valid.
        /// </returns>
        public static void IsValidWithThrow(this Tuple<Language, string> LanguageTuple)//, ILogger iLogger)
        {
            //CHECKS
            if (LanguageTuple is null)
            {
                //iLogger.Error(nameof(Args));
                var msg = $"{nameof(LanguageTuple)} is null @ TupleLanguageExtensions.IsValidWithThrow(this ***Tuple<Language,string>***)";
                throw new LoggedException(msg, new ArgumentNullException(msg));
            }

            if (!LanguageTuple.Item1.IsDefined())
                throw new LanguageNotSupportedException($"{nameof(LanguageTuple.Item1)} not defined with value= {(int)LanguageTuple.Item1} @ TupleLanguageExtensions.IsValidWithThrow(this Tuple<***Language***,string>)");

            if (LanguageTuple.Item2.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"Nothing to translate. {nameof(LanguageTuple.Item2)} @ TupleLanguageExtensions.IsValidWithThrow(this Tuple<Language,***string***>);";
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }
        }
    }
}
