using Infrastructures.Repository;
using System;
using System.Linq.Expressions;

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
        public App.Domain.Models.AppUser GetByEmailOrUsername(string emailOrUsername, Expression<Func<App.Domain.Models.AppUser, object>>[] includeProperties = null)
        {
            return _appUserRepository.GetByEmailOrUsername(emailOrUsername, includeProperties);
        }

        public bool ValidatePassword(App.Domain.Models.AppUser entity, string password)
        {
            return _appUserRepository.ValidatePassword(entity, password);
        }
    }
}
