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

            if (!Enum.IsDefined(typeof(Language), SourceLanguage))
            {
                var exceptionMSG = $"CorrectTranslation(...) ArgumentOutOfRangeException({nameof(SourceLanguage)}). Value={(int)SourceLanguage}";
                logger.Error(exceptionMSG);
                throw new ArgumentOutOfRangeException(exceptionMSG);
            }

            if (MLSToCheck is null)
            {
                var exceptionMSG = $"MLSToCorrect should not be null. {nameof(SourceLanguage)}";
                logger.Error(exceptionMSG);
                throw new ArgumentNullException(nameof(MLSToCheck));
            }
            if (MLSToCheck.ToString(SourceLanguage).IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"String necessary for check not present. {nameof(SourceLanguage)}";
                logger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            ////LOGIC HERE I ==> TEST OK. ICI  "Qte Requete aux agents == Enum.Language.Count-1 == Exact 2" à cause de GetTranslation que va tout traduire (Language.count-1)
            //var correctedMLString = GetTranslation(APIKey, MLSToCheck.ToString(SourceLanguage), SourceLanguage);

            //var IsCorrect = true;
            //foreach (var item in Enum.GetValues(typeof(Language)))
            //{
            //    if (MLSToCheck.ToString((Language)item) != correctedMLString.ToString((Language)item))
            //    {
            //        IsCorrect = false;
            //        break;
            //    }
            //}

            //LOGIC HERE II ==> On essaie de Ameliorer la performance en diminuant la quantité d'appel à l'API de Google or Bing. On Chercher "Qte Requete aux agents <= Enum.Language.Count-1"
            //TODO Reste encore a se poser la question si les If+Checks xFois (de la Logique II) sont plus lents que demander directment chéz le translator service (Logique I) d'un coup et comparer.
            //TODO (suite) Pour info le code LOGIQUE II est, selon NCrunch de 2 à 15ms plus lent... malgré moins d'appel au Translator. On sauras seulement quand le DataLayer seras developé...
            var IsCorrect = true;
            foreach (var item in Enum.GetValues(typeof(Language)))
            {
                if ((Language)item != SourceLanguage)
                    if (MLSToCheck.ToString((Language)item) != Translator.Translate(MLSToCheck.ToString(SourceLanguage), SourceLanguage, (Language)item))
                    {
                        IsCorrect = false;
                        break;
                    }
            }
            return IsCorrect;
        }
    }
}
