using System.Collections.Generic;

namespace SandwichSystem.Shared.DTO
{
    public class SandwichDTO
    {
        public StringTranslated Name { get; set; }

        public List<IngredientDTO> Ingredients { get; set; }
    }
}