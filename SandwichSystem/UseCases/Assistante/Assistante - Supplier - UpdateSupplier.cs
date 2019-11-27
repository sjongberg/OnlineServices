using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;
using System;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public bool UpdateSupplier(SupplierBTO Supplier)
        {
            try
            {
                if (Supplier is null)
                    throw new ArgumentNullException(nameof(Supplier));

                if (Supplier.Id == 0)
                    throw new Exception("Inexisting supplier");

                UnitOfWork.SupplierRepository.Update(Supplier.ToDomain().ToDTO());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
