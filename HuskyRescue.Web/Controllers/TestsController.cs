using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
    public class TestsController : BaseController
    {
		private readonly ILogger logger;
		public TestsController(ILogger logger)
		{
			this.logger = logger;
		}
        //
        // GET: /Tests/

        public ActionResult Index()
        {

			try
			{
				throw new System.ArgumentException("Parameter cannot be null", "original");
			}
			catch (Exception ex)
			{
				logger.Error("Error in Tests/Index", ex);
			}

            return View();
        }

		public ActionResult At()
		{
			throw new Exception("Exception thrown");
		}
        
    }
}
