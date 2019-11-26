using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.BusinessLayer.UseCases;
using SandwichSystem.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.BusinessLayer.UseCases.Tests
{
    [TestClass()]
    public class ParticipantTests
    {
        public List<Sandwich> GetTestsListOfSandwich()
        {
            //REchercher Founisseur
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

            var lst = new List<Sandwich>();;

            lst.Add(BrieNoix);
            lst.Add(Club);
            lst.Add(PestoVerde);

            return lst;
        }
        [TestMethod()]
        public void AfficherMenuTest()
        {
            var fakeSandwichRepo = new Mock<IRepository<Sandwich, int>>();
            var fakeIngredientRepo = new Mock<IRepository<Ingredient, int>>();

            fakeSandwichRepo.Setup( x=> x.GetAll()).Returns(GetTestsListOfSandwich());

            var participant = new Participant(fakeSandwichRepo.Object, fakeIngredientRepo.Object);

            var listMenu = participant.AfficherMenu("Test", Language.English);
            
            Assert.AreEqual(3, listMenu.Count());
        }
    }
}