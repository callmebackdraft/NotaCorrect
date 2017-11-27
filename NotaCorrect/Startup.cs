using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotaCorrect.Startup))]
namespace NotaCorrect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
