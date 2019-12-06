using OnlineServices.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.Extensions
{
    public static class StringExtentions
    {
        public static bool IsNullOrWhiteSpace(this string StringExtended, bool ThrowException = false)
            => !ThrowException ? String.IsNullOrWhiteSpace(StringExtended) : throw new IsNullOrWhiteSpaceException();

        public static bool IsNullOrWhiteSpace(this string StringExtended, string ExceptionMessage)
            => !String.IsNullOrWhiteSpace(StringExtended)? false : throw new IsNullOrWhiteSpaceException(ExceptionMessage);
    }
}
