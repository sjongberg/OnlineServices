using SandwichSystem.DataLayer.Interfaces;
using SandwichSystem.DataLayer.Repositories;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

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

        private IRepository<IngredientDTO, int> ingredientRepository;
        public IRepository<IngredientDTO, int> IngredientRepository
        {
            get
            {
                if (ingredientRepository == null)
                    ingredientRepository = new IngredientRepository(DbContext);
                return ingredientRepository;
            }
        }

        private IRepository<SupplierDTO, int> supplierRepository;
        public IRepository<SupplierDTO, int> SupplierRepository
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
