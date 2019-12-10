using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnlineServices.Shared.DataAccessHelpers
{
    public interface IRepository<TTransfertObject, TIdType>
        where TTransfertObject : class, IEntity<TIdType>
    {
        void Create(TTransfertObject entity);
        void Delete(TTransfertObject entity);
        void Delete(TIdType id);
        void Edit(TTransfertObject entity);

        TTransfertObject GetById(TIdType id);
        IEnumerable<TTransfertObject> GetAll();
        IEnumerable<TTransfertObject> Filter(Func<TTransfertObject, bool> predicate);

        int SaveChanges();
    }
}
