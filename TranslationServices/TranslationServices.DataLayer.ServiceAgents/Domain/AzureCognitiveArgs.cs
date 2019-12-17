using System;
using System.Collections.Generic;
using System.Text;

namespace TranslationServices.DataLayer.ServiceAgents.Domain
{
    public class AzureCognitiveArgs
    {
        public string SubscriptionKey { get; set; }
            = "66b23505dc864928a25661c03ba0c7b0";

        public string Endpoint { get; set; }
            = @"https://api.cognitive.microsofttranslator.com/translate?api-version=3.0";
    }
}
