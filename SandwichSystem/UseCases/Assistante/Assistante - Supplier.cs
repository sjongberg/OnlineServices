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
        public bool AjouterFournisseur(SupplierBTO Supplier)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SupplierBTO> GetFournisseurs()
        {
            try
            {
                return UnitOfWork.SupplierRepository
                    .GetAll()
                    .Select(x => x.ToDomain().ToBTO())
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
