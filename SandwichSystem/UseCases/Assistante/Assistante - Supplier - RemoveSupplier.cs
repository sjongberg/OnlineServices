using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;
using System;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public bool RemoveSupplier(SupplierBTO Supplier)
        {
            try
            {
                if (Supplier is null)
                    throw new ArgumentNullException(nameof(Supplier));

                if (Supplier.Id == 0)
                    throw new Exception("Supplier not in DB.");

                UnitOfWork.SupplierRepository.Delete(Supplier.ToDomain().ToDTO());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
