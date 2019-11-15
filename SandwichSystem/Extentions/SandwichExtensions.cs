using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared.BTO;
using System;
using System.Linq;

namespace SandwichSystem.BusinessLayer.Extentions
{
    public static class SandwichExtensions
    {
        public static SandwichBTO ToBTO(this Sandwich Sandwich, Language Langue)
        {
            return new SandwichBTO
            {
                Name = Sandwich.Name.ToString(Langue),
                Ingredients = String.Join(", ", Sandwich.Ingredients.Select(x => x.Name.ToString(Langue) + x.ShowAllergene()))
            };
        }
    }
}
