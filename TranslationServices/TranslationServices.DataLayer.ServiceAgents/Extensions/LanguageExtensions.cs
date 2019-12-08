using Google.Cloud.Translation.V2;
using OnlineServices.Shared.Exceptions;

using Language = OnlineServices.Shared.Enumerations.Language;

namespace TranslationServices.DataLayer.ServiceAgents.Extensions
{
    public static class LanguageExtensions
    {
        public static string ToLanguageCode(this Language language)
        {
            string languageCode;
            switch (language)
            {
                case Language.English:
                    languageCode = LanguageCodes.English;
                    break;
                case Language.French:
                    languageCode = LanguageCodes.French;
                    break;
                case Language.Dutch:
                    languageCode = LanguageCodes.Dutch;
                    break;
                default:
                    throw new LanguageNotSupportedException("LanguageNotSupportedException. ToLanguageCode(this Language) @ LanguageExtensions.");
            }

            return languageCode;
        }
    }
}
