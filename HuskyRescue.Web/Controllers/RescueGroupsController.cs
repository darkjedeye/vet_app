using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
    public class RescueGroupsController : Controller
    {
        //
        // GET: /RescueGroups/

        public ActionResult Index()
        {
	        var animalHandler = new HuskyRescue.Core.Service.RescueGroups.AnimalHandler();
			var search = animalHandler.PublicSearch();

	        //var animal = animalHandler.GetProfile("5701512");

			return View(search);
        }

    }
}
