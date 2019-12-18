using System;
using System.Collections.Generic;

namespace OnlineServices.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static Dictionary<int, string> ToDictionary<TEnum>(this TEnum EnumToExtend)
            where TEnum : Enum
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(TEnum));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(TEnum), item));
            return result;
        }

        public static bool IsDefined<TEnum>(this TEnum EnumToExtend, bool ThrowException = false)
            where TEnum : Enum
        {
            bool ReturnValue;
            if (!Enum.IsDefined(typeof(TEnum), EnumToExtend))
                ReturnValue = ThrowException ? throw new ArgumentOutOfRangeException($"{typeof(TEnum)} with invalid value of {EnumToExtend.ToInt()}") : false;
            else
                ReturnValue = true;
            return ReturnValue;
        }

        public static int ToInt<TEnum>(this TEnum EnumToExtend)
            //TODO UPDATE VS... where TEnum : notnull, Enum
            => Convert.ToInt32(EnumToExtend, null);
    }
}
