using System;
using System.Net.Http;

namespace WebApiBlog.Core.Handlers
{
    public class ResponseHeaderHandler : DelegatingHandler, IDelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                                  {
                                      var response = task.Result;
                                      response.Headers.Add("X-Custom-Header", Guid.NewGuid().ToString());
                                      return response;
                                  });
        }
    }
}