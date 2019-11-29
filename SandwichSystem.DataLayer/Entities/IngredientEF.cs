using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandwichSystem.DataLayer.Entities
{
    [Table("Ingredient")]
    public class IngredientEF
    {
        [Key]
        public int Id{get;set;}
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public bool IsAllergen { get; set; }

        public IList<MealCompositionEF> MealsComposition { get; set; }
    }

}
