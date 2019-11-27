using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SandwichSystem.DataLayer.Entities
{
    [Table("Suppliers")]
    public class SupplierEF
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsCurrentSupplier { get; set; }

        public ICollection<SandwichEF> Sandwiches { get; set; }
    }
}
