
using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared.DTO;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class SupplierExtensions
    {
        public static SupplierDTO ToDTO(this SupplierEF Supplier)
        {
            return new SupplierDTO
            {
                 Id = Supplier.Id,
                 Name = Supplier.Name,
                 IsCurrentSupplier = Supplier.IsCurrentSupplier
            };
        }

        public static SupplierEF ToEF(this SupplierDTO Supplier)
        {
            return new SupplierEF
            {
                Id = Supplier.Id,
                Name = Supplier.Name,
                IsCurrentSupplier = Supplier.IsCurrentSupplier
            };
        }
    }
}
