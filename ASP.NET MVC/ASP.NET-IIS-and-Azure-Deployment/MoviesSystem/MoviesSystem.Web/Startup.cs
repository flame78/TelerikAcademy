using Microsoft.Owin;

using MoviesSystem.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace MoviesSystem.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}