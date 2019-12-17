using OnlineServices.Shared.Enumerations;
using System;
using System.Threading.Tasks;
using TranslationServices.DataLayer.ServiceAgents.Domain;

namespace TranslationServices.DataLayer.ServiceAgents.Interfaces
{
    public interface ITRSTranslationServiceV2
    {
        Tuple<Language,string>[] Translate(TranslationArgs Args);
        Task<Tuple<Language, string>[]> TranslateAsync(TranslationArgs Args);
    }
}