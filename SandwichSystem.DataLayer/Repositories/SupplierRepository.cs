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
    public class SupplierRepository : IRepository<SupplierDTO, int>
    {
        public SupplierRepository(SandwichSystemContext SandwichContext)
        {
            this.SandwichContext = SandwichContext ?? throw new ArgumentNullException(nameof(SandwichContext));
        }

        public SandwichSystemContext SandwichContext { get; private set; }

        public void Delete(SupplierDTO entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
