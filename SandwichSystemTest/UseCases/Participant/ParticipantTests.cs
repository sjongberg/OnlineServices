using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.BusinessLayer.UseCases;
using SandwichSystem.DataLayer;
using SandwichSystem.DataLayer.Interfaces;
using SandwichSystem.Shared;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.BusinessLayer.UseCases.Tests
{
    [TestClass()]
    public class ParticipantTests
    {
        public List<SandwichDTO> GetTestsListOfSandwich()
        {
            //REchercher Founisseur
            IngredientDTO Tomate = new IngredientDTO { Name = new StringTranslated("Tomato", "Tomate", "Tomaat"), IsAllergen = false };
            IngredientDTO Brie = new IngredientDTO { Name = new StringTranslated("Brie", "Brie", "Brie"), IsAllergen = true };
            IngredientDTO Fromage = new IngredientDTO { Name = new StringTranslated("Cheese", "Fromage", "Kaas"), IsAllergen = true };
            IngredientDTO Noix = new IngredientDTO { Name = new StringTranslated("Nuts", "Noix", "Noten"), IsAllergen = true };
            IngredientDTO Beurre = new IngredientDTO { Name = new StringTranslated("Butter", "Beurre", "Boter"), IsAllergen = false };
            IngredientDTO Jambon = new IngredientDTO { Name = new StringTranslated("Ham", "Jambon", "Ham"), IsAllergen = false };
            IngredientDTO Roquette = new IngredientDTO { Name = new StringTranslated("Arugula", "Roquette", "Rucola"), IsAllergen = false };
            IngredientDTO Salade = new IngredientDTO { Name = new StringTranslated("Salad", "Salade", "Salade"), IsAllergen = false };
            IngredientDTO Pesto = new IngredientDTO { Name = new StringTranslated("Pesto", "Pesto", "Pesto"), IsAllergen = false };
            IngredientDTO Oeuf = new IngredientDTO { Name = new StringTranslated("Eggs", "Oeufs", "Eien"), IsAllergen = true };
            IngredientDTO Miel = new IngredientDTO { Name = new StringTranslated("Honey", "Miel", "Honing"), IsAllergen = false };

            SandwichDTO Club = new SandwichDTO { Name = new StringTranslated("Club", "Club", "Club"), Supplier = new SupplierDTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientDTO>() };
            SandwichDTO BrieNoix = new SandwichDTO { Name = new StringTranslated("Brie", "Brie", "Brie"), Supplier = new SupplierDTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientDTO>() };
            SandwichDTO PestoVerde = new SandwichDTO { Name = new StringTranslated("Pesto", "Pesto", "Pesto"), Supplier = new SupplierDTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientDTO>() };

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
        public void AfficherMenuTest()
        {
            //ARRANGE
            var fakeSandwichRepo = new Mock<ISandwichRepository>();
            fakeSandwichRepo.Setup(x => x.GetAll()).Returns(GetTestsListOfSandwich());
            fakeSandwichRepo.Setup(x => x.GetSandwichesBySupplier(It.IsAny<SupplierDTO>())).Returns(GetTestsListOfSandwich());

            var fakeIngredientRepo = new Mock<IRepository<IngredientDTO, int>>();

            var fakeSupplierRepo = new Mock<IRepository<SupplierDTO, int>>();
            fakeSupplierRepo.Setup(x => x.GetByID(It.IsAny<int>())).Returns(new SupplierDTO() { Id = 33, Name = "MockedSupplier" });

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.SandwichRepository).Returns(fakeSandwichRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new Participant(unitOfWorkMock.Object);
            var listMenu = participant.AfficherMenu(1, Language.English);

            //ASSERT
            Assert.AreEqual(3, listMenu.Count());
        }
    }
}