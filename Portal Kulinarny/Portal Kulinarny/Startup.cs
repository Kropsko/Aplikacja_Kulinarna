using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Portal_Kulinarny.Startup))]
namespace Portal_Kulinarny
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
