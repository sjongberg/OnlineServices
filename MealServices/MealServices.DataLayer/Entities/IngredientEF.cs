using OnlineServices.Shared.TranslationServices.TransfertObjects;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealServices.DataLayer.Entities
{
    [Table("Ingredient")]
    public class IngredientEF: IMultiLanguageNameFields
    {
        [Key]
        public int Id{get;set;}
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public bool IsAllergen { get; set; }

        public IList<MealCompositionEF> MealsWithIngredient { get; set; }
    }

}
