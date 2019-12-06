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
        public MultiLanguageString CorrectTranslation(string APIKey, MultiLanguageString MLSToCorrect, Language SourceLanguage)
        {
            if (APIKey.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"API Key is necessary for the service to work. {nameof(APIKey)}";
                logger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            if (!Enum.IsDefined(typeof(Language), SourceLanguage))
            {
                var exceptionMSG = $"CorrectTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                logger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (MLSToCorrect is null)
            {
                var exceptionMSG = $"MLSToCorrect should not be null. {nameof(SourceLanguage)}";
                logger.Error(exceptionMSG);
                throw new ArgumentNullException(nameof(MLSToCorrect));
            }
            if (MLSToCorrect.ToString(SourceLanguage).IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"String necessary for correction correct not present. {nameof(SourceLanguage)}";
                logger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            //LOGIC HERE


            return GetTranslation(APIKey, MLSToCorrect.ToString(SourceLanguage), SourceLanguage);
        }
    }
}
