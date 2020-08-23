using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
  public  class EmployeeAddress: BaseEntity
    {
        [ForeignKey("Employee")]
        public int EmployeeAddressId { get; set; }

        public string Street { get; set; }

        public string Baranggay { get; set; }

        public string City { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
