using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Phonebook.v2.Web.Startup))]
namespace Phonebook.v2.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
