using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared.BTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.BusinessLayer.Extentions
{
    public static class IngredientExtensions
    {
        public static IngredientBTO ToBTO(this Ingredient Ingredient, Language Language)
        {
            return new IngredientBTO 
            { 
                Name = Ingredient.Name.ToString(Language),
            };
        }
    }
}
