using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shortner.Startup))]
namespace Shortner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
