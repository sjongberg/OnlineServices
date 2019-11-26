using System.Collections.Generic;

namespace SandwichSystem.Shared.DTO
{
    public class SandwichDTO
    {
        public int Id { get; set; }
        public StringTranslated Name { get; set; }
        public SupplierDTO Supplier { get; set; }
        public List<IngredientDTO> Ingredients { get; set; }
    }
}