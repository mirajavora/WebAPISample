using System;
using WebApiBlog.Models;

namespace WebApiBlog.Core.DataAccess
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        User FindByUsername(string username);
    }
}