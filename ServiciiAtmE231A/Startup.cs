using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiciiAtmE231A.Startup))]
namespace ServiciiAtmE231A
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
