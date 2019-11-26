using SandwichSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.BusinessLayer.Domain
{
    public class Sandwich
    {
        
        public StringTranslated Name { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public Sandwich(StringTranslated Name)
        {
            this.Name = Name;
        }

        public string GetIngredients(Language Langue)
            => String.Join(" - ", Ingredients.Select(x => x.ToString(Langue)));

        //DOC Substitué par le code au-dessus...
        //public string ShowIngredients(Language Langue)
        //{
        //    var result = "";
        //    var index = 0;
        //    foreach (Ingredient i in Ingredients)
        //    {
        //        if (index < Ingredients.Count-1)
        //        {
        //            result += i.ToString(Langue) + " - ";
        //        }
        //        else
        //        {
        //            result += i.ToString(Langue);
        //        }
        //        index++;
        //    }
        //    return result;
        //}

        public Supplier Supplier { get; set; }
    }
}
