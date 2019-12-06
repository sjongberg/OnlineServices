using MealServices.BusinessLayer.Extensions;
using OnlineServices.Shared.MealServices.TransfertObjects;
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
