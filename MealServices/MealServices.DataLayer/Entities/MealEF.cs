using OnlineServices.Shared;
using OnlineServices.Shared.MealServices.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealServices.DataLayer.Entities
{
    [Table("Meal")]
    public class MealEF: IMultiLanguage
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