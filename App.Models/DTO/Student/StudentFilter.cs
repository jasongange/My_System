using App.Models.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTO.Student
{
   public class StudentFilter: FilterBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string StudentNo { get; set; }
        public int? GenderId { get; set; }
        public int? ReligionId { get; set; }
        public string Address { get; set; }
    }
}
