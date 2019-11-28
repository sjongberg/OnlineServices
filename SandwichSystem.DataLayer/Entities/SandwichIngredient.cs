using System.ComponentModel.DataAnnotations.Schema;

namespace SandwichSystem.DataLayer.Entities
{
    public class SandwichIngredient
    {
        public int SandwichId { get; set; }

        [ForeignKey("SandwichId")]
        public SandwichEF Sandwich { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public IngredientEF Ingredient { get; set; }
    }
}
