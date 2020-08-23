using App.Domain.Models;
using Codebiz.Domain.Repository;
using System;
using System.Linq.Expressions;

namespace Infrastructures.Repository
{
    public interface IAppUserRepository : IRepositoryBase<App.Domain.Models.AppUser>
    {
        App.Domain.Models.AppUser GetByEmailOrUsername(string emailOrUsername, Expression<Func<App.Domain.Models.AppUser, object>>[] includeProperties = null);
        bool ValidatePassword(AppUser entity, string password);
        string HashPassword(string password, string salt);
    }
}
