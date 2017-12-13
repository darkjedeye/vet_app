using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;

namespace HuskyRescue.Core.ViewModel.Google
{
	public static class CalendarHelper
	{
		public static GDataCredentials Credentials { get; set; }
		public static string QueryUri { get; set; }

		public static CalendarService GetService(string applicationName)
		{
			return new CalendarService(applicationName) { Credentials = Credentials };
		}

		public static AtomEntryCollection GetAllEvents(CalendarService service, DateTime? startData, DateTime? endDate)
		{
			EventQuery query = new EventQuery(QueryUri);
			//query.Uri = new Uri("http://www.google.com/calendar/feeds/" + service.Credentials.Username + "/public/full");

			if (startData != null)
			{
				query.StartTime = startData.Value;
				query.RecurrenceStart = startData.Value;
			}
			if (endDate != null)
			{
				query.EndDate = endDate.Value;
				query.RecurrenceEnd = endDate.Value;
			}
			query.SortOrder = CalendarSortOrder.ascending;
			//query.SingleEvents = true;
			query.FutureEvents = true;
			query.NumberToRetrieve = 5;

			//query.NumberToRetrieve = 5;
			// Tell the service to query:
			EventFeed calFeed = service.Query(query);
			return ((AtomFeed)(calFeed)).Entries;
		}

		public static List<string> GetAgendaToLinks()
		{
			DateTime dt = new DateTime();
			dt = DateTime.Now;
			string userName = "eric@kleincore.co.za";
			string password = "Mundane2";
			string applicationName = "Agenda";

			CalendarHelper.Credentials = new GDataCredentials(userName, password);
			AtomEntryCollection feed = CalendarHelper.GetAllEvents(CalendarHelper.GetService(applicationName), DateTime.Now, DateTime.Now.AddDays(90));
			List<string> items = new List<string>();
			for (int x = 0; x < feed.Count; x++)
			{
				var e = feed[x];

				if (!String.IsNullOrEmpty(e.Title.Text))
				{
					CalendarEvent ar = new CalendarEvent();

					ar.Title = e.Title.Text;
					ar.URI = e.AlternateUri.Content;
					ar.Description = e.Content.Content;
					ExtensionCollection<When> v = ((EventEntry)(e)).Times;
					ar.StartTime = v[0].StartTime;
					ar.EndTime = v[0].EndTime;
					items.Add(ar.ToString());
				}
			}
			return items;
		}

		public static List<CalendarEvent> GetUpcomingCalendarEvents(int numberOfEvents = 5)
		{
			if (Credentials == null)
				Credentials = new GDataCredentials("eric@kleincore.co.za", "mundane2");
			if (QueryUri == null)
				QueryUri = "http://www.google.com/calendar/feeds/" + Credentials.Username + "/public/full";

			CalendarService service = new CalendarService("Agenda");
			EventQuery query = new EventQuery(QueryUri);
			query.FutureEvents = true;
			query.SingleEvents = true;
			query.SortOrder = CalendarSortOrder.ascending;
			query.NumberToRetrieve = numberOfEvents;
			query.ExtraParameters = "orderby=starttime";
			var events = service.Query(query);

			return (from e in events.Entries
					where !String.IsNullOrEmpty(e.Title.Text)
					select new CalendarEvent()
					{
						Title = e.Title.Text,
						URI = e.AlternateUri.Content,
						Description = e.Content.Content,
						StartTime = (e as EventEntry).Times[0].StartTime,
						EndTime = (e as EventEntry).Times[0].EndTime
					}).ToList<CalendarEvent>();
		}
	}
}
