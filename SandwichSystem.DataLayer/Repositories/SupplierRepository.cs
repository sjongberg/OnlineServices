using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.DataLayer.Interfaces;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.DataLayer.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public SupplierRepository(SandwichSystemContext ContextInjected)
        {
            this.SandwichContext = ContextInjected ?? throw new ArgumentNullException(nameof(ContextInjected));
        }

        public SandwichSystemContext SandwichContext { get; private set; }

        public void Delete(SupplierDTO entityToDelete)
        {
            var sandwichRepository = new SandwichRepository(this.SandwichContext);

            if (sandwichRepository.GetSandwichesBySupplier(entityToDelete).Any())
                throw new Exception("Cannot delete supplier that has a sandwich in db.");
            else
            {
                SandwichContext.Suppliers.Remove(entityToDelete.ToEF());
            }
        }

        public void Delete(int id)
        {
            Delete(GetByID(id));
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            return SandwichContext.Suppliers
                .AsNoTracking()
                .Select(x => x.ToDTO())
                .ToList();
        }

        public SupplierDTO GetByID(int id)
        {
            return SandwichContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id)
                .ToDTO();
        }

        public SupplierDTO GetCurrentSupplier()
        {
            if (SandwichContext.Suppliers.Count(x=>x.IsCurrentSupplier==true) != 1)
                throw new Exception("Current Supplier not well configured in DB");
         
            return SandwichContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsCurrentSupplier == true)
                .ToDTO();
        }

        public void Insert(SupplierDTO entity)
        {
            throw new NotImplementedException();
        }

        public void SetCurrentSupplier(SupplierDTO Supplier)
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

        public void Update(SupplierDTO entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
