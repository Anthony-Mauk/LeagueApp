using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueApp.WebMVC.Startup))]
namespace LeagueApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
