using OnlineServices.Shared.Enumerations;
using System;

namespace TranslationServices.DataLayer.ServiceAgents
{
    public interface ITRSTranslationService
    {
        string Translate(string StringToTranslate, Language FromLangue, Language ToLangue);
    }
}
