using Microsoft.Owin;
using Owin;

// http://www.asp.net/aspnet/overview/owin-and-katana/owin-startup-class-detection
[assembly: OwinStartup("OwinStartup", typeof(HuskyRescue.Web.Startup))]
namespace HuskyRescue.Web
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}