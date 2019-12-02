using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.Shared.Interfaces
{
    public interface IRepository<Type, IdType>
    {
        //TODO ADD/MODIFY TEST TO RETURN TYPE BOOL
        bool Remove(Type Entity);
        bool Remove(IdType Id);
        //CHANGETO IQuerable fait posible de faire un GetAll et l'affiner avec un Where et pas retourner toute la liste.
        IEnumerable<Type> GetAll();
        Type GetByID(IdType Id);
        void Insert(Type Entity);
        void Update(Type Entity);
    }
}
