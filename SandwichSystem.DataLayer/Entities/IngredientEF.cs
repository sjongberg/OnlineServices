using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public bool IsAllergene { get; set; }

        public IList<SandwichIngredient> SandwichIngredients { get; set; }
    }

}
