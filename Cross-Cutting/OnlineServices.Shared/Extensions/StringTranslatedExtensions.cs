using OnlineServices.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealServices.Shared.Extensions
{
    public static class StringTranslatedExtensions
    {
        public static T FillFromMultiLanguageString<T>(this T ToFill, MultiLanguageString multiLanguageString)
            where T : IMultiLanguage
        {
            if (multiLanguageString is null)
                throw new ArgumentNullException(nameof(multiLanguageString));

            ToFill.NameEnglish = multiLanguageString.English;
            ToFill.NameFrench = multiLanguageString.French;
            ToFill.NameDutch = multiLanguageString.Dutch;

            return ToFill;
        }

        public static MultiLanguageString ExtractToMultiLanguageString(this IMultiLanguage MultilanguageString)
        {
            if (MultilanguageString is null)
                throw new ArgumentNullException(nameof(MultilanguageString));

            return new MultiLanguageString(MultilanguageString.NameEnglish, MultilanguageString.NameFrench, MultilanguageString.NameDutch);
        }
    }
}
