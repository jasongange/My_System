using App.Models.DTO.NavLink;
using PagedList;
using System.Collections.Generic;

namespace App.Services.Repository
{
    public interface INavLinkRepository
    {
        IEnumerable <Domain.Models.NavLink> GetAllNavLink();
        Domain.Models.NavLink GetById(int id);
        IPagedList<SearchNavLinkDTO> SearchNavLink(NavlinkFilter filter);
        void InsertOrUpdate(Domain.Models.NavLink navLink);
        NavLinkDetailsDTO GetDetails(int navlinkId);
    }
}
