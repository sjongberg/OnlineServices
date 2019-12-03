using MealServices.DataLayer.Entities;
using MealServices.Shared;
using MealServices.Shared.Extentions;
using MealServices.Shared.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Extentions
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

        public static MealEF ToEF(this MealTO Meal)
        {
            if (Meal is null)
                throw new ArgumentNullException(nameof(Meal));

            var ReturnValue = new MealEF()
            {
                Id = Meal.Id,

                Supplier = Meal.Supplier.ToEF(),
                MealType = Meal.MealType,
                MealsComposition = new List<MealCompositionEF>()

                //Ingredients = MealTO.Ingredients.Select(x => x.ToEF()).ToList()
            };

            ReturnValue = ReturnValue.FillFromStringTranslated(Meal.Name);


            //TODO IngredientsTO to MealComposition Extention to use as
            // andwichDTO.Ingredients.Select(x => x.ToMealCompositionEF()).ToList()??? or method in this file as toMEalComposition...
            foreach (var i in Meal.Ingredients)
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

        public static MealEF UpdateFromDetached(this MealEF AttachedEF, MealEF DetachedEF)
        {
            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update MealEF entity as it is not the same.");

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
