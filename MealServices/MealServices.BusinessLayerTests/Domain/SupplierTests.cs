using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealServices.BusinessLayer.Domain;
using MealServices.Shared;
using System;
using OnlineServices.Shared;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using OnlineServices.Shared.Exceptions;

namespace MealServices.BusinessLayer.DomainTests
{
    [TestClass]
    public class SupplierTests
    {
        [TestMethod()]
        public void Supplier_ReturnsTheSupplierUsedInCTOR()
        {
            var supplierSUT = new Supplier { Id = 33, Name = "Supplier1" };

            Meal BrieNoix2 = new Meal(new MultiLanguageString("Brie", "Brie", "Brie"), supplierSUT);

            Assert.AreEqual(supplierSUT.Id, BrieNoix2.Supplier.Id);
            Assert.AreEqual(supplierSUT.Name, BrieNoix2.Supplier.Name);
        }

        [TestMethod()]
        public void IsValid_ThrowsIsNullOrWhiteSpaceException_WhenNullNameIsProvided()
        {
            var sut = new Supplier()
            {
                Name = null,
            };

            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => sut.IsValid());
        }

        [TestMethod()]
        public void IsValid_ThrowsIsNullOrWhiteSpaceException_WhenWhiteSpaceNameIsProvided()
        {
            var sut = new Supplier()
            {
                Name = " ",
            };

            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => sut.IsValid());
        }

        [TestMethod()]
        public void IsValid_ThrowsIsNullOrWhiteSpaceException_WhenEmptyNameIsProvided()
        {
            var sut = new Supplier()
            {
                Name = "",
            };

            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => sut.IsValid());
        }
    }
}
