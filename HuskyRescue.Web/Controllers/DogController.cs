using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
	public class DogController : BaseController
	{
		public ActionResult Create()
		{
			return View();
		}

		public ActionResult Active()
		{
			return View();
		}

		public ActionResult InActive()
		{
			return View();
		}

		public ActionResult Medical()
		{
			return View();
		}
	}
}
