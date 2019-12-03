using MealServices.Shared.TransfertObjects;

namespace MealServices.Shared.Interfaces
{
    public interface ISupplierRepository : IRepository<SupplierTO, int>
    {
        SupplierTO GetDefaultSupplier();
        void SetDefaultSupplier(SupplierTO Supplier);
    }
}
