using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HrAndPayrollSystem.Startup))]
namespace HrAndPayrollSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
