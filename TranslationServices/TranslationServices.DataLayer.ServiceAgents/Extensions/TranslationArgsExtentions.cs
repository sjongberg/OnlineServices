using OnlineServices.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TranslationServices.DataLayer.ServiceAgents.Domain;
using Serilog;
using OnlineServices.Shared.Exceptions;

namespace TranslationServices.DataLayer.ServiceAgents.Extensions
{
    public static class TranslationArgsExtentions
    {

        //TODO TEST AND THROW IF LANGUAGES TO AND FROM ARE NULL OR EMPTY
        public static string ComposeRoute(this TranslationArgs Args, ILogger iLogger)
        {
            //Checks
            try
            {
                if (iLogger is null)
                    throw new ArgumentNullException(nameof(iLogger));

                if (Args is null)
                    throw new ArgumentNullException(nameof(Args));

                Args.IsValidWithThrow(iLogger);

            }
            catch (Exception)
            {
                throw;
            }



            var ReturnValue = $"&from={Args.OriginalLanguage.ToAzureLanguage()}&"
                + String.Join('&', Args.RequestedLanguages
                                    .Where(x => x != Args.OriginalLanguage) //Why commented? Test are done elsewhere, Better perfomarmance if not tested twice.
                                    .Distinct()
                                    .Select(x => $"to={x.ToAzureLanguage()}")
                                    );

            return ReturnValue;
        }

        /// <summary>
        /// The class validades that the fields has all the values as specifyed by the translation service.
        /// </summary>
        /// <returns>
        /// This method throw a exception withn validation returns false
        /// </returns>
        public static void IsValidWithThrow(this TranslationArgs Args, ILogger iLogger)
        {
            //CHECKS
            if (iLogger is null)
            {
                new ArgumentNullException(nameof(iLogger));
            }

            if (Args is null)
            {
                iLogger.Error(nameof(Args));
                throw new ArgumentNullException(nameof(Args));
            }


            if (Args.TextToTranslate.IsNullOrWhiteSpace())
            {
                var exceptionMSG = $"Nothing to translate. {nameof(Args.TextToTranslate)} @ TranslationArgs.IsValidWithThrow(TranslationArgs, ILogger);";
                iLogger.Error(exceptionMSG);
                throw new IsNullOrWhiteSpaceException(exceptionMSG);
            }

            Args.OriginalLanguage.IsDefined(true);

            if (Args.RequestedLanguages is null)
            {
                iLogger.Error(nameof(Args.RequestedLanguages));
                throw new ArgumentNullException(nameof(Args.RequestedLanguages));
            }
            if (Args.RequestedLanguages.Length < 1)
            {
                var exceptionMSG = $"ArgumentException({nameof(Args.RequestedLanguages)}). You should have at least one language to translate to. @ TranslationArgs.IsValidWithThrow(TranslationArgs, ILogger);";
                iLogger.Error(exceptionMSG);
                throw new ArgumentException(exceptionMSG);
            }
            Args.RequestedLanguages.Select(x => x.IsDefined(true));

            //if (Args.RequestedLanguages.Length == 1 & Args.RequestedLanguages.Contains(Args.OriginalLanguage))
            if (Args.RequestedLanguages.Contains(Args.OriginalLanguage))
            {
                if (Args.RequestedLanguages.Length == 1)
                {
                    var exceptionMSG = $"ArgumentException({nameof(Args.OriginalLanguage)} && {nameof(Args.OriginalLanguage)}). Values Are The Same={(int)Args.OriginalLanguage}. @ TranslationArgs.IsValidWithThrow(TranslationArgs, ILogger);";
                    iLogger.Error(exceptionMSG);
                    throw new ArgumentException(exceptionMSG);
                }
            }
        }
    }
}
