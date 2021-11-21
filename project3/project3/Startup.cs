using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(project3.Startup))]
namespace project3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
