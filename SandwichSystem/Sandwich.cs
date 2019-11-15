using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.BusinessLayer
{
    public class Sandwish
    {

        public StringTranslated Name { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public Sandwish(StringTranslated Name)
        {
            this.Name = Name;
        }

        public string ShowIngredients(Language Langue)
        {
            var result = "";
            var index = 0;
            foreach (Ingredient i in Ingredients)
            {
                if (index < Ingredients.Count-1)
                {
                    result += i.ToString(Langue) + " - ";
                }
                else
                {
                    result += i.ToString(Langue);
                }
                index++;
            }
            return result;
        }

    }
}
