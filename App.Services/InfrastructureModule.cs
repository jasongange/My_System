using App.Services.Repository;
using App.Services.Repository.NavLink;
using App.Services.Service.NavLink;
using App.Services.Service.Student;
using App.Services.Utilities.HashHelper;
using Autofac;
using Codebiz.Domain.Repository;
using Infrastructure.Repository;
using Infrastructures.Repository;
using Infrastructures.Service;
using Infrastructures.Service.AppUser;
using System.Security.Cryptography;

namespace Infrastructures
{
    public class InfrastructureModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryBase<>))
                .As(typeof(IRepositoryBase<>));


            RegisterRepositories(builder);
            RegisterServices(builder);

            builder.Register(c => new HashHelper(new SHA1CryptoServiceProvider())).As<IHashHelper>().SingleInstance();
            //builder.RegisterType<EmailHelper>().As<IEmailHelper>().InstancePerLifetimeScope();
            //builder.RegisterType<PasswordHelper>().As<IPasswordHelper>().SingleInstance();
        }
        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<NavLinkRepository>().As<INavLinkRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();


        }
        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<NavLinkService>().As<INavLinkService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
        }
    }
}
