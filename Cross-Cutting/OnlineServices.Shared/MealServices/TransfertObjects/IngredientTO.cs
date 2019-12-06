using OnlineServices.Shared.TranslationServices.TransfertObjects;

namespace OnlineServices.Shared.MealServices.TransfertObjects
{
    public class IngredientTO
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool IsAllergen { get; set; }
    }

}
