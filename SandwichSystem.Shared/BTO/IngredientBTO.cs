using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.Shared.BTO
{
    public class IngredientBTO
    {
        public int Id { get; set; }
        public StringTranslated Name { get; set; }
        public bool IsAllergen { get; set; }
    }

}
