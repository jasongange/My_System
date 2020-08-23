using App.Models.DTO.NavLink;
using PagedList;
using System.Collections.Generic;

namespace App.Services.Service.NavLink
{
    public interface INavLinkService
    {
        IEnumerable<Domain.Models.NavLink> GetAllNavLink();
        Domain.Models.NavLink GetById(int id);
        IPagedList<SearchNavLinkDTO> SearchNavLink(NavlinkFilter filter);
        void InsertOrUpdate(Domain.Models.NavLink navLink, int appUserId);
        NavLinkDetailsDTO GetDetails(int navlinkId);
    }
}
