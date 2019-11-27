using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
using SandwichSystem.Shared.Enumerations;
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
                Id = Sandwich.Id,
                Name = Sandwich.ToString(Langue),
                Ingredients = String.Join(" - ", Sandwich.Ingredients.Select(x => x.ToString(Langue))),
                Supplier = Sandwich.Supplier.ToBTO()
            };
        }

        public static Sandwich ToDomain(this SandwichDTO SandwichDTO)
        {
            return new Sandwich(new StringTranslated(SandwichDTO.Name.English, SandwichDTO.Name.French, SandwichDTO.Name.Dutch), SandwichDTO.Supplier.ToDomain())
            {
                Id = SandwichDTO.Id,
                Ingredients = SandwichDTO.Ingredients.Select(x => x.ToDomain()).ToList()
            };
        }
    }
}
