using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class EventRoughRiders
	{
		public Guid Id { get; set; }
		public Guid EventId { get; set; }

		public List<EventAttendee> Attendees { get; set; }

		[DisplayName("Date Submitted")]
		[DataType(DataType.Date)]
		public DateTime DateSubmitted { get; set; }

		[DisplayName("Has the registrant paid?")]
		public bool? HasPaid { get; set; }

		public int PaymentMethod { get; set; }

		[DisplayName("Payment Method")]
		public List<SelectListItem> ListPaymentMethod { get; set; }

		[DisplayName("Payment Method")]
		public string PaymentMethodText
		{
			get
			{
				var text = "unknown";

				//make sure the list is populated
				if (ListPaymentMethod.Count(l => l != null) > 0)
				{
					text = ListPaymentMethod.Single(l => l.Value == PaymentMethod.ToString()).Text;
				}
				return text;
			}
		}

		[DisplayName("Number of Golfers")]
		[Required(ErrorMessage = "You must select the number of golfers")]
		public IEnumerable<SelectListItem> ListPlayerCount { get; set; }

		public int PlayerCount {
			get {
				return Attendees != null ? Attendees.Count : 0;
			}
			set {
				value = Attendees != null ? Attendees.Count : 0;
			}
		}

		public string Comments { get; set; }

		[DisplayName("Amount Paid")]
		public decimal AmountPaid { get; set; }

		[DisplayName("Number of tickets?")]
		public int? TicketsBought { get; set; }

		public EventRoughRiders()
		{
			this.PaymentMethod = 0;
			this.DateSubmitted = DateTime.Now;

			this.ListPaymentMethod = new List<SelectListItem>()
			{
				new SelectListItem() { Text="", Value="0"},
				new SelectListItem() { Text="Google", Value="1"},
				new SelectListItem() { Text="PayPal", Value="2"},
				new SelectListItem() { Text="Check", Value="4"}
			};
		}

		public void BuildAttendees(int count = 4)
		{
			this.Attendees = new List<EventAttendee>();
			for (var i = 0; i < count; i++)
			{
				var e = new EventAttendee {Person = new Person()};
				if (i == 0) e.IsPrimaryContact = true;
				e.Person.Base.BuildAddresses();
				e.Person.Base.BuildEmailAddresses();
				e.Person.Base.BuildPhoneNumbers();
				e.PlayerNumber = i + 1;
				Attendees.Add(e);
			}
		}
	}
}