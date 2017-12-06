using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Contact
	{
		public static List<ContactReason> PopulateContactReasons(List<ContactReason> Reasons)
		{
			Reasons.Add(new ContactReason("", ""));
			Reasons.Add(new ContactReason("1", "Adoption related"));
			Reasons.Add(new ContactReason("2", "Surrendering a Dog"));
			Reasons.Add(new ContactReason("3", "Found a stray husky"));
			Reasons.Add(new ContactReason("4", "Volunteer"));
			Reasons.Add(new ContactReason("5", "Event Information"));
			Reasons.Add(new ContactReason("6", "General Question"));
			return Reasons;
		}

		public Contact()
		{
			ContactReasonList = new List<SelectListItem>();

			var Reasons = new List<ContactReason>();
			ContactReasonList = PopulateContactReasons(Reasons).ToSelectListItems("");
		}

		[DisplayName("First Name"), DataType(DataType.Text), Required, StringLength(100), FoundationAbidePattern("length_100")]
		public string NameFirst { get; set; }

		[DisplayName("Last Name"), DataType(DataType.Text), Required, StringLength(100), FoundationAbidePattern("length_100")]
		public string NameLast { get; set; }

		[DisplayName("Email Address"), DataType(DataType.EmailAddress), Required, StringLength(200), FoundationAbidePattern("length_200")]
		public string EmailAddress { get; set; }

		[DisplayName("Phone Number"), DataType(DataType.PhoneNumber), StringLength(14), FoundationAbidePattern("phone", "Must be a phone number")]
		public string Number { get; set; }

		[DisplayName("Message to Texas Husky Rescue"), DataType(DataType.MultilineText), Required, StringLength(4000), FoundationAbidePattern("length_4000")]
		public string Message { get; set; }

		[DisplayName("Contact Reason"), Required]
		public IEnumerable<SelectListItem> ContactReasonList { get; set; }

		public string ContactReasonID { get; set; }
	}

	public class ContactReason
	{
		public string Reason { get; set; }
		public string ID { get; set; }

		public ContactReason(string id, string reason)
		{
			Reason = reason;
			ID = id;
		}
	}
}
