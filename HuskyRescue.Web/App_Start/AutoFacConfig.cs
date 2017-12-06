using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NLog.Mvc;

namespace HuskyRescue.Web
{
	/// <summary>
	/// https://github.com/autofac/Autofac/wiki/Getting-Started
	/// </summary>
	public static class AutoFacConfig
	{
		public static void AutoFacConfigureContainer()
		{
			var builder = new ContainerBuilder();

			RegisterSingletons(builder);
			RegisterTransientTypes(builder);

			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
		}

		private static void RegisterSingletons(ContainerBuilder builder)
		{
			builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
		}

		private static void RegisterTransientTypes(ContainerBuilder builder)
		{

		}
	}
}