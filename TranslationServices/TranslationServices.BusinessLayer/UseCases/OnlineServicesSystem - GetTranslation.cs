using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using OnlineServices.Shared.Extensions;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
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
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            if (!Enum.IsDefined(typeof(Language), SourceLanguage))
            {
                var exceptionMSG = $"GetTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                iLogger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (StringToTranslate.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"Nothing to translate. {nameof(StringToTranslate)}";
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            //LOGIC HERE
            return new MultiLanguageString(
                SourceLanguage == Language.English ? StringToTranslate : Translator.Translate(StringToTranslate, SourceLanguage, Language.English),
                SourceLanguage == Language.French ? StringToTranslate : Translator.Translate(StringToTranslate, SourceLanguage, Language.French),
                SourceLanguage == Language.Dutch ? StringToTranslate : Translator.Translate(StringToTranslate, SourceLanguage, Language.Dutch));
        }
    }
}
