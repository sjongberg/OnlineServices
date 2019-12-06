using OnlineServices.Shared.Enumerations;
using OnlineServices.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationServices.DataLayer.ServiceAgents
{
    public class GoogleTranslationAgent : ITRSTranslationService
    {
        private readonly string aPIKey;

        public GoogleTranslationAgent(string APIKey)
        {
            bool v = APIKey.IsNullOrWhiteSpace("You should provide a valid Google APIKey");
            aPIKey = APIKey;
        }

        string ITRSTranslationService.Translate(string StringToTranslate, Language FromLangue, Language ToLangue)
        {
            throw new NotImplementedException();
        }
    }
}
