using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructures.Service;
using App.Services;
using App.Services.Service.Student;
using App.Models.DTO.Student;
using App.Models.ViewModel;
using System.Data.Entity.Infrastructure;

namespace EmployeeDatabaseSystem.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IAppUserService _appUserService;
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(
            IUnitOfWork unitOfWork,
            IStudentService studentService,
            IAppUserService appUserServices) 
            : base(appUserServices)
        {
            _appUserService = appUserServices;
            _studentService = studentService;
            _unitOfWork = unitOfWork;
        }

        // GET: Student
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
        public JsonResult SearchStudent(StudentFilter filter)
        {
            var result = _studentService.SearchStudent(filter);

            return Json(new
            {
                data = result.ToList(),
                totalRecordCount = filter.FilteredRecordCount
            }, JsonRequestBehavior.AllowGet);
        }

        #region Add Student
        [HttpPost]
        public JsonResult AddStudent(StudentAddOrUpdateViewModel model)
        {
            var message = "";
            var success = true;
            try
            {
                if (success)
                {
                    var student = _studentService.GetById(model.StudentId);

                    if (student == null)
                    {
                        student = new App.Domain.Models.Student();
                    }
                    student.StudentNo = model.StudentNo;
                    student.LastName = model.LastName;
                    student.FirstName = model.FirstName;
                    student.MiddleName = model.MiddleName;
                    student.Address = model.Address;
                    student.Birthday = model.Birthday;
                    student.GenderId = model.GenderId;
                    student.IsPaid = model.IsPaid;
                    student.YearLevel = model.YearLevel;
                    student.SchoolAttendedHistory = model.SchoolAttendedHistory;
                    student.ContactNumber = model.ContactNumber;
                    student.Remarks = model.Remarks;

                    _studentService.InsertOrUpdate(student, CurrentUser.AppUserId);
                    _unitOfWork.SaveChanges();

                    success = true;
                    message = "Student has been successfully saved!";
                }
            }
            catch (DbUpdateException dbEx)
            {
                message = "Failed to add student!";
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

        public JsonResult GetStudentDetails(int studentId)
        {
            var result = _studentService.GetDetails(studentId);

            return Json(new
            {
                data = result

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int studentId)
        {
            bool result = false;
            var data = _studentService.GetById(studentId);
            if (data != null)
            {
                data.IsActive = false;
                _unitOfWork.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TagAsPaid(int studentId)
        {
            bool result = true;
            var data = _studentService.GetById(studentId);
            if (data != null)
            {
                data.IsPaid = true;
                _unitOfWork.SaveChanges();
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}