using System;
using HuskyRescue.Web.Properties;

namespace HuskyRescue.Web.Infrastructure.Extensions
{
	public static class DateTimeHelper
	{
		public static string ToConfigLocalTime(this DateTime utcDT)
		{
			var istTZ = TimeZoneInfo.FindSystemTimeZoneById(Settings.Default.TimeZone);
			return String.Format("{0} ({1})", TimeZoneInfo.ConvertTimeFromUtc(utcDT, istTZ).ToShortDateString(), Settings.Default.TimeZoneAbr);
		}
	}
}
