using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandwichSystem.DataLayer.Entities
{
    [Table("Suppliers")]
    public class SupplierEF
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public ICollection<MealEF> Meals { get; set; }
    }
}
