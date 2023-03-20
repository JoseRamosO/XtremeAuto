using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XtremeAuto.Startup))]
namespace XtremeAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
