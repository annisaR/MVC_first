using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPANETLOGINIDENTITY.Startup))]
namespace ASPANETLOGINIDENTITY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
