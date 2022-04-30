using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GhostGallery.WebMVC.Startup))]
namespace GhostGallery.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
