using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.DataLayer.Entities
{
    public class IngredientEF
    {
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }
        public string NameDutch { get; set; }
        public bool IsAllergene { get; set; }
    }

}
