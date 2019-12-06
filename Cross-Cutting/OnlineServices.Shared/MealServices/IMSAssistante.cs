using OnlineServices.Shared.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Shared.MealServices
{
    public interface IMSAssistanteSupplierManagement
    {
        //IMSUnitOfWork iUnitOfWork { get; }

        bool AddSupplier(SupplierTO Supplier);
        SupplierTO GetDefaultSupplier();
        List<SupplierTO> GetSuppliers();
        bool RemoveSupplier(SupplierTO Supplier);
        bool SetDefaultSupplier(SupplierTO Supplier);
        bool UpdateSupplier(SupplierTO Supplier);
    }
}