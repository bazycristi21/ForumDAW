using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumDAW.Startup))]
namespace ForumDAW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
