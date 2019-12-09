using OnlineServices.Shared.Exceptions;
using OnlineServices.Shared.Extensions;
using Serilog;
using System;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

using Language = OnlineServices.Shared.Enumerations.Language;

namespace TranslationServices.DataLayer.ServiceAgents.TranslationAgents
{
    public class BingTranslationAgent : ITRSTranslationService
    {
        private readonly string apiKey;
        private readonly ILogger iLogger;

        public BingTranslationAgent(ILogger iLogger, string apiKey)
        {
            this.iLogger = iLogger ?? throw new ArgumentNullException($"{nameof(iLogger) } @ CTOR in BingTranslationAgent");

            if (apiKey.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"You should provide a valid Bing APIKey. {nameof(apiKey)} @ CTOR in BingTranslationAgent";
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

            //LOGIC TO IMPLEMENT HERE
            return StringToTranslate;
        }
    }
}
