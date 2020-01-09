using OnlineServices.Shared.Exceptions;
using System;

namespace OnlineServices.Shared.Extensions
{
    public static class StringExtentions
    {
        public static bool IsNullOrWhiteSpace(this string StringExtended, bool ThrowException = false)
        => !ThrowException ? String.IsNullOrWhiteSpace(StringExtended) : StringExtended.IsNullOrWhiteSpace("IsNullOrWhiteSpace(bool) @ StringExtentions");

        public static bool IsNullOrWhiteSpace(this string StringExtended, string ExceptionMessage)
            => !String.IsNullOrWhiteSpace(StringExtended)? false : throw new IsNullOrWhiteSpaceException(ExceptionMessage);
    }
}
