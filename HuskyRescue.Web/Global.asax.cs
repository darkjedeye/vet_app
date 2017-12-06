using Fabrik.Common.Web;
using HuskyRescue.Core.Mappers;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Web.Infrastructure.Binders;
using NLog.Mvc;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HuskyRescue.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private readonly ILogger _logger = new Logger();

		protected void Application_Start()
		{
			//RouteTable.Routes.MapHubs();

			AutoFacConfig.AutoFacConfigureContainer();

			AreaRegistration.RegisterAllAreas();

			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterAuth();

			//ModelBinders.Binders.DefaultBinder = new MyDefaultModelBinder();
			ModelBinders.Binders.Add(typeof(DateTime?), new MyDateTimeModelBinder());

			DataAnnotationsModelValidatorProvider.RegisterAdapterFactory(typeof(RoleRequiredAttribute),
				(metadata, controllerContext, attribute) => new RoleRequiredAttributeAdapter(metadata, controllerContext, (RoleRequiredAttribute)attribute));

			// http://ben.onfabrik.com/posts/content-negotiation-in-aspnet-mvc
			ViewResultFormatters.Formatters.Add(new PartialViewResultFormatter());

			AutoMapperConfiguration.Configure();

			_logger.Trace("Application Starting Up - Application_Start()");
		}

		protected void Application_Error()
		{
			var lastException = Server.GetLastError();
			_logger.Error("Global Error in Application_Error", lastException.InnerException ?? lastException);
		}
	}

	public class MyDefaultModelBinder : DefaultModelBinder
	{
		protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
		{
			return base.CreateModel(controllerContext, bindingContext, modelType);
		}
	}

}