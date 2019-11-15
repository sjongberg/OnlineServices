using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichSystem;
using SandwichSystem.BusinessLayer;
using SandwichSystem.BusinessLayer.Domain;

namespace SandwichSystem.BusinessLayerTests
{
    [TestClass]
    public class IsAllergeneTest
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

        Sandwich Club = new Sandwich(new StringTranslated("Club", "Club", "Club"));
        Sandwich BrieNoix = new Sandwich(new StringTranslated("Brie", "Brie", "Brie"));
        Sandwich PestoVerde = new Sandwich(new StringTranslated("Pesto", "Pesto", "Pesto"));

        [TestMethod]
        public void ShowAllergene_ReturnsStart_WhenIngredientIsAllergen()
        {
            var suta = Tomate.ShowAllergene();
            Assert.AreEqual(suta, "");

            var sutb = Fromage.ShowAllergene();
            Assert.AreEqual(sutb, "*");

            var sutc = Noix.ShowAllergene();
            Assert.AreEqual(sutc, "*");
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
            var sutd = Tomate.ToString(Language.Dutch);
            Assert.AreEqual(sutd, "Tomaat");
        }

        [TestMethod]
        public void ToString_ReturnsIngredientWithAllergenInfo_WhenAllergenIsProvided()
        {
            var sutd = Noix.ToString(Language.English);
            Assert.AreEqual(sutd, "Nuts*");
        }

        [TestMethod]
        public void ShowIngredients()
        {
            BrieNoix.Ingredients.Add(Brie);
            BrieNoix.Ingredients.Add(Miel);
            BrieNoix.Ingredients.Add(Noix);

            PestoVerde.Ingredients.Add(Pesto);
            PestoVerde.Ingredients.Add(Roquette);
            PestoVerde.Ingredients.Add(Oeuf);

            Club.Ingredients.Add(Jambon);
            Club.Ingredients.Add(Beurre);
            Club.Ingredients.Add(Salade);
            Club.Ingredients.Add(Fromage);

            var sute = BrieNoix.GetIngredients(Language.English);
            Assert.AreEqual(sute, "Brie* - Honey - Nuts*");
        }
    }
}
