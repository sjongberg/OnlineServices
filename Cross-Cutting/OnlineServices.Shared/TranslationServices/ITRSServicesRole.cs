using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;

namespace OnlineServices.Shared.TranslationServices
{
    public interface ITRSServicesRole
    {
        //TODO Refactorer à Argument Pattern pour reduire redondance dans les checkes d'arguments.
        MultiLanguageString CorrectTranslation(string APIKey, MultiLanguageString MLSToCorrect, Language SourceLanguage);
        MultiLanguageString GetTranslation(string APIKey, string StringToTranslate, Language SourceLanguage);
        bool IsCorrectTranslation(string APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage);
    }
}