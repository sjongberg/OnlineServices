using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using OnlineServices.Shared.Extensions;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using Serilog;
using System;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem
    {
        public MultiLanguageString GetTranslation(string APIKey, string StringToTranslate, Language SourceLanguage)
        {
            //CHECKS
            if (APIKey.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"API Key is necessary for the service to work. {nameof(APIKey)}";
                logger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            if (Enum.IsDefined(typeof(Language), SourceLanguage))
            {
                var exceptionMSG = $"GetTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                logger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (StringToTranslate.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"Nothing to translate. {nameof(StringToTranslate)}";
                logger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            //LOGIC HERE

            return new MultiLanguageString($"{StringToTranslate}", $"{(StringToTranslate)}", $"{(StringToTranslate)}");
        }
    }
}
