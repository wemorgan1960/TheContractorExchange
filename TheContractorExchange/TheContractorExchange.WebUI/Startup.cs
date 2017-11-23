using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheContractorExchange.WebUI.Startup))]
namespace TheContractorExchange.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
