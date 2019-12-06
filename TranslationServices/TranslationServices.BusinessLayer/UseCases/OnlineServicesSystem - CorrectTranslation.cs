using MealServices.Shared.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using Serilog;
using System;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem
    {
        public MultiLanguageString CorrectTranslation(string APIKey, MultiLanguageString MLSToCorrect, Language SourceLanguage)
        {
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
                var exceptionMSG = $"CorrectTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                logger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (MLSToCorrect is null)
                throw new ArgumentNullException(nameof(MLSToCorrect));
            if (string.IsNullOrEmpty(MLSToCorrect.ToString(SourceLanguage)) || string.IsNullOrWhiteSpace(MLSToCorrect.ToString(SourceLanguage)))
            {
                throw new ArgumentException("String necessary for correction correct not present.", nameof(APIKey));
            }

            //LOGIC HERE


            return GetTranslation(APIKey, MLSToCorrect.ToString(SourceLanguage), SourceLanguage);
        }
    }
}
