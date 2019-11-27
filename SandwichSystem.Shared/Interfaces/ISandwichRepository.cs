using SandwichSystem.Shared.DTO;
using System.Collections.Generic;

namespace SandwichSystem.Shared.Interfaces
{
    public interface ISandwichRepository : IRepository<SandwichDTO, int>
    {
        List<SandwichDTO> GetSandwichesBySupplier(SupplierDTO Supplier);
        List<SandwichDTO> GetSandwichesByIngredient(List<IngredientDTO> Ingredients);
        List<SandwichDTO> GetSandwichesWithoutIngredient(List<IngredientDTO> Ingredients);
    }
}
