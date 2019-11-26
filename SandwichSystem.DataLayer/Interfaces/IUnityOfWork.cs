using SandwichSystem.Shared.DTO;

namespace SandwichSystem.DataLayer.Interfaces
{
    public interface IUnitOfWork
    {
        ISandwichRepository SandwichRepository { get; }
        IRepository<SupplierDTO, int> SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}