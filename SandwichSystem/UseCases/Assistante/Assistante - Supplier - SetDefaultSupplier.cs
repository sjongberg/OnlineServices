using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.TransfertObjects;
using System;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public bool SetDefaultSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));

            if (Supplier.Id == 0)
                throw new Exception("Inexisting supplier");

            if (!Supplier.IsDefault)
                throw new Exception("Supplier not marked as current supplier.");

            try
            {
                UnitOfWork.SupplierRepository.SetDefaultSupplier(Supplier.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
