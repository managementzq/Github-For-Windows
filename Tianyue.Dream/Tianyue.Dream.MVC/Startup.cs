using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tianyue.Dream.MVC.Startup))]
namespace Tianyue.Dream.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
