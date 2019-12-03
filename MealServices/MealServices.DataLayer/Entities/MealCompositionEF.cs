using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MealServices.DataLayer.Entities
{
    [Table("MealComposition")]
    public class MealCompositionEF : IEquatable<MealCompositionEF>
    {
        public int MealId { get; set; }

        [ForeignKey("MealId")]
        public MealEF Meal { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public IngredientEF Ingredient { get; set; }

        public bool IsValid()
            => (this.Meal.Id == this.MealId) && (this.Ingredient.Id == this.IngredientId);

        public bool Equals([AllowNull] MealCompositionEF other)
        {
            return (this.IsValid() && other.IsValid())
                && (this.IngredientId == other.IngredientId)
                && (this.MealId == other.MealId);
        }
    }
}
