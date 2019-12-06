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

        string ITRSTranslationService.GetTranslation(string StringToTranslate, Language Langue)
        {
            throw new NotImplementedException();
        }
    }
}
