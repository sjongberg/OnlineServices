using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandwichSystem.DataLayer;

namespace SandwichSystem.DataLayerTests
{
    [TestClass]
    public class SandwichRepositoryTests
    {
        [TestMethod]
        public void SandwichRepository_ShouldInsertInDb_WhenValidSandwichIsProvided()
        {
            var repo = new SandwichRepository(null);

            repo.Insert(new Shared.DTO.SandwichDTO { Name = new Shared.StringTranslated("hello2", "bonjour", "hlo"), Supplier = new Shared.DTO.SupplierDTO { Name = "Fournisseur1" } });
        }
    }
}
