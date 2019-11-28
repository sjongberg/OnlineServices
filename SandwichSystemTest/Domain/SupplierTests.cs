using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichSystem.BusinessLayer.Domain;
using System;

namespace SandwichSystem.BusinessLayer.DomainTests
{
    [TestClass]
    public class SupplierTests
    {
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
