using OnlineServices.Shared.MealServices.Enumerations;
using OnlineServices.Shared.TranslationServices;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealServices.DataLayer.Entities
{
    [Table("Meals")]
    public class MealEF : IMultiLanguageNameFields
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