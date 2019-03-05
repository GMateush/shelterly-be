using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shelterly.Startup))]
namespace Shelterly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
