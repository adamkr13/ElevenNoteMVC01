using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElevenNoteMVC01.Startup))]
namespace ElevenNoteMVC01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
