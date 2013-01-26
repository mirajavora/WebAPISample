using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WebApiBlog.Core.DataAccess;

namespace WebApiBlog.Core.Api
{
    public abstract class RestApiController<T, TId> : ApiController, IRestApiController
    {
        private readonly IRepository<T, TId> _repository;
        protected string ApiRoute { get; private set; }

        public RestApiController(string apiRouteName)
        {
            ApiRoute = apiRouteName;
        }

        public abstract IEnumerable<T> Get();
        public abstract T Get(TId id);
        public abstract HttpResponseMessage Post(T contact);
        public abstract HttpResponseMessage Put(TId id, T contact);
        public abstract HttpResponseMessage Delete(TId id);

        protected Uri GetLocation(object resourceId)
        {
            var controller = Request.GetRouteData().Values["controller"];
            return new Uri(Url.Link(ApiRoute, new {controller = controller, id = resourceId}));
        }
    }
}