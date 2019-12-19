using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.MealServices.TransfertObjects;

namespace OnlineServices.Shared.MealServices.Interfaces
{
    public interface ISupplierRepository : IRepositoryTemp<SupplierTO, int>
    {
        SupplierTO GetDefaultSupplier();
        void SetDefaultSupplier(SupplierTO Supplier);
    }
}
