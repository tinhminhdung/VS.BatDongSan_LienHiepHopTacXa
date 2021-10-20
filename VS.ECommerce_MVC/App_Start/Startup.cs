using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VS.ECommerce_MVC.Startup))]
namespace VS.ECommerce_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
