using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using App.Domain.Models;
using App.Models.DTO.NavLink;
using App.Models.ViewModel;
using App.Services;
using App.Services.Service.NavLink;
using Infrastructures.Service;

namespace EmployeeDatabaseSystem.Controllers
{
    public class NavLinkController : BaseController
    {
        private readonly INavLinkService _navLinkService;
        private readonly IUnitOfWork _unitOfWork;

        public NavLinkController(
            INavLinkService navLinkService,
            IUnitOfWork unitOfWork,
            IAppUserService appUserServices) 
            : base(appUserServices)
        {
            _navLinkService = navLinkService;
            _unitOfWork = unitOfWork;
        }

        // GET: NavLink
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
        public ActionResult IndexView(int id)
        {
            var navLink = _navLinkService.GetById(id);
            return RedirectToAction(navLink.Action, navLink.Controller);
        }

        [HttpGet]
        public JsonResult GetAllNavLink()
        {
            var result = _navLinkService.GetAllNavLink();

            return Json(new
            {
                data = result.Select(a => new
                {
                    Id = a.NavLinkId,
                    a.Name,
                    a.IconClass,
                    a.Controller,
                    a.Action
                })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchNavLink(NavlinkFilter filter)
        {
            var result = _navLinkService.SearchNavLink(filter);

            return Json(new
            {
                data = result.ToList(),
                totalRecordCount = filter.FilteredRecordCount
            }, JsonRequestBehavior.AllowGet);
        }

        #region Add Navlink

        [HttpPost]
        public JsonResult AddNavLink(NavlinkAddOrUpdateViewModel model)
        {
            var message = "";
            var success = true;
            try
            {
                if (success)
                {
                    var navLink = _navLinkService.GetById(model.NavLinkId);

                    if (navLink == null)
                    {
                        navLink = new NavLink();
                    }
                    navLink.Name = model.Name;
                    navLink.Controller = model.Controller;
                    navLink.Action = model.Action;
                    navLink.IconClass = model.IconClass;
                    navLink.IsParent = model.IsParent;

                    _navLinkService.InsertOrUpdate(navLink, CurrentUser.AppUserId);
                    _unitOfWork.SaveChanges();

                    success = true;
                    message = "Navlink has been successfully saved!";
                }
            }
            catch (DbUpdateException dbEx)
            {
                message = "Failed to add navlink!";
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

        public JsonResult GetNavLinkDetails(int navLinkId)
        {
            var result = _navLinkService.GetDetails(navLinkId);

            return Json(new
            { 
                data = result
            
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int navLinkId)
        {
            bool result = false;
            var data = _navLinkService.GetById(navLinkId);
            if (data != null)
            {
                data.IsActive = false;
                _unitOfWork.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}