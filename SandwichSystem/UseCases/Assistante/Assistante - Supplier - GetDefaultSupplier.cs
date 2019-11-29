using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public SupplierTO GetDefaultSupplier()
            => UnitOfWork.SupplierRepository
                    .GetDefaultSupplier()
                    .ToDomain().ToTransfertObject();
    }
}
