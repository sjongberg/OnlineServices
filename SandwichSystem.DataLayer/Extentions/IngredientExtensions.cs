
using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
using System;
using System.Linq;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class IngredientExtensions
    {
        public static IngredientDTO ToDTO(this IngredientEF Ingredient)
        {
            return new IngredientDTO
            {

            };
        }
        public static IngredientEF ToEF(this IngredientDTO IngredientDTO)
        {
            return new IngredientEF()
            {
                NameEnglish = IngredientDTO.Name.English,
                NameFrench = IngredientDTO.Name.French,
                NameDutch = IngredientDTO.Name.Dutch,

                IsAllergene = IngredientDTO.IsAllergene
            };
        }
    }
}
