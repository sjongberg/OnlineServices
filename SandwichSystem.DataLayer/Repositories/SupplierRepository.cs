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
        public SupplierRepository(MealContext ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in SupplierRepository");
        }

        public MealContext mealContext { get; private set; }

        public void Delete(SupplierTO Entity)
        {
            var sandwichRepository = new MealRepository(this.mealContext);

            if (sandwichRepository.GetSandwichesBySupplier(Entity).Any())
                throw new Exception("Cannot delete supplier that has a sandwich in db.");
            else
            {
                mealContext.Suppliers.Remove(Entity.ToEF());
            }
        }

        public void Delete(int Id)
        {
            Delete(GetByID(Id));
        }

        public IEnumerable<SupplierTO> GetAll()
        {
            return mealContext.Suppliers
                .AsNoTracking()
                .Select(x => x.ToTranfertObject())
                .ToList();
        }

        public SupplierTO GetByID(int Id)
        {
            return mealContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == Id)
                .ToTranfertObject();
        }

        public SupplierTO GetCurrentSupplier()
        {
            if (mealContext.Suppliers.Count(x=>x.IsCurrentSupplier==true) != 1)
                throw new Exception("Current Supplier not well configured in DB");
         
            return mealContext.Suppliers
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

            mealContext.Suppliers
                .UpdateRange(
                    GetAll()
                    .Select(x => { x.IsCurrentSupplier = false; return x.ToEF(); })
                    .ToArray()
                );

            Update(SupplierToMakeCurrent);

            if (mealContext.Suppliers.Count(x => x.IsCurrentSupplier == true) != 1)
                throw new Exception("Current Supplier not well configured in DB");
        }

        public void Update(SupplierTO Entity)
        {
            throw new NotImplementedException();
        }
    }
}
