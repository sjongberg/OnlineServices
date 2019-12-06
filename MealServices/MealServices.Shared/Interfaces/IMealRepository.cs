using OnlineServices.Shared.MealServices.TransfertObjects;
using System.Collections.Generic;

namespace MealServices.Shared.Interfaces
{
    public interface IMealRepository : IRepository<MealTO, int>
    {
        List<MealTO> GetMealsBySupplier(SupplierTO Supplier);
        List<MealTO> GetMealsByIngredient(List<IngredientTO> Ingredients);
        List<MealTO> GetMealsWithoutIngredient(List<IngredientTO> Ingredients);
    }
}
