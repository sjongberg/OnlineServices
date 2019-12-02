using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared;
using SandwichSystem.Shared.Extentions;
using SandwichSystem.Shared.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class MealExtensions
    {
        public static MealTO ToTranfertObject(this MealEF Meal)
        {
            if (Meal is null)
                throw new ArgumentNullException(nameof(Meal));

            return new MealTO
            {
                Id = Meal.Id,
                Name = Meal.ExtractToStringTranslated(),
                Ingredients = Meal.MealsComposition?.Select(x => x.Ingredient.ToTranfertObject()).ToList(),
                Supplier = Meal.Supplier.ToTranfertObject(),
                MealType = Meal.MealType,
            };
        }

        public static MealEF ToEF(this Shared.TransfertObjects.MealTO Sandwich)
        {
            if (Sandwich is null)
                throw new ArgumentNullException(nameof(Sandwich));

            var ReturnValue = new MealEF()
            {
                Id = Sandwich.Id,

                Supplier = Sandwich.Supplier.ToEF(),
                MealType = Sandwich.MealType,
                MealsComposition = new List<MealCompositionEF>()

                //Ingredients = SandwichDTO.Ingredients.Select(x => x.ToEF()).ToList()
            };

            ReturnValue = ReturnValue.FillFromStringTranslated(Sandwich.Name);


            //TODO IngredientsTO to MealComposition Extention to use as
            // andwichDTO.Ingredients.Select(x => x.ToMealCompositionEF()).ToList()??? or method in this file as toMEalComposition...
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

        public static MealEF UpdateFieldsFromDetached(this MealEF AttachedEF, MealEF DetachedEF)
        {
            if ((AttachedEF != default) && (DetachedEF != default))
            {
                //AttachedEF.MealsComposition = //DetachedEF.MealsComposition;
                //AttachedEF.MealsComposition
                //    .ToList()
                //    .UpdateListFromDetached(DetachedEF.MealsComposition.ToList());

                AttachedEF = AttachedEF.FillFromStringTranslated(DetachedEF.ExtractToStringTranslated());
                AttachedEF.Supplier = DetachedEF.Supplier;
                AttachedEF.MealType = DetachedEF.MealType;
            }

            return AttachedEF;
        }
    }
}
