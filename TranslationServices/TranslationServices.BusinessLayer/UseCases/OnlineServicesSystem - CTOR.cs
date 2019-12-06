using OnlineServices.Shared.TranslationServices;
using Serilog;
using System;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem : ITRSOnlineServicesSystem
    {
        private readonly ILogger logger;

        public OnlineServicesSystem(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
