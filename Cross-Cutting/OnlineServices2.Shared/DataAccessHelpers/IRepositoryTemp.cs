﻿using System.Collections.Generic;

namespace OnlineServices.Shared.DataAccessHelpers
{
    public interface IRepositoryTemp<TType, TIdType>
        where TType : class
    {
        //TODO ADD/MODIFY TEST TO RETURN TYPE BOOL FOR REMOVE
        bool Remove(TType entity);
        bool Remove(TIdType Id);
        //bool Remove(params TIdType[] entities);
        //bool Remove(IEnumerable<TIdType> entities);

        //CHANGETO IQuerable fait posible de faire un GetAll et l'affiner avec un Where et pas retourner toute la liste.
        IEnumerable<TType> GetAll();
        TType GetByID(TIdType Id);
        TType Add(TType Entity);
        TType Update(TType Entity);
    }
}
