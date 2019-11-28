using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.UseCases.Assistante;
using SandwichSystem.Shared.Interfaces;
using SandwichSystem.Shared.TransfertObjects;
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
            var SupplierToAdd = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>( () => AssistanteRole.AddSupplier(SupplierToAdd));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);

        }

        [TestMethod]
        public void AddSupplier_ThrowException_WhenSupplierNameISEmptyString()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);
            var SupplierToAdd = new SupplierTO { Id = 0, Name = "" };

            //ACT
            Assert.ThrowsException<Exception>(() => AssistanteRole.AddSupplier(SupplierToAdd));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);

        }


        [TestMethod]
        public void AddSupplier_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => AssistanteRole.AddSupplier(null));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);

        }

        [TestMethod]
        public void AddSupplier_ReturnsTrue_WhenAValidSupplierIsProvidedAndAddToDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToAdd = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            var ReturnValueToAssert = AssistanteRole.AddSupplier(SupplierToAdd);

            Assert.IsTrue(ReturnValueToAssert);
        }

        [TestMethod]
        public void AddSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndAddToDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Insert(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToAdd = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            AssistanteRole.AddSupplier(SupplierToAdd);

            mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);
        }
    }
}
