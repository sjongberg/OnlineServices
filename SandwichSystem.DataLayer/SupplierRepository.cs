using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.DataLayer
{
    public class SupplierRepository : IRepository<SupplierDTO, int>, IDisposable
    {
        public SupplierRepository(SandwichContext SandwichContext)
        {
            this.SandwichContext = SandwichContext ?? new SandwichContext();
        }

        public SandwichContext SandwichContext { get; private set; }

        public void Delete(SupplierDTO entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            SandwichContext.Dispose();
            SandwichContext = null;
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
            throw new NotImplementedException();
        }

        public void Insert(SupplierDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(SupplierDTO entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
