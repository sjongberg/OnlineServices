using SandwichSystem.Shared.DTO;

namespace SandwichSystem.DataLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ISandwichRepository SandwichRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}