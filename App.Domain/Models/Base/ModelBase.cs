using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Models.Base
{
   public class ModelBase
    {
        public bool IsActive { get; set; }

        [ForeignKey("CreatedByAppUser")]
        public int CreatedByAppUserId { get; set; }
        public virtual AppUser CreatedByAppUser { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("ModifiedByAppUser")]
        public int? ModifiedByAppUserId { get; set; }
        public virtual AppUser ModifiedByAppUser { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
