using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
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
        public static Sandwich ToDomain(this SandwichBTO SandwichBTO, Language Langue)
        {
            return new Sandwich(new StringTranslated("traduction english", "traduction french", "traduction du"))
            {
                Ingredients = SandwichBTO.Ingredients.Split(" - ").Select(x => x.ToDomain(Langue)).ToList()
            };
        }

        public static Sandwich ToDomain(this SandwichDTO SandwichDTO)
        {
            return new Sandwich(new StringTranslated("traduction english", "traduction french", "traduction du"))
            {
                Ingredients = SandwichDTO.Ingredients.Select(x => x.ToDomain()).ToList()
            };
        }
        public static Ingredient ToDomain(this string ingredientBTO, Language Langue)
        {
            //TO IMPLEMENT
            return new Ingredient(null, false);
        }
        public static Ingredient ToDomain(this IngredientDTO IngredientDTO)
        {
            return new Ingredient(IngredientDTO.Name, IngredientDTO.IsAllergene);
        }
    }
}
