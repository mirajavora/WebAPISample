using System;
using System.Collections.Generic;
using System.Linq;
using WebApiBlog.Models;

namespace WebApiBlog.Core.DataAccess
{
    public class ContactRepository : IContactRepository, IRepository<Contact, Guid>
    {
        private readonly IList<Contact> _contacts;

        public ContactRepository()
        {
            _contacts = new List<Contact>();
            //create couple of contacts by default
            _contacts.Add(new Contact() { Name = "Joe Bloggs", Email = "joe@bloggs.com"});
            _contacts.Add(new Contact() { Name = "Peter Rabbit", Email = "carrot@stick.com" });
        }

        public Contact FindById(Guid id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Contact> FindAll()
        {
            return _contacts;
        }

        public void Save(Contact entity)
        {
            _contacts.Add(entity);
        }

        public void Update(Contact entity, Guid id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            contact.Email = entity.Email;
            contact.Name = entity.Name;
        }

        public void Delete(Contact entity)
        {
            _contacts.Remove(entity);
        }
    }
}