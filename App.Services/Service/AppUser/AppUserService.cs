using Infrastructures.Repository;
using App.Models.ViewModel;
using PagedList;
using App.Models.DTO.AppUser;
using App.Domain.Models;
using System;

namespace Infrastructures.Service.AppUser
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        public AppUserService(
        IAppUserRepository appUserRepository
        )
        {
            _appUserRepository = appUserRepository;
        }

        public App.Domain.Models.AppUser GetById(int id)
        {
            return _appUserRepository.GetById(id);
        }

        public App.Domain.Models.AppUser GetByUserName(string userName)
        {
            return _appUserRepository.GetByUserName(userName);
        }

        public void InsertOrUpdate(App.Domain.Models.AppUser entity, int id)
        {
            if (entity.AppUserId.Equals(0))
            {
                var now = DateTime.Now;

                entity.CreatedByAppUserId = id;
                entity.CreatedOn = now;
                entity.IsActive = true;
            }
            //else
            //{
            //    entity.ModifiedByAppUserId = id;
            //    entity.ModifiedOn = DateTime.Now;
            //}
            _appUserRepository.InsertOrUpdate(entity);
        }

        public App.Domain.Models.AppUser Login(LoginViewModel loginViewModel)
        {
            return _appUserRepository.Login(loginViewModel);
        }

        public IPagedList<SearchAppUserDTO> SearchAppUser(AppUserFilter filter)
        {
            return _appUserRepository.SearchAppUser(filter);
        }
    }
}
