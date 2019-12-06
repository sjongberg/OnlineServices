using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.Exceptions
{
    public class IsNullOrWhiteSpaceException : Exception
    {
        private const string ExceptionMessage = "String should not be Nul, Empty or Whitespace";
        public IsNullOrWhiteSpaceException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public IsNullOrWhiteSpaceException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public IsNullOrWhiteSpaceException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
