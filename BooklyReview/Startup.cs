using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BooklyReview.Startup))]
namespace BooklyReview
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
