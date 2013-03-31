using System;
using WebApiBlog.Core.DataAccess;

namespace WebApiBlog.Models
{
    public class User : IModelId 
    {
        public User(string username, string passwordHash, string salt)
        {
            Id = Guid.NewGuid();
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string Salt { get; private set; }
    }
}