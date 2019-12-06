using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationServices.DataLayer.ServiceAgents
{
    public class BingTranslationAgent : ITRSTranslationService
    {
        private readonly string aPIKey;

        public BingTranslationAgent(string APIKey)
        {
            APIKey.IsNullOrWhiteSpace("You should provide a valid Bing APIKey");
            aPIKey = APIKey;
        }

        string ITRSTranslationService.Translate(string StringToTranslate, Language FromLangue, Language ToLangue)
        {
            throw new NotImplementedException();
        }
    }
}
