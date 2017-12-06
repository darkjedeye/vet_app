using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace HuskyRescue.Web.Infrastructure
{
	public class AdminSideMenu
	{
		public AdminSideMenu(HtmlHelper htmlHelper, string menuTitleText, string icon, bool isLink = false, string controller = "", string action = "", bool isActive = false, bool isFirstMenuItem = false)
		{
			Html = htmlHelper;
			AdminSideMenuItems = new List<AdminSideMenuItem>();
			MenuTitleText = menuTitleText;
			IsActive = isActive;
			IsLink = isLink;
			Controller = controller;
			Action = action;
			Icon = icon;
			IsFirstMenuItem = isFirstMenuItem;
		}

		public AdminSideMenu(HtmlHelper htmlHelper, string menuTitleText, string icon, List<AdminSideMenuItem> adminSideMenuItems, bool isLink = false, string controller = "", string action = "", bool isActive = false)
		{
			Html = htmlHelper;
			AdminSideMenuItems = new List<AdminSideMenuItem>();
			AdminSideMenuItems = adminSideMenuItems;
			MenuTitleText = menuTitleText;
			IsActive = isActive;
			IsLink = isLink;
			Controller = controller;
			Action = action;
			Icon = icon;
		}

		public string MenuTitleText { get; set; }
		public bool IsActive { get; set; }
		public bool IsFirstMenuItem { get; set; }
		public bool IsLink { get; set; }
		public string Controller { get; set; }
		public string Action { get; set; }
		public string Icon { get; set; }
		public List<AdminSideMenuItem> AdminSideMenuItems { get; set; }
		public HtmlHelper Html { get; set; }

		public override string ToString()
		{
			var currentAction = Html.ViewContext.RouteData.GetRequiredString("action");
			var currentController = Html.ViewContext.RouteData.GetRequiredString("controller");

			// scan sub menu items to determine if one of them is the active menu item and use that info to set the parent menu item active
			var subIndex =
				AdminSideMenuItems.FindIndex(
					a => string.Compare(a.Controller, currentController, StringComparison.OrdinalIgnoreCase) == 0 &&
					     (string.Compare(a.Action, currentAction, StringComparison.OrdinalIgnoreCase) == 0));

			var ddSection = new TagBuilder("dd");

			// if this is the first menu item mark it with class "start"
			if (IsFirstMenuItem)
			{
				ddSection.AddCssClass("start");
			}

			// if the current requested page (controller/action) is the same as the menu item 
			// OR the menu item has a sub-menu item with matching controller/action 
			// then set ddSection to active (red main menu)
			var isActive = false;
			if ((string.Compare(Controller, currentController, StringComparison.OrdinalIgnoreCase) == 0 &&
			     (string.Compare(Action, currentAction, StringComparison.OrdinalIgnoreCase) == 0))
			    || subIndex > -1)
			{
				//ddSection.AddCssClass("open");
				ddSection.AddCssClass("active");
				isActive = true;
			}

			var linkParent = new TagBuilder("a");
			if (IsLink)
			{
				linkParent.Attributes.Add("href", "/" + Controller + "/" + Action);
			}
			else
			{
				linkParent.Attributes.Add("href", "#" + MenuTitleText.Replace(" ", ""));
			}

			var icon = new TagBuilder("i");
			icon.AddCssClass(Icon);

			var spanTitle = new TagBuilder("span");
			spanTitle.AddCssClass("title");
			spanTitle.InnerHtml = MenuTitleText;

			var spanArrow = new TagBuilder("span");
			spanArrow.AddCssClass("arrow");
			// if active menu and it has submenu items
			if (subIndex > -1 && AdminSideMenuItems.Count > 0)
			{
				spanArrow.AddCssClass("open");
			}

			var spanSelected = new TagBuilder("span");
			spanSelected.AddCssClass("selected");

			linkParent.InnerHtml = icon + spanTitle.ToString();
			// do not put the "arrow" span on menu items without submenus
			if (AdminSideMenuItems.Count > 0)
			{
				linkParent.InnerHtml += spanArrow.ToString();
			}
			if (subIndex > -1)
			{
				linkParent.InnerHtml += spanSelected.ToString();
			}

			ddSection.InnerHtml = linkParent.ToString();

			// add submenu items
			if (AdminSideMenuItems.Count > 0)
			{
				var div = new TagBuilder("div");
				div.AddCssClass("content");
				div.Attributes.Add("id", MenuTitleText.Replace(" ", ""));
				if (isActive)
				{
					div.AddCssClass("active");
				}

				var unorderedList = new TagBuilder("ul");
				unorderedList.AddCssClass("side-nav sub-menu");

				foreach (var item in AdminSideMenuItems)
				{
					unorderedList.InnerHtml += item.ToString();
				}
				div.InnerHtml = unorderedList.ToString();

				ddSection.InnerHtml += div.ToString();
			}

			return ddSection.ToString();
		}
	}

	public class AdminSideMenuItem
	{
		public AdminSideMenuItem(HtmlHelper htmlHelper, string linkText, string controller, string action, bool isActive = false)
		{
			Html = htmlHelper;
			LinkText = linkText;
			Controller = controller;
			Action = action;
			IsActive = isActive;
			ActionClass = "active";
		}

		public string LinkText { get; set; }
		public string Controller { get; set; }
		public string Action { get; set; }
		public bool IsActive { get; set; }
		public string ActionClass { get; set; }
		public HtmlHelper Html { get; set; }

		public override string ToString()
		{
			var currentAction = Html.ViewContext.RouteData.GetRequiredString("action");
			var currentController = Html.ViewContext.RouteData.GetRequiredString("controller");

			var listItem = new TagBuilder("li");

			// check if this is the active page
			if (string.Compare(Controller, currentController, StringComparison.OrdinalIgnoreCase) == 0 &&
				(string.Compare(Action, currentAction, StringComparison.OrdinalIgnoreCase) == 0))
			{
				listItem.AddCssClass("active");
			}

			listItem.InnerHtml = Html.ActionLink(LinkText, Action, Controller, null, new { @class = ActionClass }).ToString();

			return listItem.ToString();
		}
	}
}

/*
	<dd class="">
		<a href="/Admin/Index">
			<i class="icon-home"></i>
			<span class="title">Dashboard</span>
		</a>
	</dd>
	<dd class="active">
		<a href="javascript:;">
			<i class="icon-info"></i>
			<span class="title">General Information</span>
			<span class="arrow"></span>
		</a>
		<div class="content">
			<ul class="side-nav sub-menu">
				<li class="active">
					@Html.ActionLink("Contact Information", "ContactInfo", "Admin")
				</li>
				<li>
					@Html.ActionLink("Member Information", "MemberInfo", "Admin")
				</li>
			</ul>
		</div>
	</dd>
 */
