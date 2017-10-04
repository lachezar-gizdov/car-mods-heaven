using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CarModsHeaven.Web.Startup))]

namespace CarModsHeaven.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
