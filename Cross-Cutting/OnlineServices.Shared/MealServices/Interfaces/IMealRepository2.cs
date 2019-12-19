using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Shared.MealServices.Interfaces
{
    public interface IMealRepository2 : IRepository<MealTO, int>
    {
        List<MealTO> GetMealsBySupplier(SupplierTO Supplier);
        List<MealTO> GetMealsByIngredient(List<IngredientTO> Ingredients);
        List<MealTO> GetMealsWithoutIngredient(List<IngredientTO> Ingredients);
    }
}
