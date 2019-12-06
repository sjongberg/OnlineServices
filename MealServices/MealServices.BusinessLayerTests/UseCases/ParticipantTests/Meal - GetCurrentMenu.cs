using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MealServices.Shared.Interfaces;
using MealServices.Shared;
using OnlineServices.Shared.Enumerations;
using System.Collections.Generic;
using System.Linq;
using MealServices.BusinessLayer.Extensions;
using OnlineServices.Shared.MealServices.TransfertObjects;
using OnlineServices.Shared.MealServices.Enumerations;
using OnlineServices.Shared.TranslationServices.TransfertObjects;

namespace MealServices.BusinessLayer.UseCases.Tests
{
    [TestClass()]
    public class ParticipantTests
    {
        private List<MealTO> GetTestsListOfMeals()
        {
            //REchercher Founisseur
            var Tomate = new IngredientTO { Id = 1, Name = new MultiLanguageString("Tomato", "Tomate", "Tomaat"), IsAllergen = false };
            var Brie = new IngredientTO { Id = 2, Name = new MultiLanguageString("Brie", "Brie", "Brie"), IsAllergen = true };
            var Fromage = new IngredientTO { Id = 3, Name = new MultiLanguageString("Cheese", "Fromage", "Kaas"), IsAllergen = true };
            var Noix = new IngredientTO { Id = 4, Name = new MultiLanguageString("Nuts", "Noix", "Noten"), IsAllergen = true };
            var Beurre = new IngredientTO { Id = 5, Name = new MultiLanguageString("Butter", "Beurre", "Boter"), IsAllergen = false };
            var Jambon = new IngredientTO { Id = 6, Name = new MultiLanguageString("Ham", "Jambon", "Ham"), IsAllergen = false };
            var Roquette = new IngredientTO { Id = 7, Name = new MultiLanguageString("Arugula", "Roquette", "Rucola"), IsAllergen = false };
            var Salade = new IngredientTO { Id = 8, Name = new MultiLanguageString("Salad", "Salade", "Salade"), IsAllergen = false };
            var Pesto = new IngredientTO { Id = 9, Name = new MultiLanguageString("Pesto", "Pesto", "Pesto"), IsAllergen = false };
            var Oeuf = new IngredientTO { Id = 10, Name = new MultiLanguageString("Eggs", "Oeufs", "Eien"), IsAllergen = true };
            var Miel = new IngredientTO { Id = 11, Name = new MultiLanguageString("Honey", "Miel", "Honing"), IsAllergen = false };

            MealTO Club = new MealTO { Id = 1, Name = new MultiLanguageString("ClubEN", "ClubFR", "ClubNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>(), MealType=MealType.Sandwich };
            MealTO BrieNoix = new MealTO { Id = 2, Name = new MultiLanguageString("BrieEN", "BrieFR", "BrieNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>(), MealType = MealType.Sandwich };
            MealTO PestoVerde = new MealTO { Id = 3, Name = new MultiLanguageString("PestoEN", "PestoFR", "PestoNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>(), MealType = MealType.Sandwich };

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
            //Rechercher la liste de meal

            var lst = new List<MealTO>(); ;

            lst.Add(BrieNoix);
            lst.Add(Club);
            lst.Add(PestoVerde);

            return lst;
        }

        [TestMethod()]
        public void GetCurrentMenu_ReturnHasRightCountOfMeals_WhenAValidLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            //fakeMealRepo.Setup(x => x.GetAll()).Returns(GetTestsListOfMeal());
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(GetTestsListOfMeals());

            //var fakeIngredientRepo = new Mock<IRepository<IngredientTO, int>>();

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu();

            //ASSERT
            Assert.AreEqual(3, listMenu.Count());
        }

        [TestMethod]
        public void GetCurrentMenu_ReturnMealsInEnglish_WhenEnglishLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(GetTestsListOfMeals());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu();

            //ASSERT
            Assert.AreEqual("BrieEN", listMenu.Skip(0).First().ToDomain().ToString(Language.English));
            Assert.AreEqual("ClubEN", listMenu.Skip(1).First().ToDomain().ToString(Language.English));
            Assert.AreEqual("PestoEN", listMenu.Skip(2).First().ToDomain().ToString(Language.English));

            Assert.AreEqual("Brie* - Honey - Nuts*", listMenu.Skip(0).First().ToDomain().GetIngredientsString(Language.English));
            Assert.AreEqual("Ham - Butter - Salad - Cheese*", listMenu.Skip(1).First().ToDomain().GetIngredientsString(Language.English));
            Assert.AreEqual("Pesto - Arugula - Eggs*", listMenu.Skip(2).First().ToDomain().GetIngredientsString(Language.English));
        }

        [TestMethod]
        public void GetCurrentMenu_ReturnMealsInFrench_WhenFrenchLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(GetTestsListOfMeals());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu();

            //ASSERT
            Assert.AreEqual("BrieFR", listMenu.Skip(0).First().ToDomain().ToString(Language.French));
            Assert.AreEqual("ClubFR", listMenu.Skip(1).First().ToDomain().ToString(Language.French));
            Assert.AreEqual("PestoFR", listMenu.Skip(2).First().ToDomain().ToString(Language.French));

            Assert.AreEqual("Brie* - Miel - Noix*", listMenu.Skip(0).First().ToDomain().GetIngredientsString(Language.French));
            Assert.AreEqual("Jambon - Beurre - Salade - Fromage*", listMenu.Skip(1).First().ToDomain().GetIngredientsString(Language.French));
            Assert.AreEqual("Pesto - Roquette - Oeufs*", listMenu.Skip(2).First().ToDomain().GetIngredientsString(Language.French));
        }

        [TestMethod]
        public void GetCurrentMenu_ReturnMealsWithDutch_WhenDutchLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(GetTestsListOfMeals());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.GetCurrentMenu();

            //ASSERT
            Assert.AreEqual("BrieNL", listMenu.Skip(0).First().ToDomain().ToString(Language.Dutch));
            Assert.AreEqual("ClubNL", listMenu.Skip(1).First().ToDomain().ToString(Language.Dutch));
            Assert.AreEqual("PestoNL", listMenu.Skip(2).First().ToDomain().ToString(Language.Dutch));

            Assert.AreEqual("Brie* - Honing - Noten*", listMenu.Skip(0).First().ToDomain().GetIngredientsString(Language.Dutch));
            Assert.AreEqual("Ham - Boter - Salade - Kaas*", listMenu.Skip(1).First().ToDomain().GetIngredientsString(Language.Dutch));
            Assert.AreEqual("Pesto - Rucola - Eien*", listMenu.Skip(2).First().ToDomain().GetIngredientsString(Language.Dutch));
        }
        [TestMethod]
        public void MyTestMethod()
        {
            string a = "";

            Assert.IsTrue(string.IsNullOrWhiteSpace(a));
            Assert.IsTrue(string.IsNullOrEmpty(a));
        }
    }
}