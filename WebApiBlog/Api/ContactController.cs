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
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository) : base("DefaultApi")
        {
            _contactRepository = contactRepository;
        }

        public override IEnumerable<Contact> Get()
        {
            return _contactRepository.FindAll();
        }

        public override Contact Get(Guid id)
        {
            var contact = _contactRepository.FindById(id);
            if (contact == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return contact;
        }

        public override HttpResponseMessage Post(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Save(contact);
                var response = Request.CreateResponse<Contact>(HttpStatusCode.Created, contact);
                response.Headers.Location = GetLocation(contact.Id);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public override HttpResponseMessage Put(Guid id, Contact contact)
        {
            _contactRepository.Update(contact, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public override HttpResponseMessage Delete(Guid id)
        {
            var contact = _contactRepository.FindById(id);
            if (contact == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            _contactRepository.Delete(contact);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}