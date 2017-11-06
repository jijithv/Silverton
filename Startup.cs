using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Silverton.Startup))]
namespace Silverton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
