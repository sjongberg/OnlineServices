using MealServices.Shared.Interfaces;
using MealServices.DataLayer.Repositories;
using System;
using OnlineServices.Shared.MealServices.TransfertObjects;

namespace MealServices.DataLayer
{
    public class MSUnitOfWork : IDisposable, IMSUnitOfWork
    {
        public MSUnitOfWork(MealContext Context)
        {
            this.DbContext = Context;
        }

        private MealContext DbContext;

        private IMealRepository mealRepository;
        public IMealRepository MealRepository
        {
            get
            {
                if (mealRepository == null)
                    mealRepository = new MealRepository(DbContext);
                return mealRepository;
            }
        }

        private IRepository<IngredientTO, int> ingredientRepository;
        public IRepository<IngredientTO, int> IngredientRepository
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(DbContext);
                return ingredientRepository;
            }
        }

        private ISupplierRepository supplierRepository;
        public ISupplierRepository SupplierRepository
        {
            get
            {
                if (supplierRepository == null)
                    supplierRepository = new SupplierRepository(DbContext);
                return supplierRepository;
            }
        }

        public void Dispose()
        {
            DbContext.Dispose();
            DbContext = null;

            mealRepository = null;
            supplierRepository = null;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
