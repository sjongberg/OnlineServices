using OnlineServices.Shared.TranslationServices;
using Serilog;
using System;
using TranslationServices.DataLayer.ServiceAgents.Interfaces;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem : ITRSServicesRole
    {
        private readonly ILogger iLogger;
        private readonly ITRSTranslationService Translator;

        public OnlineServicesSystem(ILogger logger, ITRSTranslationService Translator)
        {
            this.iLogger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (Translator is null)
            {
                var exceptionMSG = $"ITRSTranslationService should not be null. {nameof(Translator)} @ CTOR in OnlineServicesSystem";
                logger.Error(exceptionMSG);
                throw new ArgumentNullException(nameof(Translator));
            }
            else
                this.Translator = Translator;
        }
    }
}
