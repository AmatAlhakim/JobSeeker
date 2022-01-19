using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobSeeker.Startup))]
namespace JobSeeker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
