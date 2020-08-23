using Autofac;
using Codebiz.Domain.Repository;
using Infrastructure.Repository;

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

            //builder.Register(c => new HashHelper(new SHA1CryptoServiceProvider())).As<IHashHelper>().SingleInstance();
            //builder.RegisterType<EmailHelper>().As<IEmailHelper>().InstancePerLifetimeScope();
            //builder.RegisterType<PasswordHelper>().As<IPasswordHelper>().SingleInstance();
        }
        private void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();

        }
        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();

        }
    }
}
