using WebApiBlog.Models;
using WebApiBlog.ViewModels;

namespace WebApiBlog.Core.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResult Authenticate(LoginModel loginModel);
    }
}