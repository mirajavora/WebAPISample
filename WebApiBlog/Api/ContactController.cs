using System;
using WebApiBlog.Core.Api;
using WebApiBlog.Core.DataAccess;
using WebApiBlog.Models;

namespace WebApiBlog.Api
{
    public class ContactController : RestApiController<Contact, Guid>
    {
        public ContactController(IContactRepository contactRepository) : base("DefaultApi", contactRepository)
        {
            
        }

        
    }
}