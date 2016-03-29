using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumSystem.Web.MVC.Startup))]
namespace ForumSystem.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
