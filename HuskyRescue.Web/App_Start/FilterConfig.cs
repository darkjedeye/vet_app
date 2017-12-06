using System.Web.Mvc;
using NLog.Mvc;


namespace HuskyRescue.Web
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			var logger = DependencyResolver.Current.GetService<ILogger>();
			filters.Add(new NLogMvcHandleErrorAttribute(logger));
		}
	}
}