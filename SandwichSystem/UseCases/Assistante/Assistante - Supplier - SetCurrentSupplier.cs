using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;
using System;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public bool SetCurrentSupplier(SupplierBTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));

            if (Supplier.Id == 0)
                throw new Exception("Inexisting supplier");

            if (!Supplier.IsCurrentSupplier)
                throw new Exception("Supplier not marked as current supplier.");

            try
            {
                UnitOfWork.SupplierRepository.SetCurrentSupplier(Supplier.ToDomain().ToDTO());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
