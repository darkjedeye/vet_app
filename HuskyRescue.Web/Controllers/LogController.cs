using System;
using System.Web.Mvc;
using HuskyRescue.Core.Service.Logging;
using HuskyRescue.Web.Infrastructure;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	[Authorize]
	public class LogController : BaseController
	{
		private readonly LogHandler _logHandler = new LogHandler();
		private readonly ILogger _logger;
		public LogController(ILogger logger)
		{
			_logger = logger;
		}

		//
		// GET: /Log/

		public ActionResult Index()
		{
			_logger.Trace("/Log/Index called");

			return View();
		}

		public ActionResult GetLog()
		{
			var jsonNetResult = new JsonNetResult {Data = _logHandler.ReadAll()};

			return jsonNetResult;

		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			var jsonNetResult = new JsonNetResult();
			try
			{
				// "Delete" from database
				_logHandler.Delete(id);

				jsonNetResult.Data = new { Result = "OK" };

				return jsonNetResult;
			}
			catch (Exception ex)
			{
				jsonNetResult.Data = new { Result = "ERROR", ex.Message };

				return jsonNetResult;
			}
		}
	}
}
