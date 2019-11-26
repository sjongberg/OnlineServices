using SandwichSystem.Shared.DTO;

namespace SandwichSystem.DataLayer
{
    public interface IUnitOfWork
    {
        ISandwichRepository RepositorySandwich { get; }
        IRepository<SupplierDTO, int> SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}