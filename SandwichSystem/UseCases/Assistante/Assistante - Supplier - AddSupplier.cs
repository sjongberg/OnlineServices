using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public bool AddSupplier(SupplierBTO Supplier)
        {
            try
            {
                if (Supplier is null)
                    throw new ArgumentNullException(nameof(Supplier));

                if (Supplier.Id != 0)
                    throw new Exception("Existing supplier");

                UnitOfWork.SupplierRepository.Insert(Supplier.ToDomain().ToDTO());

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
