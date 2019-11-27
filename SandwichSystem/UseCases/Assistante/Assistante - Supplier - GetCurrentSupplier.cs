using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public SupplierBTO GetCurrentSupplier()
            => UnitOfWork.SupplierRepository
                    .GetCurrentSupplier()
                    .ToDomain().ToBTO();
    }
}
