using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using OnlineServices.Shared.Exceptions;
using OnlineServices.Shared.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using TranslationServices.DataLayer.ServiceAgents.Extensions;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

using Language = OnlineServices.Shared.Enumerations.Language;

namespace TranslationServices.DataLayer.ServiceAgents.TranslationAgents
{
    public class GoogleTranslationAgent : ITRSTranslationService
    {
        private readonly string apiKey;
        private readonly ILogger iLogger;

        public GoogleTranslationAgent( ILogger iLogger, string apiKey = @"C:\TFS\OnlineServices-d9921f8e5f21.json")
        {
            this.iLogger = iLogger ?? throw new ArgumentNullException($"{nameof(apiKey)} @ CTOR in GoogleTranslationAgent");

            if (apiKey.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"You should provide a valid Google APIKey. {nameof(apiKey)} @ CTOR in GoogleTranslationAgent";
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }
            else
                this.apiKey = apiKey;
        }

        string ITRSTranslationService.Translate(string StringToTranslate, Language FromLangue, Language ToLangue)
        {
            //CHECKS
            if (StringToTranslate.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"Nothing to translate. {nameof(StringToTranslate)} @ GoogleTranslationAgent.Translate(...);";
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            if (FromLangue == ToLangue)
            {
                var exceptionMSG = $"ArgumentException({nameof(FromLangue)} && {nameof(FromLangue)}). Values Are The Same={(int)FromLangue}. Translate(...) @ GoogleTranslationAgent";
                iLogger.Error(exceptionMSG);
                throw new ArgumentException(exceptionMSG);
            }

            if (!FromLangue.IsDefined())
            {
                var exceptionMSG = $"ArgumentOutOfRangeException({nameof(FromLangue)}). Value={(int)FromLangue}. Translate(...) @ GoogleTranslationAgent";
                iLogger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (!ToLangue.IsDefined())
            {
                var exceptionMSG = $"ArgumentOutOfRangeException({nameof(ToLangue)}). Value={(int)ToLangue}. Translate(...) @ GoogleTranslationAgent";
                iLogger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            //LOGIC HERE
            #region This Region depends on a current Google Cloud Account with Credit Card entered on it.
            //DOC Students should create a service account https://cloud.google.com/docs/authentication/getting-started
            //var credential = GoogleCredential.FromFile(apiKey);
            //using (var client = TranslationClient.Create(credential, TranslationModel.NeuralMachineTranslation))
            //{
            //    var result = client.TranslateText(StringToTranslate, ToLangue.ToLanguageCode(), FromLangue.ToLanguageCode());

            //    return result.TranslatedText;
            //}
            #endregion

            return StringToTranslate; //TODO Delete when the google account is created and JSON file downloaded...
        }
    }
}
