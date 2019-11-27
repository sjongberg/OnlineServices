using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichSystem;
using SandwichSystem.BusinessLayer;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared;

namespace SandwichSystem.BusinessLayer.DomainTests
{
    [TestClass]
    public class IngredientTests
    {
        Ingredient Tomate = new Ingredient(new StringTranslated("Tomato", "Tomate", "Tomaat"), false);
        Ingredient Brie = new Ingredient(new StringTranslated("Brie", "Brie", "Brie"), true);
        Ingredient Fromage = new Ingredient(new StringTranslated("Cheese", "Fromage", "Kaas"), true);
        Ingredient Noix = new Ingredient(new StringTranslated("Nuts", "Noix", "Noten"), true);
        Ingredient Beurre = new Ingredient(new StringTranslated("Butter", "Beurre", "Boter"), false);
        Ingredient Jambon = new Ingredient(new StringTranslated("Ham", "Jambon", "Ham"), false);
        Ingredient Roquette = new Ingredient(new StringTranslated("Arugula", "Roquette", "Rucola"), false);
        Ingredient Salade = new Ingredient(new StringTranslated("Salad", "Salade", "Salade"), false);
        Ingredient Pesto = new Ingredient(new StringTranslated("Pesto", "Pesto", "Pesto"), false);
        Ingredient Oeuf = new Ingredient(new StringTranslated("Eggs", "Oeufs", "Eien"), true);
        Ingredient Miel = new Ingredient(new StringTranslated("Honey", "Miel", "Honing"), false);

        Sandwich Club = new Sandwich(new StringTranslated("Club", "Club", "Club"), new Supplier { Id = 33, Name = "Supplier1" });
        Sandwich BrieNoix = new Sandwich(new StringTranslated("Brie", "Brie", "Brie"), new Supplier { Id = 33, Name = "Supplier1" });
        Sandwich PestoVerde = new Sandwich(new StringTranslated("Pesto", "Pesto", "Pesto"), new Supplier { Id = 33, Name = "Supplier1" });

        [TestMethod]
        public void ShowAllergene_ReturnsStart_WhenIngredientIsAllergen()
        {
            Assert.AreEqual(false, Tomate.IsAllergene);
            Assert.AreEqual(true, Fromage.IsAllergene);
            Assert.AreEqual(true, Noix.IsAllergene);
        }

        [TestMethod]
        public void ToString_ReturnsEnglishName_WhenEnglishEnumISProvided()
        {
            var sutd = Tomate.ToString(Language.English);
            Assert.AreEqual(sutd, "Tomato");
        }
        [TestMethod]
        public void ToString_ReturnsFrenchName_WhenFrenchEnumISProvided()
        {
            var sutd = Tomate.ToString(Language.French);
            Assert.AreEqual(sutd, "Tomate");
        }

        [TestMethod]
        public void ToString_ReturnsDutchName_WhenDutchEnumISProvided()
        {
            var sut = Tomate.ToString(Language.Dutch);
            Assert.AreEqual("Tomaat", sut);
        }

        [TestMethod]
        public void ToString_ReturnsIngredientWithAllergenInfo_WhenAllergenIsProvided()
        {
            var sut = Noix.ToString(Language.English);
            Assert.AreEqual("Nuts*", sut);
        }

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
