using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BanglaBazarFoodCourt.Startup))]
namespace BanglaBazarFoodCourt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
