using SandwichSystem.Shared.TransfertObjects;
using System.Collections.Generic;

namespace SandwichSystem.Shared.Interfaces
{
    public interface ISandwichRepository : IRepository<SandwichTO, int>
    {
        List<SandwichTO> GetSandwichesBySupplier(SupplierTO Supplier);
        List<SandwichTO> GetSandwichesByIngredient(List<IngredientTO> Ingredients);
        List<SandwichTO> GetSandwichesWithoutIngredient(List<IngredientTO> Ingredients);
    }
}
