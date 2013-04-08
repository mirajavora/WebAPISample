using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiBlog.Core.Api;
using WebApiBlog.Core.DataAccess;
using WebApiBlog.Models;

namespace WebApiBlog.Api
{
    public class SecureContactController : RestApiController<Contact, Guid>
    {
        public SecureContactController(IContactRepository contactRepository)
            : base("DefaultApi", contactRepository)
        {
            
        }

        [Authorize]
        public override IEnumerable<Contact> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "Administrator")]
        public override System.Net.Http.HttpResponseMessage Delete(Guid id)
        {
            return base.Delete(id);
        }

        [Authorize(Roles = "Administrator")]
        public override System.Net.Http.HttpResponseMessage Post(Contact entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "Administrator")]
        public override System.Net.Http.HttpResponseMessage Put(Guid id, Contact entity)
        {
            return base.Put(id, entity);
        }
    }
}