using App.Models.DTO.AppUser;
using App.Models.ViewModel;
using PagedList;
using System;
using System.Linq.Expressions;

namespace Infrastructures.Service
{
    public interface IAppUserService
    {
        App.Domain.Models.AppUser Login(LoginViewModel loginViewModel);
        App.Domain.Models.AppUser GetByUserName(string userName);
        IPagedList<SearchAppUserDTO> SearchAppUser(AppUserFilter filter);
        App.Domain.Models.AppUser GetById(int id);
        void InsertOrUpdate(App.Domain.Models.AppUser appUser, int appUserId);
    }
}