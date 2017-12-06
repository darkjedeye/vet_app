using System;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class EventAttendee
	{
		public int PlayerNumber { get; set; }

		/// <summary>
		/// Used to drive JS code for showing the entry on the screen
		/// </summary>
		public string PlayerLabel
		{
			get
			{
				return "PlayerNumber" + PlayerNumber.ToString();
			}
		}

		public Guid EventRegistrationId { get; set; }

		public Guid PersonId { get; set; }

		public Guid Id { get; set; }

		public Person Person { get; set; }

		public EventRegistration EventRegistration { get; set; }

		[DisplayName("Is this the primary contact?")]
		public bool IsPrimaryContact { get; set; }

		[DisplayName("Type of attendee")]
		public int AttendeeType {get;set;}

		/// <summary>
		/// true if this person paid for the event registration
		/// </summary>
		public bool IsPayer { get; set; }

		public EventAttendee()
		{
			IsPrimaryContact = false;
			AttendeeType = 0;
		}

		public EventAttendee(int attendeeType = 0, bool primary = false)
		{
			IsPrimaryContact = primary;
			AttendeeType = attendeeType;
		}
	}
}