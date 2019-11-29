using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.Shared.Interfaces
{
    public interface ISupplierRepository : IRepository<SupplierTO, int>
    {
        SupplierTO GetDefaultSupplier();
        void SetDefaultSupplier(SupplierTO Supplier);
    }
}
