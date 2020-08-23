using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.ViewModel
{
    public class EmployeeViewModel
    {

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
        public string CreatedBy { get; set; }

        public string Gender { get; set; }
        public string Department { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public DateTime DateHired { get; set; }

        public string Street { get; set; }
        public string Baranggay { get; set; }

        public string City { get; set; }
    }
}
