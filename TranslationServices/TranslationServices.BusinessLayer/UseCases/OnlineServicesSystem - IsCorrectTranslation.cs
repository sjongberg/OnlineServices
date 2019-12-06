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
        public bool IsCorrectTranslation(string APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage)
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
                var exceptionMSG = $"CorrectTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                logger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (MLSToCheck.ToString(SourceLanguage).IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"String necessary for check not present. {nameof(SourceLanguage)}";
                logger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
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
