using System.Web.Mvc;
using WebApiBlog.Core.DataAccess;
using WebApiBlog.ViewModels;

namespace WebApiBlog.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccessTokenRepository _accessTokenRepository;

        public SecurityController(IUserRepository userRepository, IAccessTokenRepository accessTokenRepository)
        {
            _userRepository = userRepository;
            _accessTokenRepository = accessTokenRepository;
        }

        public ActionResult Index()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            return null;
        }
    }
}