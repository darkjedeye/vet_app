using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Base
	{
		public Guid ID { get; set; }

		public List<Address> Addresses { get; set; }

		public List<EmailAddress> EmailAddresses { get; set; }

		public List<PhoneNumber> PhoneNumbers { get; set; }

		public string PhoneNumberFormatted
		{
			get
			{
				var numbers = string.Empty;
				const string delimiter = "<br />";
				if (PhoneNumbers == null) return numbers;
				for (var x = 0; x < PhoneNumbers.Count; x++)
				{
					numbers += PhoneNumbers[x].TypeDesc + " - " + PhoneNumbers[x].Number;
					if (x < PhoneNumbers.Count - 1)
					{
						numbers += delimiter;
					}
				}

				return numbers;
			}
		}

		public string EmailAddressText
		{
			get
			{
				var numbers = string.Empty;
				const string delimiter = "<br />";
				if (EmailAddresses == null) return numbers;
				for (var x = 0; x < EmailAddresses.Count; x++)
				{
					numbers += EmailAddresses[x].TypeDesc + " - " + EmailAddresses[x].Address;
					if (x < EmailAddresses.Count - 1)
					{
						numbers += delimiter;
					}
				}

				return numbers;
			}
		}

		public string PrimaryAddressText
		{
			get
			{
				var address = string.Empty;

				if (Addresses == null) return address;
				if (Addresses.Count <= 0) return address;
				var s = Addresses.Single(a => a.Type.Trim().Equals("1")).AddressFull;
				if (!string.IsNullOrEmpty(s))
				{
					address = s;
				}
				return address;
			}
		}

		public string PrimaryAddressGoogleMapLink
		{
			get
			{
				var address = string.Empty;

				if (Addresses == null) return address;
				if (Addresses.Count <= 0) return address;
				var s = Addresses.Single(a => a.Type.Trim().Equals("1")).GoogleMapLink;
				if (!string.IsNullOrEmpty(s))
				{
					address = s;
				}
				return address;
			}
		}

		public static string TypeBusiness = "BUS";
		public static string TypePerson = "PER";

		/// <summary>
		/// Type of Entity: PER or BUS
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Active or not
		/// </summary>
		[DisplayName("Active?")]
		public bool IsActive { get; set; }

		/// <summary>
		/// indicator for deleted entities
		/// </summary>
		[DisplayName("Deleted?")]
		public bool IsDeleted { get; set; }

		[DisplayName("Mailable?")]
		public bool IsMailable { get; set; }

		[DisplayName("E-Mailable?")]
		public bool IsEmailable { get; set; }

		[DisplayName("Date activated"), DataType(DataType.Date), Required, FoundationAbidePattern("month_day_year"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? DateActive { get; private set; }

		//[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
		[DisplayName("Date de-activated"), DataType(DataType.Date), Required, FoundationAbidePattern("month_day_year")]
		public DateTime? DateInActive { get; private set; }

		[DisplayName("Comments"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string Comments { get; set; }

		public Base()
		{
			Type = "PER";
			Initialize();
		}

		public Base(string type = "PER")
		{
			Type = type;
			Initialize();
		}

		public void Initialize()
		{
			DateActive = DateTime.Today;
			IsActive = true;
			IsDeleted = false;
			IsEmailable = true;
			IsMailable = true;
			Addresses = new List<Address>();
			PhoneNumbers = new List<PhoneNumber>();
			EmailAddresses = new List<EmailAddress>();
		}

		/// <summary>
		/// Populate List of Address objects with "count" number
		/// </summary>
		/// <param name="count">Number of Address objects to add to the List</param>
		public void BuildAddresses(int count = 1)
		{
			Addresses = new List<Address>();
			for (var i = 0; i < count; i++)
			{
				this.Addresses.Add(new Address());
			}
		}

		public void BuildEmailAddresses(int count = 1)
		{
			EmailAddresses = new List<EmailAddress>();
			for (var i = 0; i < count; i++)
			{
				EmailAddresses.Add(new EmailAddress());
			}
		}

		public void BuildPhoneNumbers(int count = 1)
		{
			PhoneNumbers = new List<PhoneNumber>();
			for (var i = 0; i < count; i++)
			{
				PhoneNumbers.Add(new PhoneNumber());
			}
		}
	}
}