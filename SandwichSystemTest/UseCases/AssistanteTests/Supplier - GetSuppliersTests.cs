using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.BusinessLayer.UseCases.Assistante;
using SandwichSystem.Shared.Interfaces;
using SandwichSystem.Shared.TransfertObjects;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_GetSuppliersTests
    {
        public static List<SupplierTO> SupplierList()
        {
            return new List<SupplierTO>
            {
                new SupplierTO { Id=1, Name="Suplier1", IsDefault=false},
                new SupplierTO { Id=2, Name="Suplier3", IsDefault=true},
                new SupplierTO { Id=3, Name="Suplier3", IsDefault=false}
            };
        }

        [TestMethod]
        public void GetSuppliers_ReturnsSupplierInDB_WhenCalled()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.GetAll()).Returns(SupplierList());

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);

            //ACT
            var suppliers = AssistanteRole.GetSuppliers();

            //ASSERT
            Assert.AreEqual(SupplierList().Count(), suppliers.Count());
        }

        [TestMethod]
        public void GetSuppliers_SupplierRepositoryIsCalledOnce_WhenCalled()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.GetAll()).Returns(SupplierList());

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var AssistanteRole = new Assistante(mockUoW.Object);

            //ACT
            AssistanteRole.GetSuppliers();

            //ASSERT
            mockSupplierRepository.Verify(x => x.GetAll(), Times.Once);
        }

        //[TestMethod]
        //public void GetSuppliers_ThrowsException_WhenNotConnectedToDB()
        //{
        //    //ARRANGE
        //    var mockSupplierRepository = new Mock<IRepository<SupplierTO, int>>();
        //    mockSupplierRepository.Setup(x => x.GetAll()).Returns(() => throw new Exception("Not connected to db."));

        //    var mockUoW = new Mock<IUnitOfWork>();
        //    mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

        //    var AssistanteRole = new Assistante(mockUoW.Object);

        //    //ACT & ASSERT
        //    Assert.ThrowsException<Exception>(()=>AssistanteRole.GetSuppliers());
        //}
    }
}
