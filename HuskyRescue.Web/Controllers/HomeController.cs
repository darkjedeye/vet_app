using System.Web.Mvc;
using HuskyRescue.Core.ViewModel.Google;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	public class HomeController : BaseController
	{
		private readonly ILogger logger;
		
		public HomeController(ILogger logger)
		{
			this.logger = logger;
		}

		public ActionResult Index()
		{
			logger.Trace("/Home/Index (get) called"); 
			
			ViewBag.Message = "Welcome to Texas Husky Rescue, Inc!";

			TempData["reminders"] = CalendarHelper.GetUpcomingCalendarEvents();
			var prefix = ""; // HuskyRescue.Web.Properties.Settings.Default.ServerPrefix.ToString();
			TempData["serverprefix"] = string.IsNullOrEmpty(prefix) ? prefix : string.Empty;

			return View();
		}

		public ActionResult About()
		{
			logger.Trace("/Home/About (get) called");
			return View();
		}
	}
}
