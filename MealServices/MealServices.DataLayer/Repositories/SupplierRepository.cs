using MealServices.DataLayer.Extensions;
using MealServices.Shared.Interfaces;

using Microsoft.EntityFrameworkCore;

using OnlineServices.Shared.MealServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly MealContext mealContext;

        public SupplierRepository(MealContext ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in SupplierRepository");
        }


        public bool Remove(SupplierTO Entity)
        {
            var mealRepository = new MealRepository(this.mealContext);

            if (mealRepository.GetMealsBySupplier(Entity).Any())
                throw new Exception("Cannot delete supplier that has a meal in db.");
            else
            {
                mealContext.Suppliers.Remove(Entity.ToEF());
                return true;
            }
        }

        public bool Remove(int Id)
            => Remove(GetByID(Id));

        public IEnumerable<SupplierTO> GetAll()
        {
            return mealContext.Suppliers
                .AsNoTracking()
                .Include(x => x.Meals)
                    .ThenInclude(Meal => Meal.MealsComposition)
                        .ThenInclude(MealsComposition => MealsComposition.Ingredient)
                .Select(x => x.ToTranfertObject())
                .ToList();
        }

        public SupplierTO GetByID(int Id)
        {
            return mealContext.Suppliers
                .AsNoTracking()
                .Include(x => x.Meals)
                    .ThenInclude(Meal => Meal.MealsComposition)
                        .ThenInclude(MealsComposition => MealsComposition.Ingredient)
                .FirstOrDefault(x => x.Id == Id)
                .ToTranfertObject();
        }

        private bool isDefaultSupplierUniquenessWithThrow(string MethodName)
        {
            if (mealContext.Suppliers.Count(x => x.IsDefault == true) != 1)
                throw new Exception($"{MethodName}. Default Supplier not well configured in DB");
            else
                return true;
        }

        public SupplierTO GetDefaultSupplier()
        {
            isDefaultSupplierUniquenessWithThrow("GetCurrentSupplier()");

            return mealContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsDefault == true)
                .ToTranfertObject();
        }

        public SupplierTO Insert(SupplierTO Entity)
            => mealContext
                .Add(Entity.ToEF())
                .Entity
                .ToTranfertObject();

        public void SetDefaultSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));
            if (Supplier.Id is default(int))
                throw new Exception("Invalid SupplierID");

            var SupplierToMakeCurrent = GetByID(Supplier.Id);
            SupplierToMakeCurrent.IsDefault = true;

            mealContext.Suppliers
                .UpdateRange(
                    GetAll()
                    .Select(x => { x.IsDefault = false; return x.ToEF(); })
                    .ToArray()
                );

            Update(SupplierToMakeCurrent);

            isDefaultSupplierUniquenessWithThrow("SetCurrentSupplier(SupplierTO) after update");
        }

        public SupplierTO Update(SupplierTO Entity)
            => mealContext.Suppliers
                .Find(Entity.Id)
                .UpdateFromDetached(Entity.ToEF())
                .ToTranfertObject();
    }
}
