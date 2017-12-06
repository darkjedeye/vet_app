using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Payments;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class EventRegistration
	{
		public PaymentInformation PayInfo { get; set; }

		public Guid Id { get; set; }
		public Guid EventId { get; set; }

		public List<EventAttendee> Attendees { get; set; }

		public string RegistrationDescription
		{
			get
			{
				var description = new StringBuilder();
				foreach (var a in Attendees)
				{
					description.AppendLine(a.Person.FullName);
					description.AppendLine(a.Person.Base.Addresses[0].AddressFull);
					
					if (a.Person.Base.EmailAddresses.Count > 0)
					{
						if (!string.IsNullOrEmpty(a.Person.Base.EmailAddresses[0].Address))
						{
							description.AppendLine(a.Person.Base.EmailAddresses[0].Address);
						}
					}
					if (a.Person.Base.PhoneNumbers.Count > 0)
					{
						if (!string.IsNullOrEmpty(a.Person.Base.PhoneNumbers[0].Number))
						{
							description.AppendLine(a.Person.Base.PhoneNumbers[0].Number);
						}
					}
					description.AppendLine();
				}
				description.AppendFormat("{0} tickets purchased.", TicketsBought);
				return description.ToString();
			}
		}

		public Event Event { get; set; }

		[DisplayName("Date submitted"), DataType(DataType.Date), Required, FoundationAbidePattern("month_day_year")]
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

		public IEnumerable<SelectListItem> ListPlayerCount { get; set; }

		[DisplayName("Number of Golfers"), Required, FoundationAbidePattern("number")]
		public int intListPlayerCount { get; set; }

		public int PlayerCount
		{
			get
			{
				return Attendees != null ? Attendees.Count : 0;
			}
			set
			{
				value = Attendees != null ? Attendees.Count : 0;
			}
		}

		[DisplayName("Comments/Notes"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string Comments { get; set; }

		[DisplayName("Amount paid"), DataType(DataType.Currency), FoundationAbidePattern("number")]
		public decimal AmountPaid { get; set; }

		[DisplayName("Amount due"), DataType(DataType.Currency), FoundationAbidePattern("number")]
		public decimal AmountDue
		{
			get
			{
				decimal ticketPrice = 0;
				if (Event != null)
				{
					if (Event.TicketPrice != null)
					{
						ticketPrice = Event.TicketPrice.Value;
					}
				}
				if (Event != null && ticketPrice != 0) return (decimal)(TicketsBought * ticketPrice);
				var eventHandler = new HuskyRescue.Core.Service.Entity.EventHandler();
				try
				{
					var eventTemp = eventHandler.ReadOne(EventId);
					ticketPrice = eventTemp.TicketPrice != null ? eventTemp.TicketPrice.Value : 0;
				}
				catch
				{
					// TODO: log error
					ticketPrice = 0;
				}
				return (decimal)(TicketsBought * ticketPrice);
			}
		}

		[DisplayName("Number of tickets purchased"), FoundationAbidePattern("integer")]
		public int? TicketsBought { get; set; }

		[DisplayName("Payment processor transaction id"), StringLength(50), DataType(DataType.Text)]
		public string PaymentTransactionId { get; set; }

		public EventRegistration()
		{
			PaymentMethod = 0;
			DateSubmitted = DateTime.Now;
			BuildListPlayers();

			PayInfo = new PaymentInformation();

			PopulatePaymentMethods();
		}

		public EventRegistration(Event eventVm)
		{
			Event = eventVm;
			EventId = eventVm.Id;

			PayInfo = new PaymentInformation();

			DateSubmitted = DateTime.Now;
			BuildListPlayers();
		}

		public void PopulatePaymentMethods()
		{
			ListPaymentMethod = new List<SelectListItem>()
			{
				//new SelectListItem() { Text="", Value="0", Selected=true},
				new SelectListItem() { Text="Google", Value="1"},
				new SelectListItem() { Text="PayPal", Value="2"},
				new SelectListItem() { Text="Square", Value="3"},
				new SelectListItem() { Text="Check", Value="4"},
				new SelectListItem() { Text="Cash", Value="5"},
				new SelectListItem() { Text="Credit Card", Value="6"}
			};
		}

		public void BuildAttendees(int count = 4)
		{
			this.Attendees = new List<EventAttendee>();
			for (var i = 0; i < count; i++)
			{
				var e = new EventAttendee { Person = new Person() };
				if (i == 0) e.IsPrimaryContact = true;
				e.Person.Base.BuildAddresses();
				e.Person.Base.BuildEmailAddresses();
				e.Person.Base.BuildPhoneNumbers();
				e.PlayerNumber = i + 1;
				Attendees.Add(e);
			}
		}

		public void BuildListPlayers()
		{
			ListPlayerCount = new List<SelectListItem>() {
						 new SelectListItem() { Text="1", Value="1"},
						 new SelectListItem() { Text="2", Value="2"},
						 new SelectListItem() { Text="3", Value="3"},
						 new SelectListItem() { Text="4", Value="4", Selected=true}
			};
		}
	}
}