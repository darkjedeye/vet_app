using System;
using System.Web.Mvc;
using HuskyRescue.Web.Infrastructure;

namespace HuskyRescue.Web.Controllers
{
	public class BaseController : Controller
	{
		protected BaseController()
		{

		}

		public enum ContentType
		{
			Html = 0,
			Json = 1,
			Xml = 2
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected virtual string GetContentType()
		{
			var type = Request.QueryString["type"];

			if (!string.IsNullOrEmpty(type)) return type;

			if (Request.IsAjaxRequest())
				type = Request.Headers["Accept"].Contains("application/json")
					? "json"
					: "xml";
			else
				type = "html";

			return type;
		}

		/// <summary>
		/// This provides simple feedback to the model state in the case of errors.
		/// </summary>
		/// <param name="filterContext"></param>
		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.Result is RedirectToRouteResult)
			{
				try
				{
					// put the ModelState into TempData
					TempData.Add("_MODELSTATE", ModelState);
				}
				catch (Exception)
				{
					TempData.Clear();
					// swallow exception
				}
			}
			else if (filterContext.Result is ViewResult && TempData.ContainsKey("_MODELSTATE"))
			{
				// merge modelstate from TempData
				var modelState = TempData["_MODELSTATE"] as ModelStateDictionary;
				foreach (var item in modelState)
				{
					if (!ModelState.ContainsKey(item.Key))
						ModelState.Add(item);
				}
			}
			base.OnActionExecuted(filterContext);
		}
	}
}
