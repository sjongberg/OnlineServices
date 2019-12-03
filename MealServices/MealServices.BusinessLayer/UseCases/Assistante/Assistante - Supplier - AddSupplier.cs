using MealServices.BusinessLayer.Extentions;
using MealServices.Shared.TransfertObjects;
using System;

namespace MealServices.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public bool AddSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));

            if (Supplier.Id != 0)
                throw new Exception("Existing supplier");

            try
            {

                iUnitOfWork.SupplierRepository.Insert(Supplier.ToDomain().ToTransfertObject());

                if (Supplier.IsDefault)
                    iUnitOfWork.SupplierRepository.SetDefaultSupplier(Supplier.ToDomain().ToTransfertObject());

                return true;
            }

            //TODO Code to test Unique Constraint on Name...
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
