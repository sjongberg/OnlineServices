using MealServices.Shared;
using MealServices.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.BusinessLayer.Domain
{
    public class Meal
    {
        public Meal(StringTranslated Name, Supplier Supplier)
        {
            this.Name = Name;
            this.Supplier = Supplier;
        }

        public int Id { get; set; }

        public StringTranslated Name { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public MealType MealType { get; set; }

        public string ToString(Language Langue)
            => Name.ToString(Langue);

        public string GetIngredientsString(Language Langue)
            => String.Join(" - ", Ingredients.Select(x => x.ToString(Langue)));

        public Supplier Supplier { get; private set; }
    }
}
