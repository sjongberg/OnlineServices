using SandwichSystem.DataLayer.Entities;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.DataLayer.Extentions
{
    public static class SupplierExtensions
    {
        public static SupplierTO ToTranfertObject(this SupplierEF Supplier)
        {
            return new SupplierTO
            {
                 Id = Supplier.Id,
                 Name = Supplier.Name,
                 IsDefault = Supplier.IsDefault
            };
        }

        public static SupplierEF ToEF(this SupplierTO Supplier)
        {
            return new SupplierEF
            {
                Id = Supplier.Id,
                Name = Supplier.Name,
                IsDefault = Supplier.IsDefault
            };
        }
    }
}
