using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Hosting;
using WebApiBlog.Core.DataAccess;

namespace WebApiBlog.Core.Handlers
{
    public class AuthenticationHandler : DelegatingHandler, IDelegatingHandler
    {
        private readonly IAccessTokenRepository _accessTokenRepository;
        private readonly IUserRepository _userRepository;

        public AuthenticationHandler(IAccessTokenRepository accessTokenRepository, IUserRepository userRepository)
        {
            _accessTokenRepository = accessTokenRepository;
            _userRepository = userRepository;
        }

        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var accessToken = request.Headers.GetCookies("token");
            if (accessToken.Count == 0)
                return base.SendAsync(request, cancellationToken);

            var tokenValue = accessToken[0]["token"].Value;
            var token = _accessTokenRepository.FindById(tokenValue);
            if(token == null)
                return base.SendAsync(request, cancellationToken);

            var user = _userRepository.FindById(token.UserId);

            var identity = new GenericIdentity(user.Username, "Basic");
            var principal = new GenericPrincipal(identity, new[] {"Administrator"});
            Thread.CurrentPrincipal = principal;

            return base.SendAsync(request, cancellationToken);
        }
    }
}