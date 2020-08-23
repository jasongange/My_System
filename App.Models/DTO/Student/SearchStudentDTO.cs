using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTO.Student
{
   public class SearchStudentDTO
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string StudentNo { get; set; }
        public DateTime? Birthday { get; set; }

        public string Address { get; set; }
        public string Gender { get; set; }
        public string IsPaid { get; set; }
        public string YearLevel { get; set; }
        public string SchoolAttendedHistory { get; set; }
        public long? ContactNumber { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
       
     
    }
}
