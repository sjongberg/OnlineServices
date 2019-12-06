using MealServices.Shared.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using Serilog;
using System;

namespace TranslationServices.BusinessLayer.UseCases
{
    public partial class OnlineServicesSystem
    {
        private readonly ILogger logger;

        public OnlineServicesSystem(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
