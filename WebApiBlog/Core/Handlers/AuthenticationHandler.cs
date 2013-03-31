using System.Net.Http;

namespace WebApiBlog.Core.Handlers
{
    public class AuthenticationHandler : DelegatingHandler, IDelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}