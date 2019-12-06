using System.Collections.Generic;

namespace MealServices.Shared.Interfaces
{
    public interface IRepository<Type, IdType>
    {
        //TODO ADD/MODIFY TEST TO RETURN TYPE BOOL
        bool Remove(Type Entity);
        bool Remove(IdType Id);
        //CHANGETO IQuerable fait posible de faire un GetAll et l'affiner avec un Where et pas retourner toute la liste.
        IEnumerable<Type> GetAll();
        Type GetByID(IdType Id);
        Type Insert(Type Entity);
        Type Update(Type Entity);
    }
}
