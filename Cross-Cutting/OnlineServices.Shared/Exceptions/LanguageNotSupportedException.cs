using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.Exceptions
{
    [Serializable]
    public class LanguageNotSupportedException : Exception
    {
        private const string ExceptionMessage = "Language Unknown or not properly configured";
        public LanguageNotSupportedException(string message)
            : base($"{ExceptionMessage}. {message}")
        {
        }

        public LanguageNotSupportedException(string message, Exception innerException)
            : base($"{ExceptionMessage}. {message}", innerException)
        {
        }

        public LanguageNotSupportedException()
            : base($"{ExceptionMessage}")
        {
        }
    }
}
