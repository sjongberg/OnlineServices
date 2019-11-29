using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared;
using SandwichSystem.Shared.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class MealExtensions
    {
        public static MealTO ToTranfertObject(this MealEF Sandwich)
        {
            if (Sandwich is null)
                throw new ArgumentNullException(nameof(Sandwich));

            return new Shared.TransfertObjects.MealTO
            {
                Id = Sandwich.Id,
                Name = new StringTranslated(Sandwich.NameEnglish, Sandwich.NameFrench, Sandwich.NameDutch),
                Ingredients = Sandwich.MealsComposition?.Select(x => x.Ingredient.ToTranfertObject()).ToList(),
                Supplier = Sandwich.Supplier.ToTranfertObject()
            };
        }

        public static MealEF ToEF(this Shared.TransfertObjects.MealTO Sandwich)
        {
            if (Sandwich is null)
                throw new ArgumentNullException(nameof(Sandwich));

            var ReturnValue = new MealEF()
            {
                Id = Sandwich.Id,
                NameEnglish = Sandwich.Name.English,
                NameFrench = Sandwich.Name.French,
                NameDutch = Sandwich.Name.Dutch,

                Supplier = Sandwich.Supplier.ToEF(),
                MealType = Sandwich.MealType,
                MealsComposition = new List<MealCompositionEF>()

                //Ingredients = SandwichDTO.Ingredients.Select(x => x.ToEF()).ToList()
            };

            foreach (var i in Sandwich.Ingredients)
            {
                ReturnValue.MealsComposition.Add(
                    new MealCompositionEF()
                    {
                        IngredientId = i.Id,
                        Ingredient = i.ToEF(),
                        MealId = ReturnValue.Id,
                        Meal = ReturnValue
                    });
            }

            return ReturnValue;
        }
    }
}
