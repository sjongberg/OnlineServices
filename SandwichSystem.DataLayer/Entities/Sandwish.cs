using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandwichSystem.DataLayer.Entities
{
    [Table("Sandwich")]
    public class SandwichEF
    {
        public int SandwichId { get; set; }
        
        [Column("Name")]
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public ICollection<IngredientEF> Ingredients { get; set; }
    }
}