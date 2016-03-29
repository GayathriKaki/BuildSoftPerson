using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuildSoftPerson.Startup))]
namespace BuildSoftPerson
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
