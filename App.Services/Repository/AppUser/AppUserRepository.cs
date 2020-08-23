using App.Domain;
using App.Domain.Models;
using App.Services.Utilities.HashHelper;
using Infrastructure.Repository;
using System.Data.Entity;
using System.Linq;
using App.Models.ViewModel;
using PagedList;
using App.Models.DTO.AppUser;
using App.Services.Utilities;

namespace Infrastructures.Repository
{
    public class AppUserRepository: RepositoryBase<AppUser>, IAppUserRepository
    {
        private readonly IHashHelper _hashHelper;
        public AppUserRepository(
            AppDomainContext context,
             IHashHelper hashHelper
            ) : base(context)
        {
            _hashHelper = hashHelper;
        }
        public AppUser Login(LoginViewModel loginViewModel)
        {
            return GetAll.FirstOrDefault(a => a.UserName.Equals(loginViewModel.Username)&&a.Password.Equals(loginViewModel.Password));    
        }
        public override void InsertOrUpdate(AppUser entity)
        {
            if (entity.AppUserId.Equals(0))
            {
                this.Context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                this.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public AppUser GetByUserName(string userName)
        {
            return GetAll.FirstOrDefault(a => a.UserName == userName);
        }

        //public AppUser GetByEmailOrUsername(string emailOrUsername)
        //{
        //    return GetAll.FirstOrDefault(a => a.Username == emailOrUsername || a.Email == emailOrUsername);
        //}

        public IPagedList<SearchAppUserDTO> SearchAppUser(AppUserFilter filter)
        {
            var data = GetData(filter);

            filter.FilteredRecordCount = data.Count();

            var dataDTO = data.Select(a => new SearchAppUserDTO
            {
                AppUserId = a.AppUserId,
                LastName = a.LastName,
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                UserName = a.UserName,
                Email = a.Email,
                CreatedOn = a.CreatedOn,
                //CreatedBy = a.CreatedByAppUser.FirstName + " " + a.CreatedByAppUser.LastName,
            });
            dataDTO = QueryHelper.Ordering(dataDTO, filter.SortColumn, filter.SortDirection != "asc", false);

            return dataDTO.ToPagedList(filter.Page, filter.PageSize);
        }
        private IQueryable<AppUser> GetData(AppUserFilter filter)
        {
            var data = GetAll.Where(a => a.IsActive);

            //Filter
            if (!string.IsNullOrWhiteSpace(filter.LastName))
            {
                filter.LastName = filter.LastName.Trim();
                data = data.Where(a => a.LastName.Contains(filter.LastName));
            }
            if (!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                filter.FirstName = filter.FirstName.Trim();
                data = data.Where(a => a.FirstName.Contains(filter.FirstName));
            }
            if (!string.IsNullOrWhiteSpace(filter.MiddleName))
            {
                filter.MiddleName = filter.MiddleName.Trim();
                data = data.Where(a => a.MiddleName.Contains(filter.MiddleName));
            }
            if (!string.IsNullOrWhiteSpace(filter.UserName))
            {
                filter.UserName = filter.UserName.Trim();
                data = data.Where(a => a.UserName.Contains(filter.UserName));
            }
            //if (!string.IsNullOrWhiteSpace(filter.CreatedBy))
            //{
            //    filter.CreatedBy = filter.CreatedBy.Trim();
            //    data = data.Where(a => (a.CreatedByAppUser.FirstName + " "
            //    + a.CreatedByAppUser.LastName)
            //    .Trim().Contains(filter.CreatedBy));
            //}
            return data;
        }
        public AppUser GetById(int id)
        {
            return GetAll.FirstOrDefault(a => a.AppUserId == id);
        }
    }
}
