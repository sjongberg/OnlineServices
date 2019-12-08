using System.Collections.Generic;

namespace OnlineServices.Shared.DataAccessHelpers
{
    public interface IRepository<TType, TIdType>
    {
        //TODO ADD/MODIFY TEST TO RETURN TYPE BOOL
        bool Remove(TType Entity);
        bool Remove(TIdType Id);
        //CHANGETO IQuerable fait posible de faire un GetAll et l'affiner avec un Where et pas retourner toute la liste.
        IEnumerable<TType> GetAll();
        TType GetByID(TIdType Id);
        TType Insert(TType Entity);
        TType Update(TType Entity);
    }
}
