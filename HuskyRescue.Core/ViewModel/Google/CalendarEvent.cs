using System;

namespace HuskyRescue.Core.ViewModel.Google
{
	public class CalendarEvent
	{
		public string Title { get; set; }
		public string URI { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public override string ToString()
		{
			return "<a href='" + URI + "' title='" + Description + "' >" + StartTime.ToShortDateString() + " " + StartTime.ToShortTimeString() + "-" + EndTime.ToShortTimeString() + " " + Title + "</a>";
		}
	}
}
