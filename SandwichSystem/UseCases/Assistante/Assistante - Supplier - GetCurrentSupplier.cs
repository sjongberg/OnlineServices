using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public SupplierTO GetCurrentSupplier()
            => UnitOfWork.SupplierRepository
                    .GetCurrentSupplier()
                    .ToDomain().ToTransfertObject();
    }
}
