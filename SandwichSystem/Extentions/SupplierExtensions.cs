using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.Shared;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.DTO;
using System;
using System.Linq;

namespace SandwichSystem.BusinessLayer.Extentions
{
    public static class SupplierExtensions
    {
        public static SupplierBTO ToBTO(this Supplier Supplier)
        {
            return new SupplierBTO
            {
                Id = Supplier.SupplierId,
                Name = Supplier.Name
            };
        }
        public static Supplier ToDomain(this SupplierBTO SupplierBTO)
        {
            return new Supplier()
            {
                SupplierId = SupplierBTO.Id,
                Name = SupplierBTO.Name
            };
        }
        public static SupplierDTO ToDTO(this Supplier Supplier)
        {
            return new SupplierDTO
            {
                Id = Supplier.SupplierId,
                Name = Supplier.Name
            };
        }
    }
}
