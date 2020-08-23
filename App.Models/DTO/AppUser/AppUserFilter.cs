using App.Models.DTO.Base;

namespace App.Models.DTO.AppUser
{
    public class AppUserFilter: FilterBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
    }
}
