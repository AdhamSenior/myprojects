using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobilBor.Startup))]
namespace MobilBor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
