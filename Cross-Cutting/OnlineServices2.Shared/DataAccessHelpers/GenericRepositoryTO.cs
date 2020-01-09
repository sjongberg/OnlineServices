
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;

//namespace OnlineServices.Shared.DataAccessHelpers
//{
//    public abstract class GenericRepositoryTO<TEntity, TTransfertObject, TIdType> : IRepository<TTransfertObject, TIdType>
//        where TEntity : class, IEntity<TIdType>
//        where TTransfertObject : class, IEntity<TIdType>
//    {
//        private readonly DbContext dbContext;

//        public GenericRepositoryTO(DbContext dBContext)
//        {
//            this.dbContext = dBContext;
//        }

//        void IRepository<TTransfertObject, TIdType>.Create(TTransfertObject entity)
//        {
//            dbContext.Set<TEntity>().Add(ToEF(entity));
//        }

//        void IRepository<TTransfertObject, TIdType>.Delete(TTransfertObject entity)
//        {
//            dbContext.Set<TEntity>().Remove(ToEF(entity));
//        }

//        //private bool Equalite(TIdType a, TIdType b)
//        //{
//        //    return EqualityComparer<TIdType>.Default.Equals(a,b);
//        //}

//        void IRepository<TTransfertObject, TIdType>.Delete(TIdType id)
//        {
//            var entityToDelete = dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
//            if (entityToDelete != null)
//            {
//                dbContext.Set<TEntity>().Remove(entityToDelete);
//            }
//        }

//        void IRepository<TTransfertObject, TIdType>.Edit(TTransfertObject entity)
//        {
//            var dbEntity = dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(entity.Id));
//            dbEntity = UpdateFromDetached(dbEntity, ToEF(entity));
//        }

//        IEnumerable<TTransfertObject> IRepository<TTransfertObject, TIdType>.GetAll()
//        {
//            return dbContext.Set<TEntity>().Select(x => ToTransfertObject(x));
//        }

//        IEnumerable<TTransfertObject> IRepository<TTransfertObject, TIdType>.Filter(Func<TTransfertObject, bool> predicate)
//        {

//            return dbContext.Set<TEntity>()
//                .Where(x => predicate.Invoke(ToTransfertObject(x)))
//                .Select(x => ToTransfertObject(x));
//        }

//        TTransfertObject IRepository<TTransfertObject, TIdType>.GetById(TIdType id)
//        {
//            return ToTransfertObject(dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id)));
//        }

//        int IRepository<TTransfertObject, TIdType>.SaveChanges()
//        {
//            return dbContext.SaveChanges();
//        }

//        abstract public TEntity ToEF(TTransfertObject transfertObject);
//        abstract public TTransfertObject ToTransfertObject(TEntity entity);
//        abstract public TEntity UpdateFromDetached(TEntity AttachedEF, TEntity DetachedEF);
//    }
//}
