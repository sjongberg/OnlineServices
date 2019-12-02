using SandwichSystem.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.Shared.Extentions
{
    public static class StringTranslatedExtentions
    {
        public static T FillFromStringTranslated<T>(this T ToFill, StringTranslated stringTranslated)
            where T : IMultiLanguageFields
        {
            ToFill.NameEnglish = stringTranslated.English;
            ToFill.NameFrench = stringTranslated.French;
            ToFill.NameDutch = stringTranslated.Dutch;

            return ToFill;
        }

        public static StringTranslated ExtractToStringTranslated(this IMultiLanguageFields Multilanguage)
            => new StringTranslated(Multilanguage.NameEnglish, Multilanguage.NameFrench, Multilanguage.NameDutch);

    }
}
