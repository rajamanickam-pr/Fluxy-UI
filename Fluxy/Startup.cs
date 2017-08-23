using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fluxy.Startup))]
namespace Fluxy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
