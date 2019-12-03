using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealServices.BusinessLayer.Domain;
using MealServices.Shared;
using MealServices.Shared.Enumerations;

namespace MealServices.BusinessLayer.DomainTests
{
    [TestClass]
    public class MealTests
    {
        Ingredient Brie = new Ingredient(new StringTranslated("Brie", "Brie", "Brie"), true);
        Ingredient Noix = new Ingredient(new StringTranslated("Nuts", "Noix", "Noten"), true);
        Ingredient Miel = new Ingredient(new StringTranslated("Honey", "Miel", "Honing"), false);


        Meal BrieNoix = new Meal(new StringTranslated("Brie", "Brie", "Brie"), new Supplier { Id = 33, Name = "Supplier1" });

        [TestMethod]
        public void GetIngredientsString_ReturnsACompleteListOFIngredientsWithAllergeneInfo()
        {
            BrieNoix.Ingredients.Add(Brie);
            BrieNoix.Ingredients.Add(Miel);
            BrieNoix.Ingredients.Add(Noix);

            var sute = BrieNoix.GetIngredientsString(Language.English);
            Assert.AreEqual(sute, "Brie* - Honey - Nuts*");
        }
    }
}
