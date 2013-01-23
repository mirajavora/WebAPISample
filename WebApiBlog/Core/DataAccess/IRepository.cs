using System;
using System.Collections.Generic;

namespace WebApiBlog.Core.DataAccess
{
    public interface IRepository<T>
    {
        T FindById(Guid id);
        IEnumerable<T> FindAll();
        void Save(T entity);
        void Delete(T entity); 
    }
}