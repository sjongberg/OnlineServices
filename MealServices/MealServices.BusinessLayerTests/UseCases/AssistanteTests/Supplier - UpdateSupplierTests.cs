using MealServices.BusinessLayer.UseCases.Assistante;
using MealServices.Shared.Interfaces;
using OnlineServices.Shared.MealServices.TransfertObjects;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MealServices.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_UpdateSupplierTests
    {
        [TestMethod]
        public void UpdateSupplier_ThrowException_WhenSupplierIDisDifferentOfZero()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IMSUnitOfWork>()).Object);
            var SupplierToUpdate = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>(() => AssistanteRole.UpdateSupplier(SupplierToUpdate));
        }

        [TestMethod]
        public void UpdateSupplier_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IMSUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => AssistanteRole.UpdateSupplier(null));
        }

        [TestMethod]
        public void UpdateSupplier_ReturnsTrue_WhenAValidSupplierIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Update(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            var ReturnValueToAssert = AssistanteRole.UpdateSupplier(SupplierToUpdate);

            Assert.IsTrue(ReturnValueToAssert);
        }

        [TestMethod]
        public void UpdateSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Update(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            AssistanteRole.UpdateSupplier(SupplierToUpdate);

            mockSupplierRepository.Verify(x => x.Update(It.IsAny<SupplierTO>()), Times.Once);
        }
    }
}
