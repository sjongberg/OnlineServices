using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.BusinessLayer.UseCases;
using SandwichSystem.DataLayer;
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
            IngredientDTO Tomate = new IngredientDTO { Name = new StringTranslated("Tomato", "Tomate", "Tomaat"), IsAllergene = false };
            IngredientDTO Brie = new IngredientDTO { Name = new StringTranslated("Brie", "Brie", "Brie"), IsAllergene = true };
            IngredientDTO Fromage = new IngredientDTO { Name = new StringTranslated("Cheese", "Fromage", "Kaas"), IsAllergene = true };
            IngredientDTO Noix = new IngredientDTO { Name = new StringTranslated("Nuts", "Noix", "Noten"), IsAllergene = true };
            IngredientDTO Beurre = new IngredientDTO { Name = new StringTranslated("Butter", "Beurre", "Boter"), IsAllergene = false };
            IngredientDTO Jambon = new IngredientDTO { Name = new StringTranslated("Ham", "Jambon", "Ham"), IsAllergene = false };
            IngredientDTO Roquette = new IngredientDTO { Name = new StringTranslated("Arugula", "Roquette", "Rucola"), IsAllergene = false };
            IngredientDTO Salade = new IngredientDTO { Name = new StringTranslated("Salad", "Salade", "Salade"), IsAllergene = false };
            IngredientDTO Pesto = new IngredientDTO { Name = new StringTranslated("Pesto", "Pesto", "Pesto"), IsAllergene = false };
            IngredientDTO Oeuf = new IngredientDTO { Name = new StringTranslated("Eggs", "Oeufs", "Eien"), IsAllergene = true };
            IngredientDTO Miel = new IngredientDTO { Name = new StringTranslated("Honey", "Miel", "Honing"), IsAllergene = false };

            SandwichDTO Club = new SandwichDTO { Name = new StringTranslated("Club", "Club", "Club"), Ingredients = new List<IngredientDTO>() };
            SandwichDTO BrieNoix = new SandwichDTO { Name = new StringTranslated("Brie", "Brie", "Brie"), Ingredients = new List<IngredientDTO>() };
            SandwichDTO PestoVerde = new SandwichDTO { Name = new StringTranslated("Pesto", "Pesto", "Pesto"), Ingredients = new List<IngredientDTO>() };

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
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var fakeSandwichRepo = new Mock<ISandwichRepository>();
            var fakeIngredientRepo = new Mock<IRepository<IngredientDTO, int>>();

            var fakeSupplierRepo = new Mock<IRepository<SupplierDTO, int>>();

            fakeSandwichRepo.Setup(x => x.GetAll()).Returns(GetTestsListOfSandwich());
            unitOfWorkMock.Setup(x => x.RepositorySandwich).Returns(fakeSandwichRepo.Object);

            var participant = new Participant(unitOfWorkMock.Object);

            var listMenu = participant.AfficherMenu(1, Language.English);

            Assert.AreEqual(3, listMenu.Count());
        }
    }
}