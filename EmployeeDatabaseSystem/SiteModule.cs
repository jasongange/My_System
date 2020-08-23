using App.Domain;
using App.Services;
using Autofac;
using Autofac.Integration.Mvc;
using Infrastructures;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeDatabaseSystem
{
    public class SiteModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDomainContext>().InstancePerLifetimeScope();
            builder.Register(c => new ApplicationContext()
            {
                Contexts = new List<DbContext>()
                {
                    c.Resolve<AppDomainContext>()
                }
            }).As<ApplicationContext>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterControllers(typeof(Global).Assembly);

            builder.RegisterModule(new InfrastructureModule());

            //builder.RegisterType<FileUploadHelper>().InstancePerLifetimeScope();          
        }
    }
}