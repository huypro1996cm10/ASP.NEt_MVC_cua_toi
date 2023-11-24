using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website_MVC.Startup))]
namespace Website_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
