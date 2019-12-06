using OnlineServices.Shared.MealServices.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Shared.MealServices.TransfertObjects
{
    public class MealTO
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public SupplierTO Supplier { get; set; }
        public List<IngredientTO> Ingredients { get; set; }
        public MealType MealType { get; set; }
    }
}