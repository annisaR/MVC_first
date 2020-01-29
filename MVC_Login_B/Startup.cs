using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Login_B.Startup))]
namespace MVC_Login_B
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
