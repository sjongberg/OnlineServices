using OnlineServices.Shared.TranslationServices.TransfertObjects;

using System;

namespace OnlineServices.Shared.Extensions
{
    public static class MultiLanguageStringExtensions
    {
        public static T FillFromMultiLanguageString<T>(this T ToFill, MultiLanguageString multiLanguageString)
            where T : IMultiLanguageNameFields
        {
            if (multiLanguageString is null)
                throw new ArgumentNullException(nameof(multiLanguageString));

            ToFill.NameEnglish = multiLanguageString.English;
            ToFill.NameFrench = multiLanguageString.French;
            ToFill.NameDutch = multiLanguageString.Dutch;

            return ToFill;
        }

        public static MultiLanguageString ExtractToMultiLanguageString(this IMultiLanguageNameFields MultilanguageString)
        {
            if (MultilanguageString is null)
                throw new ArgumentNullException(nameof(MultilanguageString));

            return new MultiLanguageString(MultilanguageString.NameEnglish, MultilanguageString.NameFrench, MultilanguageString.NameDutch);
        }
    }
}
