using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LooseLyCoupleApp.Startup))]
namespace LooseLyCoupleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
