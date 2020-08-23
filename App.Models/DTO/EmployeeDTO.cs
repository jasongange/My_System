using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTO
{
    public  class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Username { get; set; }

        public string Department { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateHired { get; set; }

        public string Street { get; set; }
        public string Baranggay { get; set; }

        public string City { get; set; }

    }
}
