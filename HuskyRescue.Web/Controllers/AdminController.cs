using System.Web.Mvc;
using HuskyRescue.Core.Service;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	[Authorize(Roles = "Administrator,Staff")]
    public class AdminController : Controller
    {
		private readonly RescueCountHandler _rescueCountHandler = new RescueCountHandler();
		private readonly ILogger _logger;
		public AdminController(ILogger logger)
		{
			_logger = logger;
		}
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult RescueCount()
		{
			TempData["CurrentCount"] = _rescueCountHandler.Count;
			return View();
		}

		[HttpPost]
		public ActionResult UpdateCount(string Count)
		{
			RescueCountHandler.SetCount(Count);

			if (Request.IsAjaxRequest())
			{
				var result = new { RescueCount = _rescueCountHandler.Count };
				return Json(result, JsonRequestBehavior.AllowGet);
			}
			return RedirectToAction("Index");
		}

		public ActionResult MemberInfo()
		{
			return View();
		}

		public ActionResult ContactInfo()
		{
			return View();
		}

		public ActionResult OrgChart()
		{
			return View();
		}
    }
}
