using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebECommerce.Startup))]
namespace WebECommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
