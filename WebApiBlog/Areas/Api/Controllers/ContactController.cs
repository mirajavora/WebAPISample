using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApiBlog.Core.DataAccess;
using WebApiBlog.Models;

namespace WebApiBlog.Areas.Api.Controllers
{
    public class ContactController : ApiController 
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IEnumerable<Contact> Get()
        {
            return _contactRepository.FindAll();
        }


    }
}