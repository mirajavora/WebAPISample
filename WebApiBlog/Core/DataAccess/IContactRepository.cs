using System;
using System.Collections.Generic;
using WebApiBlog.Models;

namespace WebApiBlog.Core.DataAccess
{
    public interface IContactRepository
    {
        Contact FindById(Guid id);
        IEnumerable<Contact> FindAll();
        void Save(Contact entity);
        void Delete(Contact entity);
        void Update(Contact entity, Guid id);
    }
}