using App.Models.DTO.NavLink;
using App.Services.Repository;
using PagedList;
using System;
using System.Collections.Generic;

namespace App.Services.Service.NavLink
{
    public class NavLinkService : INavLinkService
    {
        private readonly INavLinkRepository _navLinkRepository;
        public NavLinkService(
        INavLinkRepository navLinkRepository
        )
        {
            _navLinkRepository = navLinkRepository;
        }
        public IEnumerable<Domain.Models.NavLink> GetAllNavLink()
        {
           return _navLinkRepository.GetAllNavLink();
        }

        public Domain.Models.NavLink GetById(int id)
        {
            return _navLinkRepository.GetById(id);
        }

        public NavLinkDetailsDTO GetDetails(int navlinkId)
        {
            return _navLinkRepository.GetDetails(navlinkId);
        }

        public void InsertOrUpdate(Domain.Models.NavLink entity, int id)
        {
            if (entity.NavLinkId.Equals(0))
            {
                var now = DateTime.Now;

                entity.CreatedByAppUserId = id;
                entity.CreatedOn = now;
                entity.IsActive = true;
            }
            else
            {
                entity.ModifiedByAppUserId = id;
                entity.ModifiedOn = DateTime.Now;
            }
            _navLinkRepository.InsertOrUpdate(entity);
        }
        public IPagedList<SearchNavLinkDTO> SearchNavLink(NavlinkFilter filter)
        {
            return _navLinkRepository.SearchNavLink(filter);
        }
    }
}
