using App.Models.ViewModel;
using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeDatabaseSystem.Controllers
{
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public class DemoAppController : ApiController
        {
            private readonly IEmployeeServices _employeeServices;
            // GET api/<controller>
            public DemoAppController()
            {
                _employeeServices = new EmployeeServices();
            }
            [HttpGet]
            public IHttpActionResult Get()
            {
                var listOfEmployee = _employeeServices.GetEmployeeList();
                return Ok(listOfEmployee);
            }
            [HttpGet]
            public IHttpActionResult GetEmployeeTask()
            {
                var taskOfEmployee = _employeeServices.GetEmployeeTask();
                return Ok(taskOfEmployee);
            }
            // GET api/<controller>/5
            public IHttpActionResult GetEmployeeById(EmployeeViewModel employeeViewModel)
            {
                var employee = _employeeServices.GetEmployeeById(employeeViewModel);
                return Ok(employee);
            }

            // POST api/<controller>
            [HttpPost]
            public IHttpActionResult UpdateEmployeeDTO(EmployeeViewModel employeeViewModel)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var employeeDTO = _employeeServices.UpdateEmployeeDetails(employeeViewModel);
                return Ok(employeeDTO);
            }
            [HttpPost]
            public IHttpActionResult InsertEmployeeDTO(EmployeeViewModel employeeViewModel)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _employeeServices.InsertEmployee(employeeViewModel);

                return Ok();
            }
            [HttpPost]
            public IHttpActionResult DeleteEmployeeDTO(EmployeeViewModel employeeViewModel)
            {
                if (!ModelState.IsValid)

                    return BadRequest(ModelState);

                _employeeServices.DeleteEmployee(employeeViewModel);
                return Ok();
            }
            public IHttpActionResult UpdateEmployeeTask(EmployeeTaskViewModel employeeTaskViewModel)
            {
                if (!ModelState.IsValid)

                    return BadRequest(ModelState);

                var personTaskDTO = _employeeServices.UpdateEmployeeTaskDetails(employeeTaskViewModel);
                return Ok(personTaskDTO);

            }
            public IHttpActionResult InsertEmployeeTaskDTO(EmpInsertTaskViewModel empInsertTaskViewModel)
            {
                if (!ModelState.IsValid)

                    return BadRequest(ModelState);

                _employeeServices.InsertEmployeeTask(empInsertTaskViewModel);
                return Ok();
            }
            [HttpPost]
            public IHttpActionResult DeleteEmployeeTaskDTO(EmployeeTaskViewModel employeeTaskViewModel)
            {
                if (!ModelState.IsValid)

                    return BadRequest(ModelState);

                _employeeServices.DeleteEmployeeTask(employeeTaskViewModel);
                return Ok();
            }
        }
}
