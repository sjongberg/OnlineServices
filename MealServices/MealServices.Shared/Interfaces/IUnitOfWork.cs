namespace MealServices.Shared.Interfaces
{
    public interface IUnitOfWork
    {
        IMealRepository MealRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}