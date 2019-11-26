using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.DataLayer
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public UnitOfWork(SandwichContext Context)
        {
            this.DbContext = Context;
        }

        private SandwichContext DbContext;

        private ISandwichRepository sandwichRepository;
        public ISandwichRepository RepositorySandwich
        {
            get
            {
                if (sandwichRepository == null)
                    sandwichRepository = new SandwichRepository(DbContext);
                return sandwichRepository;
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
        }
        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
