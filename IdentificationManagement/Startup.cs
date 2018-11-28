using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentificationManagement.Startup))]
namespace IdentificationManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
