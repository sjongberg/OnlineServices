using SandwichSystem.Shared.DTO;

namespace SandwichSystem.Shared.Interfaces
{
    public interface ISupplierRepository : IRepository<SupplierDTO, int>
    {
        SupplierDTO GetCurrentSupplier();
        void SetCurrentSupplier(SupplierDTO Supplier);
    }
}
