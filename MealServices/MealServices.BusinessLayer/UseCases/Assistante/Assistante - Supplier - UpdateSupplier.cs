using MealServices.BusinessLayer.Extentions;
using MealServices.Shared.TransfertObjects;
using System;

namespace MealServices.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public bool UpdateSupplier(SupplierTO Supplier)
        {
            try
            {
                if (Supplier is null)
                    throw new ArgumentNullException(nameof(Supplier));

                if (Supplier.Id == 0)
                    throw new Exception("Inexisting supplier");

                iUnitOfWork.SupplierRepository.Update(Supplier.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
