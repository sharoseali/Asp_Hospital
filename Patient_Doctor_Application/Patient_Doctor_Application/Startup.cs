using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Patient_Doctor_Application.Startup))]
namespace Patient_Doctor_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
