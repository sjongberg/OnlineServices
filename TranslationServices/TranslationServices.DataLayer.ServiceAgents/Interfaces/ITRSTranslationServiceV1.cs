using OnlineServices.Shared.Enumerations;
using System;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Domain;

namespace TranslationServices.DataLayer.ServiceAgents.Interfaces
{
    public interface ITRSTranslationServiceV1
    {
        string Translate(string StringToTranslate, Language FromLangue, Language ToLangue);
    }
}
