using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandwichSystem.DataLayer.Entities
{
    [Table("Sandwich")]
    public class SandwichEF
    {
        [Key]
        public int Id { get; set; }
        
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }

        public SupplierEF Supplier { get; set; }

        public IList<SandwichIngredient> SandwichIngredients { get; set; }
    }
}