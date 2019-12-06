using MealServices.DataLayer.Repositories;
using MealServices.Shared.Interfaces;

using OnlineServices.Shared.MealServices.TransfertObjects;

using System;

namespace MealServices.DataLayer
{
    public class MSUnitOfWork : IDisposable, IMSUnitOfWork
    {
        private readonly MealContext mealContext;

        public MSUnitOfWork(MealContext ContextIoC)
        {
            this.mealContext = ContextIoC ?? throw new ArgumentNullException(nameof(ContextIoC));
        }

        private IMealRepository mealRepository;
        public IMealRepository MealRepository
            => mealRepository ??= new MealRepository(mealContext);

        private IRepository<IngredientTO, int> ingredientRepository;
        public IRepository<IngredientTO, int> IngredientRepository
            => ingredientRepository ??= new IngredientRepository(mealContext);

        private ISupplierRepository supplierRepository;
        public ISupplierRepository SupplierRepository
            => supplierRepository ??= new SupplierRepository(mealContext);

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    mealContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            mealContext.SaveChanges();
        }
    }
}
