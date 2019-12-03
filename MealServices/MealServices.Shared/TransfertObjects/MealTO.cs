using MealServices.Shared.Enumerations;
using System.Collections.Generic;

namespace MealServices.Shared.TransfertObjects
{
    public class MealTO
    {
        public int Id { get; set; }
        public StringTranslated Name { get; set; }
        public SupplierTO Supplier { get; set; }
        public List<IngredientTO> Ingredients { get; set; }
        public MealType MealType { get; set; }
    }
}