using MealServices.Shared.Enumerations;
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
            if (APIKey is null)
                throw new ArgumentNullException(nameof(APIKey));

            if (string.IsNullOrEmpty(APIKey) || string.IsNullOrWhiteSpace(APIKey))
            {
                var exceptionMSG = "API Key is necessary for the service to work";
                logger.Error(exceptionMSG);
                throw new ArgumentException(exceptionMSG, nameof(APIKey));
            }

            if (Enum.IsDefined(typeof(Language), SourceLanguage))
            {
                var exceptionMSG = $"GetTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                logger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (StringToTranslate is null)
                throw new ArgumentNullException(nameof(StringToTranslate));
            if (string.IsNullOrEmpty(StringToTranslate) || string.IsNullOrWhiteSpace(StringToTranslate))
            {
                var exceptionMSG = "Nothing to translate";
                logger.Error(exceptionMSG);
                throw new ArgumentException(exceptionMSG, nameof(APIKey));
            }

            //LOGIC HERE

            return new MultiLanguageString($"{StringToTranslate}",$"{(StringToTranslate)}",$"{(StringToTranslate)}");
        }
    }
}
