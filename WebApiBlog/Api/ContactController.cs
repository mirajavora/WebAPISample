using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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