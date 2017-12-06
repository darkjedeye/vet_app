using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Fabrik.Common;
using HuskyRescue.Core.Service.Enum;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Extensions;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Business
	{
		public Guid ID { get; set; }

		public Guid BaseID { get; set; }

		public Base Base { get; set; }

		[DisplayName("Name"), DataType(DataType.Text), StringLength(50), Required(ErrorMessage = "Business name required", AllowEmptyStrings = false), FoundationAbidePattern("length_50")]
		public string BusinessName { get; set; }

		[DisplayName("Contact name"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string ContactName { get; set; }

		[DisplayName("Contact title"), DataType(DataType.Text), StringLength(30), FoundationAbidePattern("length_30")]
		public string ContactTitle { get; set; }

		[DisplayName("EIN"), DataType(DataType.Text), StringLength(10), FoundationAbidePattern("length_10")]
		public string EIN { get; set; }

		[DisplayName("Business Type")]
		public string TypeBusiness { get; set; }
		public IEnumerable<SelectListItem> TypeBusinessList { get; set; }

		[DisplayName("Description/Notes/Comments"), DataType(DataType.MultilineText)]
		public string Description { get; set; }

		public Business()
		{
			TypeBusinessList = new List<SelectListItem>();
			this.Base = new Base("BUS");
		}

		public void Setup(bool isNew)
		{
			var businessTypeHandler = new BusinessTypeHandler();
			var usaStatesHandler = new UsaStatesHandler();
			var streetAddressTypeHandler = new StreetAddressTypeHandler();
			var emailTypeHandler = new EmailTypeHandler();
			var phoneNumberTypeHandler = new PhoneNumberTypeHandler();

			var emailTypes = emailTypeHandler.ReadAll();
			var phoneNumberTypes = phoneNumberTypeHandler.ReadAll();

			TypeBusinessList = businessTypeHandler.ReadAll().ToSelectListItems(TypeBusiness.IsNullOrEmpty() ? "" : TypeBusiness);

			if (isNew || Base.Addresses.Count == 0)
			{
				// add one default address
				Base.BuildAddresses();
			}
			foreach (var address in Base.Addresses)
			{
				address.AddressStateList = usaStatesHandler.ReadAll().ToSelectListItems(address.StateID.IsNullOrEmpty() ? "TX" : address.StateID);
				//primary
				address.AddressTypeList = streetAddressTypeHandler.ReadAll().ToSelectListItems(address.Type.IsNullOrEmpty() ? "1" : address.Type);
			}

			if (isNew || Base.EmailAddresses.Count == 0)
			{
				// add two default email addresses
				Base.BuildEmailAddresses(2);
				//work
				Base.EmailAddresses[0].EmailTypeList = emailTypes.ToSelectListItems("2");
				//other
				Base.EmailAddresses[1].EmailTypeList = emailTypes.ToSelectListItems("4");
			}
			else
			{
				foreach (var email in Base.EmailAddresses)
				{
					email.EmailTypeList = emailTypes.ToSelectListItems(email.Type);
				}
			}
			if (isNew || Base.PhoneNumbers.Count == 0)
			{
				// add three default phone numbers
				Base.BuildPhoneNumbers(3);

				//work
				Base.PhoneNumbers[0].PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems("2");
				//mobile
				Base.PhoneNumbers[1].PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems("3");
				//fax
				Base.PhoneNumbers[2].PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems("4");
			}
			else
			{
				foreach (var phone in Base.PhoneNumbers)
				{
					phone.PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems(phone.Type);
				}
			}
		}
	}
}