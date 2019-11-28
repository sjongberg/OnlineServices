using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared;
using SandwichSystem.Shared.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class SandwichExtensions
    {
        public static SandwichTO ToTranfertObject(this SandwichEF Sandwich)
        {
            if (Sandwich is null)
                throw new ArgumentNullException(nameof(Sandwich));

            return new Shared.TransfertObjects.SandwichTO
            {
                Id = Sandwich.Id,
                Name = new StringTranslated(Sandwich.NameEnglish, Sandwich.NameFrench, Sandwich.NameDutch),
                Ingredients = Sandwich.SandwichIngredients?.Select(x => x.Ingredient.ToTranfertObject()).ToList(),
                Supplier = Sandwich.Supplier.ToTranfertObject()
            };
        }

        public static SandwichEF ToEF(this Shared.TransfertObjects.SandwichTO Sandwich)
        {
            if (Sandwich is null)
                throw new ArgumentNullException(nameof(Sandwich));

            var ReturnValue = new SandwichEF()
            {
                Id = Sandwich.Id,
                NameEnglish = Sandwich.Name.English,
                NameFrench = Sandwich.Name.French,
                NameDutch = Sandwich.Name.Dutch,

                Supplier = Sandwich.Supplier.ToEF(),
                SandwichIngredients = new List<SandwichIngredient>()

                //Ingredients = SandwichDTO.Ingredients.Select(x => x.ToEF()).ToList()
            };

            foreach (var i in Sandwich.Ingredients)
            {
                ReturnValue.SandwichIngredients.Add(
                    new SandwichIngredient()
                    {
                        IngredientId = i.Id,
                        Ingredient = i.ToEF(),
                        SandwichId = ReturnValue.Id,
                        Sandwich = ReturnValue
                    });
            }

            return ReturnValue;
        }
    }
}
