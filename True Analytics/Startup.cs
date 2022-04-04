using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(True_Analytics.Startup))]
namespace True_Analytics
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
