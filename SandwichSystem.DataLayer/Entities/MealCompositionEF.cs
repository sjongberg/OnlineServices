using System.ComponentModel.DataAnnotations.Schema;

namespace SandwichSystem.DataLayer.Entities
{
    [Table("MealComposition")]
    public class MealCompositionEF
    {
        public int MealId { get; set; }

        [ForeignKey("MealId")]
        public MealEF Meal { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public IngredientEF Ingredient { get; set; }
    }
}
