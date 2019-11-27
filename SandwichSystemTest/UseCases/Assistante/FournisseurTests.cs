using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.UseCases.Assistante;
using SandwichSystem.DataLayer.Interfaces;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class FournisseurTests
    {
        public static List<SupplierDTO> SupplierList()
        {
            return new List<SupplierDTO>
            {
                new SupplierDTO { Id=1, Name="Suplier1"},
                new SupplierDTO { Id=2, Name="Suplier3"},
                new SupplierDTO { Id=3, Name="Suplier3"}
            };
        }
        [TestMethod]
        public void GetFournisseurs_ReturnsSupplierInDB_WhenCalled()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<IRepository<SupplierDTO, int>>();
            mockSupplierRepository.Setup(x => x.GetAll()).Returns(SupplierList());

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToAdd = new SupplierBTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            var suppliers = AssistanteRole.GetFournisseurs();

            mockSupplierRepository.Verify(x => x.GetAll(), Times.Once);
            Assert.AreEqual(SupplierList().Count(), suppliers.Count());

        }
        [TestMethod]
        public void AjouterFournisseur_ThrowException_WhenSupplierIDisDiferentOfZero()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);
            var SupplierToAdd = new SupplierBTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>( () => AssistanteRole.AjouterFournisseur(SupplierToAdd));
        }

        [TestMethod]
        public void AjouterFournisseur_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var AssistanteRole = new Assistante((new Mock<IUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => AssistanteRole.AjouterFournisseur(null));
        }

        [TestMethod]
        public void AjouterFournisseur_AddSupplier_WhenAValidSupplierIsProvided()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<IRepository<SupplierDTO, int>>();
            mockSupplierRepository.Setup(x => x.Insert(It.IsAny<SupplierDTO>()));

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);
            var SupplierToAdd = new SupplierBTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            AssistanteRole.AjouterFournisseur(SupplierToAdd);

            mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierDTO>()), Times.Once);

        }
    }
}
