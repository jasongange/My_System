using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class EmployeeTask: BaseEntity
    {
        [Key]
        public int EmployeeTaskId { get; set; }

        public string EmployeeTaskName { get; set; }

        public string EmployeeTaskDetails { get; set; }

        [ForeignKey("Employee")]

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
