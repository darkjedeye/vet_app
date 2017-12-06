using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class EventSponsor
	{
		public EventSponsor()
		{
			SponsorshipLevelsSelectList = new List<SelectListItem>();
			People = new List<SelectListItem>();
			Businesses = new List<SelectListItem>();
			IsDonating = false;
			IsDonationReceived = false;
			IsSingageComplete = false;
			IsSponsoring = false;
			HasLogoBeenReceived = false;
			Comments = string.Empty;
		}

		public Guid Id { get; set; }

		public Guid EventId { get; set; }

		public Guid BusinessId { get; set; }

		public Guid PersonId { get; set; }

		public List<DonationItems> DonationItems { get; set; }

		public Event Event { get; set; }

		public Person Person { get; set; }

		public Business Business { get; set; }

		public List<EventSponsorshipLevel> SponsorshipLevels { get; set; }

		[DisplayName("Date added to database")]
		[DataType(DataType.Date)]
		[DisplayFormat(NullDisplayText = "Not Available")]
		[ReadOnly(true)]
		public DateTime DateAdded { get; set; }

		[DisplayName("Sponsor?")]
		public bool IsSponsoring { get; set; }

		[DisplayName("Donating (cash or goods)?")]
		public bool IsDonating { get; set; }

		[DisplayName("Has the donation been received?")]
		public bool IsDonationReceived { get; set; }

		[DisplayName("Is the singage complete?")]
		public bool IsSingageComplete { get; set; }

		[DisplayName("Has the company logo been received?")]
		public bool HasLogoBeenReceived { get; set; }

		[HiddenInput(DisplayValue = false)]
		public int SponsorshipLevel { get; set; }

		[DisplayName("Sponsorship Level")]
		public List<SelectListItem> SponsorshipLevelsSelectList { get; set; }

		[DisplayName("Amount of money donated: ")]
		[DataType(DataType.Currency)]
		public Decimal? DonationAmount { get; set; }

		[DisplayName("Comments/Notes")]
		[DataType(DataType.MultilineText)]
		[AllowHtml()]
		public string Comments { get; set; }

		[DisplayName("Sponsoring Person")]
		public List<SelectListItem> People { get; set; }

		[DisplayName("Sponsoring Organization")]
		public List<SelectListItem> Businesses { get; set; }

		[DisplayName("Event to sponsor")]
		public List<SelectListItem> EventList { get; set; }
	}
}