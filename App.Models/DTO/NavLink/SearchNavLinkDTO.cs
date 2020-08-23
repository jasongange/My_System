using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTO.NavLink
{
   public class SearchNavLinkDTO
    {
        public int NavlinkId { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
