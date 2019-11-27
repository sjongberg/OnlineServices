using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.DataLayer.Interfaces
{
    public interface ISupplierRepository : IRepository<SupplierDTO, int>
    {
        SupplierDTO GetCurrentSupplier();
        void SetCurrentSupplier(SupplierDTO Supplier);
    }
}
