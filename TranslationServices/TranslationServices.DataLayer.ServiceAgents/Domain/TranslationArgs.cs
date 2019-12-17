using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineServices.Shared.Extensions;
using Serilog;

namespace TranslationServices.DataLayer.ServiceAgents.Domain
{
    /// <summary>
    /// A wrap of args for translation.
    /// </summary>
    /// <remarks>
    /// This class has the benefits of wrapping all the args necessary for a translation request of the implementations of the ITRSTranslationService interface.
    /// </remarks>
    public class TranslationArgs
    {
        /// <summary>
        /// Contains the string with the content to translate.
        /// </summary>
        public string TextToTranslate { get; set; }

        /// <summary>
        /// Contains the language of the TextToTranslate.
        /// </summary>
        public Language OriginalLanguage { get; set; }

        /// <summary>
        /// Contains a array of language to translate the TextToTranslate to.
        /// </summary>
        public Language[] RequestedLanguages { get; set; }
    }
}
