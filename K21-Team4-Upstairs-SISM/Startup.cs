using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(K21_Team4_Upstairs_SISM.Startup))]
namespace K21_Team4_Upstairs_SISM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
