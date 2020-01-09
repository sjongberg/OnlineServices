using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.EvaluationServices.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Shared.EvaluationServices.TransfertObjects
{
    public class QuestionsTO : IEntity<int>
    {
        public  int Id { get; set; }
        public QuestionsType Type { get; set; }
        public int Position { get; set; }
        public MultiLanguageString Libelle { get; set; }
    }
}