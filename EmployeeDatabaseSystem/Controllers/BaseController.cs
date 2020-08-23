using App.Domain.Models;
using EmployeeDatabaseSystem.CustomActionResult;
using Infrastructures.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDatabaseSystem.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAppUserService _appUserServices;
        private AppUser _currentAppUser = null;

        public BaseController(IAppUserService appUserServices)
        {
            _appUserServices = appUserServices;
        }
        private void InitializeCurrentUser()
        {
            var currentContext = System.Web.HttpContext.Current;

            if (currentContext == null) return;

            if (!currentContext.Request.IsAuthenticated) return;

            var userSession = Session["AppUser"] as AppUser;

            if (userSession != null && userSession.UserName == currentContext.User.Identity.Name)
            {
                _currentAppUser = userSession;
            }
            else
            {
                _currentAppUser = _appUserServices.GetByUserName(currentContext.User.Identity.Name);
                Session["AppUser"] = _currentAppUser;
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            InitializeCurrentUser();
        }
        protected AppUser CurrentUser
        {
            get
            {
                InitializeCurrentUser();

                return _currentAppUser;
            }
        }
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonDotNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}