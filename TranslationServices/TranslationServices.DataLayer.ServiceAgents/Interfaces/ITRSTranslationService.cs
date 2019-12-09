using OnlineServices.Shared.Enumerations;

namespace TranslationServices.DataLayer.ServiceAgents.Interfaces
{
    public interface ITRSTranslationService
    {
        string Translate(string StringToTranslate, Language FromLangue, Language ToLangue);
    }
}
