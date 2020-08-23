using App.Models.ViewModel;
using App.Services;
using Infrastructures.Service;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDatabaseSystem.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAppUserService _appUserServices;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(
        IAppUserService appUserServices,
        IUnitOfWork unitOfWork
        ) : base(appUserServices)
        {
            _appUserServices = appUserServices;
            _unitOfWork = unitOfWork;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public JsonResult Login(LoginViewModel model)
        {
            AuthenticationManager.SignOut();
            var message = "";
            var success = true;
            var appUser = _appUserServices.Login(model);
            if(appUser != null)
            {
                var user = _appUserServices.GetByUserName(model.Username);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserName),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };
                    ClaimsIdentity identity;
                    identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(identity);
                    success = true;
                    message = "Successfully login!";
                }
                else
                {
                    message = "Invalid Credential!";
                    success = false;
                }
        
            }
            return Json(new
            {
                success,
                message,
                Data = appUser,
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            _unitOfWork.SaveChanges();

            Session["AppUser"] = null;
            Session.Clear();

            return RedirectToAction("Login", "Account");
        }
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

    }
}
