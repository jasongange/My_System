using System.Web.Mvc;
using Infrastructures.Service;
using App.Services;
using App.Models.DTO.AppUser;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System;
using App.Models.ViewModel;
using App.Domain.Models;

namespace EmployeeDatabaseSystem.Controllers
{
    public class AppUserController : BaseController
    {
        private readonly IAppUserService _appUserService;
        private readonly IUnitOfWork _unitOfWork;
        public AppUserController(
            IUnitOfWork unitOfWork,
            IAppUserService appUserServices) 
            : base(appUserServices)
        {
            _appUserService = appUserServices;
            _unitOfWork = unitOfWork;
        }

        // GET: AppUser
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult AddForm()
        {
            return View("Form");
        }
        public ActionResult EditForm(int id)
        {
            return View("Form");
        }
        [HttpGet]
        public JsonResult SearchAppUser(AppUserFilter filter)
        {
            var result = _appUserService.SearchAppUser(filter);

            return Json(new
            {
                data = result.ToList(),
                totalRecordCount = filter.FilteredRecordCount
            }, JsonRequestBehavior.AllowGet);
        }

        #region Add AppUser

        [HttpPost]
        public JsonResult AddAppUser(AppUserAddOrUpdateViewModel model)
        {
            var message = "";
            var success = true;
            try
            {
                if (success)
                {
                    var appUser = _appUserService.GetById(model.AppUserId);

                    if (appUser == null)
                    {
                        appUser = new AppUser();
                    }

                    appUser.LastName = model.LastName;
                    appUser.FirstName = model.FirstName;
                    appUser.MiddleName = model.MiddleName;
                    appUser.Email = model.Email;
                    appUser.UserName = model.UserName;
                    appUser.Password = model.Password;

                    _appUserService.InsertOrUpdate(appUser, CurrentUser.AppUserId);
                    _unitOfWork.SaveChanges();

                    success = true;
                    message = "AppUser has been successfully saved!";
                }
            }
            catch (DbUpdateException dbEx)
            {
                message = "Failed to add user!";
                success = false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                success = false;
            }

            return Json(new
            {
                success = success,
                message = message
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}