using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheAgency.Startup))]
namespace TheAgency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
