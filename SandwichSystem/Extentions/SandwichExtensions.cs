using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared;
using SandwichSystem.Shared.Enumerations;
using SandwichSystem.Shared.TransfertObjects;
using System;
using System.Linq;

namespace SandwichSystem.BusinessLayer.Extentions
{
    public static class SandwichExtensions
    {
        //public static SandwichBTO ToBTO(this Sandwich Sandwich, Language Langue)
        //{
        //    return new SandwichBTO
        //    {
        //        Id = Sandwich.Id,
        //        Name = Sandwich.ToString(Langue),
        //        Ingredients = String.Join(" - ", Sandwich.Ingredients.Select(x => x.ToString(Langue))),
        //        //Supplier = Sandwich.Supplier.ToTransfertObject()
        //    };
        //}

        public static Sandwich ToDomain(this MealTO SandwichTO)
        {
            return new Sandwich(SandwichTO.Name, SandwichTO.Supplier.ToDomain())
            {
                Id = SandwichTO.Id,
                Ingredients = SandwichTO.Ingredients.Select(x => x.ToDomain()).ToList()
            };
        }

        public static MealTO ToTransfertObject(this Sandwich Sandwich)
        {
            return new MealTO
            {
                Id = Sandwich.Id,
                Name = Sandwich.Name,
                Ingredients = Sandwich.Ingredients.Select(x => x.ToTransfertObject()).ToList(),
                Supplier = Sandwich.Supplier.ToTransfertObject()
            };
        }
    }
}
