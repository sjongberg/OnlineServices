using OnlineServices.Shared.Enumerations;
using System;

namespace TranslationServices.DataLayer.ServiceAgents
{
    public interface ITRSTranslationService
    {
        string GetTranslation(string StringToTranslate, Language Langue);
    }
}
