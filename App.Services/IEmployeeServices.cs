using App.Models.DTO;
using App.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
   public interface IEmployeeServices
    {
        //Get List of Employee
        List<EmployeeDTO> GetEmployeeList();

        //Get employee by ID
        EmployeeDTO GetEmployeeById(EmployeeViewModel employeeViewModel);

        //Insert Employee
        void InsertEmployee(EmployeeViewModel employeeViewModel);

        //Update Employee Datails
        EmployeeDTO UpdateEmployeeDetails(EmployeeViewModel employeeViewModel);

        //Delete Employee
        void DeleteEmployee(EmployeeViewModel employeeViewModel);




        //get List of EmployeeTask
        List<EmployeeTaskDTO> GetEmployeeTask();

        //InsertEmployeeTask
        void InsertEmployeeTask(EmpInsertTaskViewModel empInsertTaskViewModel);

        //Update Employee Task Details
        EmployeeTaskDTO UpdateEmployeeTaskDetails(EmployeeTaskViewModel employeeTaskViewModel);

        //DeleteEmployeeTask
        void DeleteEmployeeTask(EmployeeTaskViewModel employeeTaskViewModel);

       

       

        

      

       
       
    }
}
