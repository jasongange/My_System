using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class Employee: BaseEntity
    {
        [Key]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        public virtual EmployeeAddress EmployeeAddress { get; set; }
        public virtual ICollection<EmployeeTask> EmployeeTask { get; set; }
    }
}
