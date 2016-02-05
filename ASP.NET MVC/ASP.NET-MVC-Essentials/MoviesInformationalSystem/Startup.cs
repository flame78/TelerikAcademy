using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesInformationalSystem.Startup))]
namespace MoviesInformationalSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
