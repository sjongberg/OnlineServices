using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.TransfertObjects;
using System;
using System.Linq;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public SupplierTO GetDefaultSupplier()
        {
            if (GetSuppliers().Count(x => x.IsDefault == true) != 1)
                throw new Exception($"GetDefaultSupplier(). Default Supplier not well configured in DB");

            return iUnitOfWork.SupplierRepository
                    .GetDefaultSupplier()
                    .ToDomain().ToTransfertObject();
        }
    }
}
