using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared;
using SandwichSystem.Shared.TransfertObjects;
using System;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class IngredientExtensions
    {
        public static IngredientTO ToTranfertObject(this IngredientEF Ingredient)
        {
            if (Ingredient is null)
                throw new ArgumentNullException(nameof(Ingredient));

            return new IngredientTO
            {
                Id = Ingredient.Id,
                Name = new StringTranslated(Ingredient.NameEnglish, Ingredient.NameFrench, Ingredient.NameDutch),
                IsAllergen = Ingredient.IsAllergen
            };
        }

        public static IngredientEF ToEF(this IngredientTO Ingredient)
        {
            if (Ingredient is null)
                throw new ArgumentNullException(nameof(Ingredient));

            return new IngredientEF()
            {
                Id = Ingredient.Id,
                NameEnglish = Ingredient.Name.English,
                NameFrench = Ingredient.Name.French,
                NameDutch = Ingredient.Name.Dutch,

                IsAllergen = Ingredient.IsAllergen
            };
        }
    }
}
