using System;
using System.Collections.Generic;
using System.Linq;
using WebApiBlog.Models;

namespace WebApiBlog.Core.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IList<User> _users; 

        public UserRepository()
        {
            _users = new List<User>();
        }

        public User FindById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> FindAll()
        {
            return _users;
        }

        public void Save(User entity)
        {
            _users.Add(entity);
        }

        public void Update(User entity, Guid id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(User entity)
        {
            _users.Remove(entity);
        }
    }
}