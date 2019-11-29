using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared;
using System;

namespace SandwichSystem.BusinessLayer.DomainTests
{
    [TestClass]
    public class SupplierTests
    {
        [TestMethod]
        public void Supplier_ReturnsTheSupplierUsedInCTOR()
        {
            var supplierSUT = new Supplier { Id = 33, Name = "Supplier1" };

            Sandwich BrieNoix2 = new Sandwich(new StringTranslated("Brie", "Brie", "Brie"), supplierSUT);

            Assert.AreEqual(supplierSUT.Id, BrieNoix2.Supplier.Id);
            Assert.AreEqual(supplierSUT.Name, BrieNoix2.Supplier.Name);
        }

        [TestMethod]
        public void IsValid_ShouldThrowsException_WhenNullNameIsProvided()
        {
            var sut = new Supplier()
            {
                Name = null,
            };

            Assert.ThrowsException<Exception>(() => sut.IsValid());
        }

        [TestMethod]
        public void IsValid_ShouldThrowsException_WhenWhiteSpaceNameIsProvided()
        {
            var sut = new Supplier()
            {
                Name = " ",
            };

            Assert.ThrowsException<Exception>(() => sut.IsValid());
        }

        [TestMethod]
        public void IsValid_ShouldThrowsException_WhenEmptyNameIsProvided()
        {
            var sut = new Supplier()
            {
                Name = "",
            };

            Assert.ThrowsException<Exception>(() => sut.IsValid());
        }
    }
}
