using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Helpers;
using System.Security.Claims;

namespace EmployeeDatabaseSystem
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Autofac
            ConfigureIoc();
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Fix antiforgery issue
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
        private void ConfigureIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new SiteModule());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}