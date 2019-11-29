using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.DataLayer.Repositories
{
    public class MealRepository : IMealRepository
    {
        private MealContext mealContext;

        public MealRepository(MealContext ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in MealRepository");
        }

        public void Delete(Shared.TransfertObjects.MealTO Entity)
        {
            mealContext.Sandwiches.Remove(Entity.ToEF());
        }

        public void Delete(int Id)
        {
            Delete(GetByID(Id));
        }

        public IEnumerable<Shared.TransfertObjects.MealTO> GetAll()
         => mealContext.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.MealsComposition)
            .Select(x => x.ToTranfertObject()).ToList();

        public MealTO GetByID(int Id)
            => mealContext.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.MealsComposition)
            .FirstOrDefault(x => x.Id == Id).ToTranfertObject();

        public List<Shared.TransfertObjects.MealTO> GetSandwichesByIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public List<Shared.TransfertObjects.MealTO> GetSandwichesBySupplier(SupplierTO Supplier)
            => mealContext.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.MealsComposition)
            .Where(x=>x.Supplier.Id == Supplier.Id)
            .Select(x=>x.ToTranfertObject())
            .ToList();

        public List<Shared.TransfertObjects.MealTO> GetSandwichesWithoutIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public void Insert(Shared.TransfertObjects.MealTO Entity)
        {
            mealContext.Sandwiches.Add(Entity.ToEF());
        }

        public void Update(Shared.TransfertObjects.MealTO Entity)
        {
            throw new NotImplementedException();
        }
    }
}
