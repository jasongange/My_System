using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTO
{
   public class EmployeeTaskDTO
    {
        public int EmployeeTaskId { get; set; }
        public string EmployeeName { get; set; }

        public string EmployeeTaskName { get; set; }
        public string EmployeeTaskDetails { get; set; }
    }
}
