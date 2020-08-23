using App.Domain;
using App.Domain.Models;
using App.Models.DTO;
using App.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class EmployeeServices: IEmployeeServices
    {
        private AppDomainContext Context { get; set; }
        public EmployeeServices()
        {
            Context = new AppDomainContext();
        }
        private EmployeeDTO MapModelToEmployeeDTO(Employee employee)
        {
            var employeeDTO = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Username = employee.Username,
                Gender = employee.Gender,
                Department = employee.Department,
                Street = employee.EmployeeAddress.Street,
                Baranggay = employee.EmployeeAddress.Baranggay,
                City = employee.EmployeeAddress.City

            };
            return employeeDTO;
        }
        private Employee UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            var dateNow = DateTime.Now;
            var employee = Context.Employee.
                Where(d => d.IsActive == true && d.EmployeeId == employeeViewModel.EmployeeId)
              .FirstOrDefault();

            employee.FirstName = employeeViewModel.FirstName;
            employee.LastName = employeeViewModel.LastName;
            employee.Gender = employeeViewModel.Gender;
            employee.Department = employeeViewModel.Department;
            employee.UpdatedBy = "Admin";
            employee.DateUpdated = dateNow;
            employee.EmployeeAddress.Street = employeeViewModel.Street;
            employee.EmployeeAddress.Baranggay = employeeViewModel.Baranggay;
            employee.EmployeeAddress.City = employeeViewModel.City;
            employee.EmployeeAddress.DateUpdated = dateNow;
            employee.EmployeeAddress.UpdatedBy = "Admin";

            Context.SaveChanges();
            return employee;
        }
        public EmployeeDTO UpdateEmployeeDetails(EmployeeViewModel employeeViewModel)
        {
            var employee = UpdateEmployee(employeeViewModel);
            var employeeDTO = MapModelToEmployeeDTO(employee);
            return employeeDTO;
        }
        public List<EmployeeDTO> GetEmployeeList()
        {

            var listOfEmployee = Context.Employee.Where(d => d.IsActive == true).Select(p => new EmployeeDTO
            {
                EmployeeId = p.EmployeeId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Username = p.Username,
                Department = p.Department,
                Gender = p.Gender,
                Street = p.EmployeeAddress.Street,
                Baranggay = p.EmployeeAddress.Baranggay,
                City = p.EmployeeAddress.City

            })
            .ToList();

            return listOfEmployee;
        }
        public List<EmployeeTaskDTO> GetEmployeeTask()
        {
            var taskOfemployee = Context.EmployeeTask.Where(d => d.IsActive == true).Select(p => new EmployeeTaskDTO
            {
                EmployeeTaskId = p.EmployeeTaskId,
                EmployeeTaskName = p.EmployeeTaskName,
                EmployeeTaskDetails = p.EmployeeTaskDetails,
                EmployeeName = p.Employee.LastName + ", " + p.Employee.FirstName
            })
            .ToList();

            return taskOfemployee;
        }
        public EmployeeDTO GetEmployeeById(EmployeeViewModel employeeViewModel)
        {
            var employee = Context.Employee.Where(d => d.IsActive == true && d.EmployeeId == employeeViewModel.EmployeeId)
                .Select(p => new EmployeeDTO
                {
                    EmployeeId = p.EmployeeId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Username = p.Username,
                    Department = p.Department,
                    Gender = p.Gender,
                    Street = p.EmployeeAddress.Street,
                    Baranggay = p.EmployeeAddress.Baranggay,
                    City = p.EmployeeAddress.City

                }).FirstOrDefault();

            return employee;
        }
        public void InsertEmployee(EmployeeViewModel employeeViewModel)
        {
            var dateNow = DateTime.Now;
            var employee = new Employee
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Username = employeeViewModel.Username,
                Gender = employeeViewModel.Gender,
                Department = employeeViewModel.Department,
                Birthday = dateNow.AddYears(-30),
                DateCreated = dateNow,
                CreatedBy = "Admin",
                IsActive = true,
                EmployeeAddress = new EmployeeAddress
                {
                    Street = employeeViewModel.Street,
                    Baranggay = employeeViewModel.Baranggay,
                    City = employeeViewModel.City,
                    IsActive = true,
                    DateCreated = dateNow,
                    CreatedBy = "Admin"
                }
            };
            Context.Employee.Add(employee);
            Context.SaveChanges();
        }
        public void DeleteEmployee(EmployeeViewModel employeeViewModel)
        {
            var dateNow = DateTime.Now;
            var employee = Context.Employee.
                Where(d => d.IsActive == true && d.EmployeeId == employeeViewModel.EmployeeId).FirstOrDefault();

            employee.UpdatedBy = "Admin";
            employee.DateUpdated = dateNow;
            employee.IsActive = false;

            Context.SaveChanges();
        }
        private EmployeeTask UpdateEmployeeTask(EmployeeTaskViewModel employeeTaskViewModel)
        {
            var dateNow = DateTime.Now;
            var employeeTask = Context.EmployeeTask.
                Where(d => d.IsActive == true && d.EmployeeTaskId == employeeTaskViewModel.EmployeeTaskId)
              .FirstOrDefault();

            employeeTask.EmployeeTaskName = employeeTaskViewModel.EmployeeTaskName;
            employeeTask.EmployeeTaskDetails = employeeTaskViewModel.EmployeeTaskDetails;
            employeeTask.DateUpdated = dateNow;
            employeeTask.UpdatedBy = "Admin";

            Context.SaveChanges();
            return employeeTask;
        }
        private EmployeeTaskDTO MapModelToEmployeeTaskDTO(EmployeeTask employeeTask)
        {
            var employeeTaskDTO = new EmployeeTaskDTO
            {
                EmployeeTaskId = employeeTask.EmployeeTaskId,
                EmployeeTaskName = employeeTask.EmployeeTaskName,
                EmployeeTaskDetails = employeeTask.EmployeeTaskDetails

            };
            return employeeTaskDTO;
        }

        public EmployeeTaskDTO UpdateEmployeeTaskDetails(EmployeeTaskViewModel employeeTaskViewModel)
        {
            var employeeTask = UpdateEmployeeTask(employeeTaskViewModel);
            var employeeTaskDTO = MapModelToEmployeeTaskDTO(employeeTask);
            return employeeTaskDTO;
        }
        public void InsertEmployeeTask(EmpInsertTaskViewModel empInsertTaskViewModel)
        {
            var dateNow = DateTime.Now;
            var employee = Context.Employee.
               Where(d => d.IsActive == true && d.EmployeeId == empInsertTaskViewModel.EmployeeId)
             .FirstOrDefault();
            var employeeTask = new EmployeeTask
            {
                EmployeeId = empInsertTaskViewModel.EmployeeId,
                EmployeeTaskName = empInsertTaskViewModel.EmployeeTaskName,
                EmployeeTaskDetails = empInsertTaskViewModel.EmployeeTaskDetails,
                DateCreated = dateNow,
                CreatedBy = "Admin",
                IsActive = true
            };
            Context.EmployeeTask.Add(employeeTask);
            Context.SaveChanges();
        }
        public void DeleteEmployeeTask(EmployeeTaskViewModel employeeTaskViewModel)
        {
            var DateNow = DateTime.Now;
            var employee = Context.EmployeeTask.
            Where(d => d.IsActive == true && d.EmployeeTaskId == employeeTaskViewModel.EmployeeTaskId).FirstOrDefault();
            var employeetask = new EmployeeTask();

            employee.UpdatedBy = "Admin";
            employee.DateUpdated = DateTime.Now;
            employee.IsActive = false;

            Context.SaveChanges();

        }
    }
}
