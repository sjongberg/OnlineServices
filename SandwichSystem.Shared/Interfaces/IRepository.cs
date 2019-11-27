using System.Collections.Generic;

namespace SandwichSystem.Shared.Interfaces
{
    public interface IRepository<T, U>
    {
        void Delete(T entityToDelete);
        void Delete(U id);
        IEnumerable<T> GetAll();
        T GetByID(U id);
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}
