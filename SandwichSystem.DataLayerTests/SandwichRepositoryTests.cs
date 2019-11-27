using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SandwichSystem.Shared.Interfaces;

namespace SandwichSystem.DataLayerTests
{
    [TestClass]
    public class SandwichRepositoryTests
    {
        [TestMethod]
        public void SandwichRepository_ShouldInsertInDb_WhenValidSandwichIsProvided()
        {
            var repoMock = new Mock<ISandwichRepository>();

            //repoMock.Setup(x=>x.Insert).

            //repo.Insert(new Shared.DTO.SandwichDTO { Name = new Shared.StringTranslated("hello2", "bonjour", "hlo"), Supplier = new Shared.DTO.SupplierDTO { Name = "Fournisseur1" } });
        }
    }
}
