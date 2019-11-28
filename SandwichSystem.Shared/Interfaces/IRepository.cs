using System.Collections.Generic;

namespace SandwichSystem.Shared.Interfaces
{
    public interface IRepository<Type, IdType>
    {
        void Delete(Type Entity);
        void Delete(IdType Id);
        IEnumerable<Type> GetAll();
        Type GetByID(IdType Id);
        void Insert(Type Entity);
        void Update(Type Entity);
    }
}
