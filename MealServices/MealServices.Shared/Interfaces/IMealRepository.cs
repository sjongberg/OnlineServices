using MealServices.Shared.TransfertObjects;
using System.Collections.Generic;

namespace MealServices.Shared.Interfaces
{
    public interface IMealRepository : IRepository<MealTO, int>
    {
        List<MealTO> GetSandwichesBySupplier(SupplierTO Supplier);
        List<MealTO> GetSandwichesByIngredient(List<IngredientTO> Ingredients);
        List<MealTO> GetSandwichesWithoutIngredient(List<IngredientTO> Ingredients);
    }
}
