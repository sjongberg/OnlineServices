namespace SandwichSystem.Shared.Interfaces
{
    public interface IUnitOfWork
    {
        ISandwichRepository SandwichRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}