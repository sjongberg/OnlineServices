using SandwichSystem.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.BusinessLayer.Domain
{
    public class Ingredient
    {
        public StringTranslated Name { get; set; }
        public bool IsAllergene { get; set; }

        public Ingredient(StringTranslated Name, bool isAllergene)
        {
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.IsAllergene = isAllergene;
        }

        public string ToString(Language Langue)
            => Name.ToString(Langue) + (IsAllergene? "*":"");


    }

}
