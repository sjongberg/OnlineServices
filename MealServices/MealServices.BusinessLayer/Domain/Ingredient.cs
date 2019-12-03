using MealServices.Shared;
using MealServices.Shared.Enumerations;
using System;

namespace MealServices.BusinessLayer.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }

        public StringTranslated Name { get; set; }

        public bool IsAllergen { get; set; }

        public Ingredient(StringTranslated Name, bool isAllergene)
        {
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.IsAllergen = isAllergene;
        }

        public string ToString(Language Langue)
            => Name.ToString(Langue) + (IsAllergen? "*":"");
    }

}
