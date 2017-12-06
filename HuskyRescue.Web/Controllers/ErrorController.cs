using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace AnimalRescue.Web.Controllers
{
	[OutputCache(Location = OutputCacheLocation.None)]
	public class ErrorController : BaseController
	{
		public ActionResult HttpError()
		{
			Exception ex = null;

			try
			{
				ex = (Exception)HttpContext.Application[Request.UserHostAddress.ToString()];
			}
			catch
			{
			}

			if (ex != null)
			{
				ViewData["Description"] = ex.Message;
			}
			else
			{
				ViewData["Description"] = "An error occurred.";
			}

			ViewData["Title"] = "Oops. Sorry. An error occurred and the website admin has been notified.";
			Response.StatusCode = 500;
			Response.TrySkipIisCustomErrors = true;
			return View("Http500");
		}

		public ActionResult Http404()
		{
			ViewData["Title"] = "The page you requested was not found";
			ViewData["Description"] = "An error occurred.";
			Response.StatusCode = 404;
			Response.TrySkipIisCustomErrors = true;
			return View();
		}

		public ActionResult Http500()
		{
			try
			{
				ViewData["Title"] = "The page you requested was not found";
				ViewData["Description"] = "An error occurred.";
				Response.StatusCode = 500;
			}
			catch
			{
			}
			Response.TrySkipIisCustomErrors = true;

			return View();
		}

		public ActionResult Index()
		{
			string message = string.Empty;
			string type = string.Empty;
			try
			{
				var ex = HttpContext.Application[Request.UserHostAddress.ToString()];

				if (ex != null)
				{
					switch(ex.GetType().ToString())
					{
						case "System.Web.HttpException":
							var webEx = (System.Web.HttpException)ex;
							message = webEx.Message;
							type = "System.Web.HttpException";
							Response.StatusCode = webEx.GetHttpCode();
							break;

						case "System.ApplicationException":
							var appEx = (System.ApplicationException)ex;
							message = appEx.Message;
							type = "System.ApplicationException";
							Response.StatusCode = 500;
							break;
						default:
							var sysEx = (System.Exception)ex;
							message = sysEx.Message;
							type = "System.Exception";
							Response.StatusCode = 500;
							break;
					}
				}
			}
			catch
			{
				ViewData["Description"] = "Default Error";
				ViewData["Type"] = "Unkown";
			}
			ViewData["Description"] = message;
			ViewData["Type"] = type;
			ViewData["Title"] = "Sorry, an error occurred and the website admin has been notified.";
			Response.TrySkipIisCustomErrors = true;
			
			return View();
		}


		public ActionResult Log()
		{
			TempData["logfile"] = System.IO.File.ReadAllText(AnimalRescue.Utilities.Properties.Settings.Default.LogErrorFile);
			return View();
		}
	}
}
