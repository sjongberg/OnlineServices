using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.DataLayer.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public SupplierRepository(SandwichSystemContext ContextInjected)
        {
            this.SandwichContext = ContextInjected ?? throw new ArgumentNullException(nameof(ContextInjected));
        }

        public SandwichSystemContext SandwichContext { get; private set; }

        public void Delete(SupplierTO Entity)
        {
            var sandwichRepository = new SandwichRepository(this.SandwichContext);

            if (sandwichRepository.GetSandwichesBySupplier(Entity).Any())
                throw new Exception("Cannot delete supplier that has a sandwich in db.");
            else
            {
                SandwichContext.Suppliers.Remove(Entity.ToEF());
            }
        }

        public void Delete(int Id)
        {
            Delete(GetByID(Id));
        }

        public IEnumerable<SupplierTO> GetAll()
        {
            return SandwichContext.Suppliers
                .AsNoTracking()
                .Select(x => x.ToTranfertObject())
                .ToList();
        }

        public SupplierTO GetByID(int Id)
        {
            return SandwichContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == Id)
                .ToTranfertObject();
        }

        public SupplierTO GetCurrentSupplier()
        {
            if (SandwichContext.Suppliers.Count(x=>x.IsCurrentSupplier==true) != 1)
                throw new Exception("Current Supplier not well configured in DB");
         
            return SandwichContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsCurrentSupplier == true)
                .ToTranfertObject();
        }

        public void Insert(SupplierTO entity)
        {
            throw new NotImplementedException();
        }

        public void SetCurrentSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));
            if (Supplier.Id is default(int))
                throw new Exception("Invalid SupplierID");

            var SupplierToMakeCurrent = GetByID(Supplier.Id);
            SupplierToMakeCurrent.IsCurrentSupplier = true;

            SandwichContext.Suppliers
                .UpdateRange(
                    GetAll()
                    .Select(x => { x.IsCurrentSupplier = false; return x.ToEF(); })
                    .ToArray()
                );

            Update(SupplierToMakeCurrent);

            if (SandwichContext.Suppliers.Count(x => x.IsCurrentSupplier == true) != 1)
                throw new Exception("Current Supplier not well configured in DB");
        }

        public void Update(SupplierTO Entity)
        {
            throw new NotImplementedException();
        }
    }
}
