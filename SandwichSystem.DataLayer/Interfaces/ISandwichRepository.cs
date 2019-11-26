using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.DataLayer.Interfaces
{
    public interface ISandwichRepository : IRepository<SandwichDTO, int>
    {
        List<SandwichDTO> GetSandwichesBySupplier(SupplierDTO Supplier);
        List<SandwichDTO> GetSandwichesByIngredient(List<IngredientDTO> Ingredients);
        List<SandwichDTO> GetSandwichesWithoutIngredient(List<IngredientDTO> Ingredients);
    }
}
