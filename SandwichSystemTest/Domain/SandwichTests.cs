using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichSystem;
using SandwichSystem.BusinessLayer;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared;

namespace SandwichSystem.BusinessLayer.DomainTests
{
    [TestClass]
    public class SandwichTests
    {
        Ingredient Brie = new Ingredient(new StringTranslated("Brie", "Brie", "Brie"), true);
        Ingredient Noix = new Ingredient(new StringTranslated("Nuts", "Noix", "Noten"), true);
        Ingredient Miel = new Ingredient(new StringTranslated("Honey", "Miel", "Honing"), false);


        Sandwich BrieNoix = new Sandwich(new StringTranslated("Brie", "Brie", "Brie"), new Supplier { Id = 33, Name = "Supplier1" });

        [TestMethod]
        public void GetIngredientsString_ReturnsACompleteListOFIngredientsWithAllergeneInfo()
        {
            BrieNoix.Ingredients.Add(Brie);
            BrieNoix.Ingredients.Add(Miel);
            BrieNoix.Ingredients.Add(Noix);

            var sute = BrieNoix.GetIngredientsString(Language.English);
            Assert.AreEqual(sute, "Brie* - Honey - Nuts*");
        }

        [TestMethod]
        public void Supplier_ReturnsTheSupplierUsedInCTOR()
        {
            var supplierSUT = new Supplier { Id = 33, Name = "Supplier1" };

            Sandwich BrieNoix2 = new Sandwich(new StringTranslated("Brie", "Brie", "Brie"), supplierSUT);

            Assert.AreEqual(supplierSUT.Id, BrieNoix2.Supplier.Id);
            Assert.AreEqual(supplierSUT.Name, BrieNoix2.Supplier.Name);
        }
    }
}
