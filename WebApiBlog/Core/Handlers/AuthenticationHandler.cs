using System.Net.Http;
using System.Security.Principal;
using System.Web.Http.Hosting;

namespace WebApiBlog.Core.Handlers
{
    public class AuthenticationHandler : DelegatingHandler, IDelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            //var identity = new GenericIdentity(credentials.Username, "Basic");
            //request.Properties.Add(HttpPropertyKeys., new GenericPrincipal(identity, new string[0]));

            return base.SendAsync(request, cancellationToken);
        }
    }
}