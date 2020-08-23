using App.Domain;
using App.Models.DTO.NavLink;
using App.Services.Utilities;
using Infrastructure.Repository;
using PagedList;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace App.Services.Repository.NavLink
{
    public class NavLinkRepository : RepositoryBase<Domain.Models.NavLink>, INavLinkRepository
    {
        public NavLinkRepository(
            AppDomainContext context) 
            : base(context)
        {
        }

        public IEnumerable<Domain.Models.NavLink> GetAllNavLink()
        {
            return GetAll.Where(a =>a.IsActive).AsEnumerable();
        }
        public Domain.Models.NavLink GetById(int id)
        {
            return GetAll.FirstOrDefault(a => a.NavLinkId == id);
        }

        public NavLinkDetailsDTO GetDetails(int navlinkId)
        {
            var result = GetAll.Where(x => x.NavLinkId == navlinkId).Select(a => new NavLinkDetailsDTO
            {
               NavlinkId = a.NavLinkId,
               Name = a.Name,
               Controller = a.Controller,
               Action = a.Action,
               IconClass = a.IconClass,
               IsParent = a.IsParent
            }).FirstOrDefault();
            return result;
        }

        public override void InsertOrUpdate(Domain.Models.NavLink entity)
        {
            if (entity.NavLinkId.Equals(0))
            {
                this.Context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                this.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public IPagedList<SearchNavLinkDTO> SearchNavLink(NavlinkFilter filter)
        {
            var data = GetData(filter);

            filter.FilteredRecordCount = data.Count();

            var dataDTO = data.Select(a => new SearchNavLinkDTO
            {
                NavlinkId = a.NavLinkId,
                Name = a.Name,
                Controller = a.Controller,
                CreatedBy = a.CreatedByAppUser.FirstName + " " + a.CreatedByAppUser.LastName,
                CreatedOn = a.CreatedOn
            });
            dataDTO = QueryHelper.Ordering(dataDTO, filter.SortColumn, filter.SortDirection != "asc", false);

            return dataDTO.ToPagedList(filter.Page, filter.PageSize);
        }
        private IQueryable<Domain.Models.NavLink> GetData(NavlinkFilter filter)
        {
            var data = GetAll.Where(a => a.IsActive);

            //Filter
            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                filter.Name = filter.Name.Trim();
                data = data.Where(a => a.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrWhiteSpace(filter.CreatedBy))
            {
                filter.CreatedBy = filter.CreatedBy.Trim();
                data = data.Where(a => (a.CreatedByAppUser.FirstName + " "
                + a.CreatedByAppUser.LastName)
                .Trim().Contains(filter.CreatedBy));
            }
            return data;
        }
        
    }
}
