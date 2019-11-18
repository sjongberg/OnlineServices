
using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
using System;
using System.Linq;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class SandwichExtensions
    {
        public static SandwichDTO ToDTO(this SandwichEF SandwichEF)
        {
            return new SandwichDTO
            {
            };
        }
        public static SandwichEF ToEF(this SandwichDTO SandwichDTO)
        {
            return new SandwichEF()
            {
                NameEnglish = SandwichDTO.Name.English,
                NameFrench = SandwichDTO.Name.French,
                NameDutch = SandwichDTO.Name.Dutch,

                Ingredients = SandwichDTO.Ingredients.Select(x => x.ToEF()).ToList()
            };
        }
    }
}
