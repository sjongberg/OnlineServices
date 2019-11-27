using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.Shared.Interfaces;
using SandwichSystem.Shared;
using SandwichSystem.Shared.DTO;
using SandwichSystem.Shared.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.BusinessLayer.UseCases.Tests
{
    [TestClass()]
    public class ParticipantTests
    {
        private List<SandwichDTO> GetTestsListOfSandwich()
        {
            //REchercher Founisseur
            IngredientDTO Tomate = new IngredientDTO { Id = 1, Name = new StringTranslated("Tomato", "Tomate", "Tomaat"), IsAllergen = false };
            IngredientDTO Brie = new IngredientDTO { Id = 2, Name = new StringTranslated("Brie", "Brie", "Brie"), IsAllergen = true };
            IngredientDTO Fromage = new IngredientDTO { Id = 3, Name = new StringTranslated("Cheese", "Fromage", "Kaas"), IsAllergen = true };
            IngredientDTO Noix = new IngredientDTO { Id = 4, Name = new StringTranslated("Nuts", "Noix", "Noten"), IsAllergen = true };
            IngredientDTO Beurre = new IngredientDTO { Id = 5, Name = new StringTranslated("Butter", "Beurre", "Boter"), IsAllergen = false };
            IngredientDTO Jambon = new IngredientDTO { Id = 6, Name = new StringTranslated("Ham", "Jambon", "Ham"), IsAllergen = false };
            IngredientDTO Roquette = new IngredientDTO { Id = 7, Name = new StringTranslated("Arugula", "Roquette", "Rucola"), IsAllergen = false };
            IngredientDTO Salade = new IngredientDTO { Id = 8, Name = new StringTranslated("Salad", "Salade", "Salade"), IsAllergen = false };
            IngredientDTO Pesto = new IngredientDTO { Id = 9, Name = new StringTranslated("Pesto", "Pesto", "Pesto"), IsAllergen = false };
            IngredientDTO Oeuf = new IngredientDTO { Id = 10, Name = new StringTranslated("Eggs", "Oeufs", "Eien"), IsAllergen = true };
            IngredientDTO Miel = new IngredientDTO { Id = 11, Name = new StringTranslated("Honey", "Miel", "Honing"), IsAllergen = false };

            SandwichDTO Club = new SandwichDTO { Id = 1, Name = new StringTranslated("ClubEN", "ClubFR", "ClubNL"), Supplier = new SupplierDTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientDTO>() };
            SandwichDTO BrieNoix = new SandwichDTO { Id = 2, Name = new StringTranslated("BrieEN", "BrieFR", "BrieNL"), Supplier = new SupplierDTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientDTO>() };
            SandwichDTO PestoVerde = new SandwichDTO { Id = 3, Name = new StringTranslated("PestoEN", "PestoFR", "PestoNL"), Supplier = new SupplierDTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientDTO>() };

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
            //Rechercher la liste de sandwich

            var lst = new List<SandwichDTO>(); ;

            lst.Add(BrieNoix);
            lst.Add(Club);
            lst.Add(PestoVerde);

            return lst;
        }

        [TestMethod()]
        public void GetCurrentMenu_ReturnHasRightCountOfSandwiches_WhenAValidLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierDTO() { Id = 33, Name = "MockedSupplier" };

            var fakeSandwichRepo = new Mock<ISandwichRepository>();
            //fakeSandwichRepo.Setup(x => x.GetAll()).Returns(GetTestsListOfSandwich());
            fakeSandwichRepo.Setup(x => x.GetSandwichesBySupplier(It.IsAny<SupplierDTO>())).Returns(GetTestsListOfSandwich());

            //var fakeIngredientRepo = new Mock<IRepository<IngredientDTO, int>>();

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetCurrentSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.SandwichRepository).Returns(fakeSandwichRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu(Language.English);

            //ASSERT
            Assert.AreEqual(3, listMenu.Count());
        }

        [TestMethod]
        public void GetCurrentMenu_ReturnSandwichesInEnglish_WhenEnglishLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierDTO() { Id = 33, Name = "MockedSupplier" };

            var fakeSandwichRepo = new Mock<ISandwichRepository>();
            fakeSandwichRepo.Setup(x => x.GetSandwichesBySupplier(It.IsAny<SupplierDTO>())).Returns(GetTestsListOfSandwich());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetCurrentSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.SandwichRepository).Returns(fakeSandwichRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu(Language.English);

            //ASSERT
            Assert.AreEqual("BrieEN", listMenu.Skip(0).First().Name);
            Assert.AreEqual("ClubEN", listMenu.Skip(1).First().Name);
            Assert.AreEqual("PestoEN", listMenu.Skip(2).First().Name);

            Assert.AreEqual("Brie* - Honey - Nuts*", listMenu.Skip(0).First().Ingredients);
            Assert.AreEqual("Ham - Butter - Salad - Cheese*", listMenu.Skip(1).First().Ingredients);
            Assert.AreEqual("Pesto - Arugula - Eggs*", listMenu.Skip(2).First().Ingredients);
        }

        [TestMethod]
        public void GetCurrentMenu_ReturnSandwichesInFrench_WhenFrenchLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierDTO() { Id = 33, Name = "MockedSupplier" };

            var fakeSandwichRepo = new Mock<ISandwichRepository>();
            fakeSandwichRepo.Setup(x => x.GetSandwichesBySupplier(It.IsAny<SupplierDTO>())).Returns(GetTestsListOfSandwich());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetCurrentSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.SandwichRepository).Returns(fakeSandwichRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu(Language.French);

            //ASSERT
            Assert.AreEqual("BrieFR", listMenu.Skip(0).First().Name);
            Assert.AreEqual("ClubFR", listMenu.Skip(1).First().Name);
            Assert.AreEqual("PestoFR", listMenu.Skip(2).First().Name);

            Assert.AreEqual("Brie* - Miel - Noix*", listMenu.Skip(0).First().Ingredients);
            Assert.AreEqual("Jambon - Beurre - Salade - Fromage*", listMenu.Skip(1).First().Ingredients);
            Assert.AreEqual("Pesto - Roquette - Oeufs*", listMenu.Skip(2).First().Ingredients);
        }

        [TestMethod]
        public void GetCurrentMenu_ReturnSandwichesInDutch_WhenDutchLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierDTO() { Id = 33, Name = "MockedSupplier" };

            var fakeSandwichRepo = new Mock<ISandwichRepository>();
            fakeSandwichRepo.Setup(x => x.GetSandwichesBySupplier(It.IsAny<SupplierDTO>())).Returns(GetTestsListOfSandwich());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetCurrentSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.SandwichRepository).Returns(fakeSandwichRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu(Language.Dutch);

            //ASSERT
            Assert.AreEqual("BrieNL", listMenu.Skip(0).First().Name);
            Assert.AreEqual("ClubNL", listMenu.Skip(1).First().Name);
            Assert.AreEqual("PestoNL", listMenu.Skip(2).First().Name);

            Assert.AreEqual("Brie* - Honing - Noten*", listMenu.Skip(0).First().Ingredients);
            Assert.AreEqual("Ham - Boter - Salade - Kaas*", listMenu.Skip(1).First().Ingredients);
            Assert.AreEqual("Pesto - Rucola - Eien*", listMenu.Skip(2).First().Ingredients);
        }
    }
}