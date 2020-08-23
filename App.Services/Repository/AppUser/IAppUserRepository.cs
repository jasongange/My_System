using App.Domain.Models;
using App.Models.DTO.AppUser;
using App.Models.ViewModel;
using Codebiz.Domain.Repository;
using PagedList;
using System;
using System.Linq.Expressions;

namespace Infrastructures.Repository
{
    public interface IAppUserRepository : IRepositoryBase<AppUser>
    {
        AppUser Login(LoginViewModel loginViewModel);
        AppUser GetByUserName(string userName);
        IPagedList<SearchAppUserDTO> SearchAppUser(AppUserFilter filter);
        AppUser GetById(int id);
        //AppUser GetByEmailOrUsername(string emailOrUsername);
    }
}
