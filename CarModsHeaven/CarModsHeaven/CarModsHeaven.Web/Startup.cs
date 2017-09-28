using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarModsHeaven.Web.Startup))]
namespace CarModsHeaven.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
