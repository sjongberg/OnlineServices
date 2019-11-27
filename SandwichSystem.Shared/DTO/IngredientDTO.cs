using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.Shared.DTO
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public StringTranslated Name { get; set; }
        public bool IsAllergen { get; set; }
    }

}
