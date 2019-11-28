using SandwichSystem.Shared.Interfaces;
using SandwichSystem.DataLayer.Repositories;
using System;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.DataLayer
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public UnitOfWork(SandwichSystemContext Context)
        {
            this.DbContext = Context;
        }

        private SandwichSystemContext DbContext;

        private ISandwichRepository sandwichRepository;
        public ISandwichRepository SandwichRepository
        {
            get
            {
                if (sandwichRepository == null)
                    sandwichRepository = new SandwichRepository(DbContext);
                return sandwichRepository;
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

            sandwichRepository = null;
            supplierRepository = null;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
