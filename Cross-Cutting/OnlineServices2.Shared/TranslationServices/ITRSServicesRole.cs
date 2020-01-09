using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.SecurityServices.TransfertObjects;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using System;

namespace OnlineServices.Shared.TranslationServices
{
    public interface ITRSServicesRole
    {
        //TODO Refactorer à Argument Pattern pour reduire redondance dans les checkes d'arguments.
        MultiLanguageString GetTranslations(ServiceAuthorization APIKey, Tuple<Language, string> TupleToTranslate);
        bool IsCorrectTranslation(ServiceAuthorization APIKey, MultiLanguageString MLSToCheck, Language SourceLanguage);
    }
}