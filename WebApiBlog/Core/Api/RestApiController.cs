using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiBlog.Core.DataAccess;

namespace WebApiBlog.Core.Api
{
    public abstract class RestApiController<T, TId> : ApiController, IRestApiController where T : IModelId
    {
        private readonly IRepository<T, TId> _repository;
        protected string ApiRoute { get; private set; }

        protected RestApiController(string apiRouteName, IRepository<T, TId> repository)
        {
            _repository = repository;
            ApiRoute = apiRouteName;
        }

        public virtual IEnumerable<T> Get()
        {
            return _repository.FindAll();
        }

        public virtual T Get(TId id)
        {
            var entity = _repository.FindById(id);
            if (entity == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return entity;
        }

        public virtual HttpResponseMessage Post(T entity)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(entity);
                var response = Request.CreateResponse<T>(HttpStatusCode.Created, entity);
                response.Headers.Location = GetLocation(entity.Id);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public virtual HttpResponseMessage Put(TId id, T entity)
        {
            _repository.Update(entity, id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public virtual HttpResponseMessage Delete(TId id)
        {
            var contact = _repository.FindById(id);
            if (contact == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            _repository.Delete(contact);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        protected Uri GetLocation(object resourceId)
        {
            var controller = Request.GetRouteData().Values["controller"];
            return new Uri(Url.Link(ApiRoute, new {controller = controller, id = resourceId}));
        }
    }
}