using System;
using System.Web;
using System.Web.Mvc;
using WebApiBlog.Core.DataAccess;
using WebApiBlog.Core.Services;
using WebApiBlog.Models;
using WebApiBlog.ViewModels;

namespace WebApiBlog.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccessTokenRepository _accessTokenRepository;

        public SecurityController(IAuthenticationService authenticationService, IAccessTokenRepository accessTokenRepository)
        {
            _authenticationService = authenticationService;
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

            var result = _authenticationService.Authenticate(model);
            if (!result.IsAuthenticated)
                return View(model);

            var token = new AccessToken(result.User.Id);
            _accessTokenRepository.Save(token);
            Response.Cookies.Add(new HttpCookie("token", token.Id) { Expires = token.Expires, Path = "/" });

            return RedirectToAction("Index", "Security");
        }

        public ActionResult Logout()
        {
            Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Security");
        }
    }
}