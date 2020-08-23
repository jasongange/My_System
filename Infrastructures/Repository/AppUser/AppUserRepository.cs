using App.Domain;
using App.Domain.Models;
using Infrastructure.Repository;
using Infrastructures.Utilities.HashHelper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructures.Repository
{
    public class AppUserRepository: RepositoryBase<App.Domain.Models.AppUser>, IAppUserRepository
    {
        private readonly IHashHelper _hashHelper;
        public AppUserRepository(
            AppDomainContext context,
             IHashHelper hashHelper
            ) : base(context)
        {
            _hashHelper = hashHelper;
        }

        public App.Domain.Models.AppUser GetByEmailOrUsername(string emailOrUsername, Expression<Func<App.Domain.Models.AppUser, object>>[] includeProperties = null)
        {
            var query = GetAll.Where(x => x.IsActive);

            if (includeProperties != null)
            {
                query = GetAll.GetAllIncluding(includeProperties);
            }
            return query.Where(a => a.Username == emailOrUsername || a.Email == emailOrUsername).FirstOrDefault();
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

        public bool ValidatePassword(AppUser entity, string password)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            var passDetails = entity.PasswordHash.Split(':');
            var hashedPassword = passDetails[0];
            var salt = passDetails[1];

            var newHashedPassword = this.HashPassword(password, salt);

            if (newHashedPassword.ToLower() == hashedPassword.ToLower())
                return true;
            else
                return false;
        }
        public string HashPassword(string password, string salt)
        {
            return _hashHelper.ComputeHash(password + salt + password);
        }
    }
}
