using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace HuskyRescue.Web.Infrastructure.Extensions
{
	public static class MenuLinkHelper
	{
		/// <summary>
		/// Extension method for <see cref="HtmlHelper"/> to support highlighting the active tab on the default MVC menu
		/// </summary>
		/// <param name="htmlHelper"></param>
		/// <param name="linkText">The text to display in the link</param>
		/// <param name="actionName">Link target action name</param>
		/// <param name="controllerName">Link target controller name</param>
		/// <param name="activeClass">The CSS class to apply to the link if active</param>
		/// <param name="checkAction">If true, checks the current action name to determine if the menu item is 'active', otherwise only the controller name is matched</param>
		/// <returns></returns>
		public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string activeClass, bool checkAction)
		{
			var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
			var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

			if (string.Compare(controllerName, currentController, StringComparison.OrdinalIgnoreCase) == 0 && 
				((!checkAction) || string.Compare(actionName, currentAction, StringComparison.OrdinalIgnoreCase) == 0))
			{
				return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = activeClass });
			}

			return htmlHelper.ActionLink(linkText, actionName, controllerName);
		}

		public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string activeClass)
		{
			return MenuLink(htmlHelper, linkText, actionName, controllerName, activeClass, true);
		}

		public static MvcHtmlString MenuBuilder(this HtmlHelper htmlHelper, List<AdminSideMenu> adminSideMenus)
		{
			if(adminSideMenus.Count == 0 ) return new MvcHtmlString(string.Empty);

			var menuHtml = adminSideMenus.Aggregate(string.Empty, (current, menu) => current + menu.ToString());

			return new MvcHtmlString(menuHtml);
		}

	}
}
