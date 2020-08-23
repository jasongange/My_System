using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models
{
    public class AppUser
    {
        [Key]
        public int AppUserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Suffix { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("CreatedByAppUser")]
        public int? CreatedByAppUserId { get; set; }
        public virtual AppUser CreatedByAppUser { get; set; }

        public DateTime? CreatedOn { get; set; }

        //[ForeignKey("ModifiedByAppUser")]
        //public int? ModifiedByAppUserId { get; set; }
        //public virtual AppUser ModifiedByAppUser { get; set; }
        //public DateTime? ModifiedOn { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}
