using System;
using System.Collections.Generic;

namespace SandwichSystem.DataLayer
{
    public interface IRepository<T, U>
    {
        void Delete(T entityToDelete);
        void Delete(U id);
        IEnumerable<T> Get();
        T GetByID(U id);
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}
