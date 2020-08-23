using App.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
   public class Student: ModelBase
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string StudentNo { get; set; }

        public string Address { get; set; }

        public DateTime? Birthday { get; set; }

        [ForeignKey("Gender")]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? YearLevel { get; set; }
        public string SchoolAttendedHistory { get; set; }
        public long? ContactNumber { get; set; }
        public string Remarks { get; set; }
        public bool IsPaid { get; set; }
    }
}
