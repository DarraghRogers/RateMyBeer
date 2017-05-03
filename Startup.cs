using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RateMyBeer.Startup))]
namespace RateMyBeer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
