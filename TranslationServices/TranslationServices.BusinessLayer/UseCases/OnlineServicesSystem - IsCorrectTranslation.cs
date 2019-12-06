using MealServices.Shared.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using Serilog;
using System;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem
    {
        public bool IsCorrectTranslation(string APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage)
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
                var exceptionMSG = $"CorrectTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                logger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (MLSToCheck is null)
                throw new ArgumentNullException(nameof(MLSToCheck));
            if (string.IsNullOrEmpty(MLSToCheck.ToString(SourceLanguage)) || string.IsNullOrWhiteSpace(MLSToCheck.ToString(SourceLanguage)))
            {
                throw new ArgumentException("String necessary for check not present.", nameof(APIKey));
            }

            //LOGIC HERE
            var correctedMLString = GetTranslation(APIKey, MLSToCheck.ToString(SourceLanguage), SourceLanguage);

            var IsCorrect = true;
            foreach (var item in Enum.GetValues(typeof(Language)))
            {
                if (MLSToCheck.ToString((Language)item) == correctedMLString.ToString((Language)item))
                {
                    IsCorrect = false;
                    break;
                }
            }
            return IsCorrect;
        }
    }
}
