using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Astrofilm.Startup))]
namespace Astrofilm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
