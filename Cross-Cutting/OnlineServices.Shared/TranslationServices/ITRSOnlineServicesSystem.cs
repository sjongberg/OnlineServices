using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;

namespace OnlineServices.Shared.TranslationServices
{
    public interface ITRSOnlineServicesSystem
    {
        MultiLanguageString CorrectTranslation(string APIKey, MultiLanguageString MLSToCorrect, Language SourceLanguage);
        MultiLanguageString GetTranslation(string APIKey, string StringToTranslate, Language SourceLanguage);
        bool IsCorrectTranslation(string APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage);
    }
}