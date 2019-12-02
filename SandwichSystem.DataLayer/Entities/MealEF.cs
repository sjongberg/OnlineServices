using SandwichSystem.Shared.Enumerations;
using SandwichSystem.Shared.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandwichSystem.DataLayer.Entities
{
    [Table("Meal")]
    public class MealEF: IMultiLanguageFields
    {
        [Key]
        public int Id { get; set; }
        
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }

        public MealType MealType { get; set; }

        public SupplierEF Supplier { get; set; }

        public IList<MealCompositionEF> MealsComposition { get; set; }
    }
}