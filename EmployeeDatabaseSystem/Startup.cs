using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Fred comment test 2018.03.06
        }
    }
}