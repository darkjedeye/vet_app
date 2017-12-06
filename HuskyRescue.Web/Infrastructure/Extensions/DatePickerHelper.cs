using System.Web.Mvc;

namespace HuskyRescue.Web.Infrastructure.Extensions
{
	public static class DatePickerHelper
	{
		public static string DatePicker(this HtmlHelper htmlHelper, string name, string value)
		{

			return "<script type=\"text/javascript\">" +
					 "$(function() {" +
					 "$(\"#" + name + "\").datepicker();" +
					 "});" +
					 "</script>" +
					 "<input type=\"text\" size=\"10\" value=\"" + value + "\" id=\"" + name + "\" name=\"" + name + "\"/>";
		}
	}
}
