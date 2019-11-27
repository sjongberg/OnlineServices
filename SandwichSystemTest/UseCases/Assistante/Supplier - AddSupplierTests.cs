using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.UseCases.Assistante;
using SandwichSystem.Shared.Interfaces;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
using System;

namespace SandwichSystem.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_AddSupplierTests
    {
        [TestMethod]
        public void AddSupplier_ThrowException_WhenSupplierIDisDiferentOfZero()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);
            var SupplierToAdd = new SupplierBTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>( () => AssistanteRole.AddSupplier(SupplierToAdd));
        }

        [TestMethod]
        public void AddSupplier_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => AssistanteRole.AddSupplier(null));
        }

        [TestMethod]
        public void AddSupplier_ReturnsTrue_WhenAValidSupplierIsProvidedAndAddToDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Insert(It.IsAny<SupplierDTO>()));

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToAdd = new SupplierBTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            var ReturnValueToAssert = AssistanteRole.AddSupplier(SupplierToAdd);

            Assert.IsTrue(ReturnValueToAssert);
        }

        [TestMethod]
        public void AddSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndAddToDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Insert(It.IsAny<SupplierDTO>()));

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToAdd = new SupplierBTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            AssistanteRole.AddSupplier(SupplierToAdd);

            mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierDTO>()), Times.Once);
        }
    }
}
