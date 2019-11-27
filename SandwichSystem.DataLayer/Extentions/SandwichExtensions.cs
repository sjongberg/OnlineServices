
using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class SandwichExtensions
    {
        public static SandwichDTO ToDTO(this SandwichEF SandwichEF)
        {
            if (SandwichEF is null)
                throw new ArgumentNullException(nameof(SandwichEF));

            return new SandwichDTO
            {
                Id = SandwichEF.Id,
                Name = new StringTranslated(SandwichEF.NameEnglish, SandwichEF.NameFrench, SandwichEF.NameDutch),
                Ingredients = SandwichEF.SandwichIngredients?.Select(x => x.Ingredient.ToDTO()).ToList(),
                Supplier = SandwichEF.Supplier.ToDTO()
            };
        }

        public static SandwichEF ToEF(this SandwichDTO SandwichDTO)
        {
            if (SandwichDTO is null)
                throw new ArgumentNullException(nameof(SandwichDTO));

            var ReturnValue = new SandwichEF()
            {
                Id = SandwichDTO.Id,
                NameEnglish = SandwichDTO.Name.English,
                NameFrench = SandwichDTO.Name.French,
                NameDutch = SandwichDTO.Name.Dutch,

                Supplier = SandwichDTO.Supplier.ToEF(),
                SandwichIngredients = new List<SandwichIngredient>()

                //Ingredients = SandwichDTO.Ingredients.Select(x => x.ToEF()).ToList()
            };

            foreach (var i in SandwichDTO.Ingredients)
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
