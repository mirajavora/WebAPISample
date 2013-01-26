using System;
using System.Collections.Generic;

namespace WebApiBlog.Core.DataAccess
{
    public interface IRepository<T, TId>
    {
        T FindById(TId id);
        IEnumerable<T> FindAll();
        void Save(T entity);
        void Update(T entity, TId id);
        void Delete(T entity);
        
    }
}