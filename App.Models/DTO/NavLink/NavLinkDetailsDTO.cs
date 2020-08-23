using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTO.NavLink
{
   public class NavLinkDetailsDTO
    {
        public int NavlinkId { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string IconClass { get; set; }
        public bool IsParent { get; set; }
    }
}
