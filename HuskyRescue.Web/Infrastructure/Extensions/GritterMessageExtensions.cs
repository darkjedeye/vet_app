using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace HuskyRescue.Web.Infrastructure.Extensions
{
	internal static class GritterMessageExtensions
	{
		private const string NewLine = "<br />";

		public static ActionResult Error(this ActionResult result, List<string> messageList )
		{
			return Error(result, string.Join<string>(NewLine, messageList));
		}

		public static ActionResult Error(this ActionResult result, string message)
		{
			CreateCookieWithGritterMessage(Notification.Error, message);
			return result;
		}

		public static ActionResult Warning(this ActionResult result, List<string> messageList)
		{
			return Warning(result, string.Join<string>(NewLine, messageList));
		}

		public static ActionResult Warning(this ActionResult result, string message)
		{
			CreateCookieWithGritterMessage(Notification.Warning, message);
			return result;
		}

		public static ActionResult Success(this ActionResult result, List<string> messageList)
		{
			return Success(result, string.Join<string>(NewLine, messageList));
		}

		public static ActionResult Success(this ActionResult result, string message)
		{
			CreateCookieWithGritterMessage(Notification.Success, message);
			return result;
		}

		public static ActionResult Information(this ActionResult result, List<string> messageList)
		{
			return Information(result, string.Join<string>(NewLine, messageList));
		}

		public static ActionResult Information(this ActionResult result, string message)
		{
			CreateCookieWithGritterMessage(Notification.Info, message);
			return result;
		}

		private static void CreateCookieWithGritterMessage(Notification notification, string message)
		{
			HttpContext.Current.Response.Cookies.Add(new HttpCookie(string.Format("Gritter.{0}", notification), message) { Path = "/" });
		}

		private enum Notification
		{
			Error,
			Warning,
			Success,
			Info
		}
	}
}