using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MealMonkey.Startup))]
namespace MealMonkey
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}
