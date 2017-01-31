using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(School_Management_Web.Startup))]
namespace School_Management_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
