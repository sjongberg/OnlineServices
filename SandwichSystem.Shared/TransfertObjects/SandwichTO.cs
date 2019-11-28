using System.Collections.Generic;

namespace SandwichSystem.Shared.TransfertObjects
{
    public class SandwichTO
    {
        public int Id { get; set; }
        public StringTranslated Name { get; set; }
        public SupplierTO Supplier { get; set; }
        public List<IngredientTO> Ingredients { get; set; }
    }
}