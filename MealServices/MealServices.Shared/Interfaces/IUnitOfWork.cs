namespace MealServices.Shared.Interfaces
{
    public interface IMSUnitOfWork
    {
        IMealRepository MealRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}