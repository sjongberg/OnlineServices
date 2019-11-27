using SandwichSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.BusinessLayer.Domain
{
    public class Sandwich
    {
        public Sandwich(StringTranslated Name, Supplier Supplier)
        {
            this.Name = Name;
            this.Supplier = Supplier;
        }

        public int Id { get; set; }

        public StringTranslated Name { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public string ToString(Language Langue)
            => Name.ToString(Langue);

        public string GetIngredientsString(Language Langue)
            => String.Join(" - ", Ingredients.Select(x => x.ToString(Langue)));

        public Supplier Supplier { get; private set; }
    }
}
