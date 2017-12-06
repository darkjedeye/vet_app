using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Attributes
{
	/// <summary>
	/// http://johan.driessen.se/posts/Updated-Anti-XSRF-Validation-for-ASP.NET-MVC-4-RC
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class ValidateJsonAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (filterContext == null)
			{
				throw new ArgumentNullException("filterContext");
			}

			var httpContext = filterContext.HttpContext;
			var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];

			// only make this check if this is an ajax request
			if ((httpContext.Request["X-Requested-With"] == "XMLHttpRequest") || ((httpContext.Request.Headers != null) && (httpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")))
			{
				AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
			}
		}
	}
}
