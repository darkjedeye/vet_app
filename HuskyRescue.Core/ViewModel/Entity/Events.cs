using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Event
	{
		public Guid Id { get; set; }

		public IEnumerable<SelectListItem> Locations { get; set; }
		[DisplayName("Location of the event"), Required]
		public Guid? BusinessId { get; set; }

		public List<EventRegistration> Registrations { get; set; }

		public List<EventSponsor> Sponsors { get; set; }

		public Business Business { get; set; }

		[DisplayName("Date of the event"), DataType(DataType.Date), Required, FoundationAbidePattern("month_day_year")]
		public DateTime DateOfEvent { get; set; }

		[DisplayName("Active?"), Required]
		public bool IsActive { get; set; }

		[DisplayName("Name"), DataType(DataType.Text), Required, StringLength(255), FoundationAbidePattern("length_255")]
		public string Name { get; set; }

		[DisplayName("Purpose"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string Purpose { get; set; }

		[DisplayName("Results"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string Results { get; set; }

		[DisplayName("Notes"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string Description { get; set; }

		[DisplayName("Starting time (HH:MM:SS)"), DataType(DataType.Time), FoundationAbidePattern("time")]
		public DateTime? StartTime { get; set; }

		[DisplayName("Ending time (HH:MM:SS)"), DataType(DataType.Time), FoundationAbidePattern("time")]
		public DateTime? EndTime { get; set; }

		[DisplayName("All day?")]
		public bool? IsAllDay { get; set; }

		[DisplayName("Total money spent"), DataType(DataType.Currency), FoundationAbidePattern("number")]
		public Decimal? AmountSpent { get; set; }

		[DisplayName("Total money received"), DataType(DataType.Currency), FoundationAbidePattern("number")]
		public Decimal? AmountReceived { get; set; }

		public String Type { get; set; }

		[DisplayName("Are tickets sold for this event?")]
		public Boolean? IsTicketsSold { get; set; }

		[DisplayName("Price per ticket")]
		public Decimal? TicketPrice { get; set; }

		[DisplayName("Is this the active golf tourney?")]
		public Boolean IsActiveGolfEvent { get; set; }

		[DisplayName("Is this the active RoughRiders event?")]
		public Boolean IsActiveRoughRidersEvent { get; set; }

		[DisplayName("Is this the active Raffle?")]
		public Boolean IsActiveRaffle { get; set; }

		public Event()
		{
			DateOfEvent = DateTime.Now;
			Locations = new List<SelectListItem>();
			IsActive = true;
			Type = "OTH";
			Registrations = new List<EventRegistration>();
			Sponsors = new List<EventSponsor>();
			Business = new Business();

			IsActiveGolfEvent = false;
			IsActiveRoughRidersEvent = false;
			IsActiveRaffle = false;
		}
	}
}