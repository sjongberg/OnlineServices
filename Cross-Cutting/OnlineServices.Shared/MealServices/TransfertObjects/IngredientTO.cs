using System.Diagnostics.CodeAnalysis;
using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.TranslationServices.TransfertObjects;

namespace OnlineServices.Shared.MealServices.TransfertObjects
{
    public class IngredientTO : IEntity<int>
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool IsAllergen { get; set; }
    }

}
