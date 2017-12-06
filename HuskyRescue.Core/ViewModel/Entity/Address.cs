using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Address
	{
		public Guid ID { get; set; }

		public Guid EntityID { get; set; }

			/// <summary>
			/// If true then forces validation of specific properties
			/// </summary>
		public bool Validate { get; set; }

		public string AddressFull
		{
			get
			{
				return Street + ", " + City + ", " + StateID + ", " + ZIP;
			}
		}

		public string GoogleMapLink
		{
			get
			{
				return "https://maps.google.com/?q=" + Street + ", " + City + ", " + StateID + ", " + ZIP;
			}
		}

		//[RequiredIfTrue("Validate", ErrorMessage = "Street address is required")]
		[DisplayName("Street"), Required, DataType(DataType.Text), StringLength(80), FoundationAbidePattern("length_80")]
		public string Street { get; set; }

		[DisplayName("Street/Other"), DataType(DataType.Text), StringLength(80), FoundationAbidePattern("length_80")]
		public string Street2 { get; set; }

		//[RequiredIfTrue("Validate", ErrorMessage = "Address city is required")]
		[DisplayName("City"), Required, DataType(DataType.Text), StringLength(80), FoundationAbidePattern("length_80")]
		public string City { get; set; }

		[DisplayName("State"), Required]
		public string StateID { get; set; }

		//[RequiredIfTrue("Validate", ErrorMessage = "Address state is required")]
		[DisplayName("State"), Required]
		public IEnumerable<SelectListItem> AddressStateList { get; set; }

		//[RequiredIfTrue("Validate", ErrorMessage = "Address postal code is required")]
		[DisplayName("Postal code"), Required, DataType(DataType.Text), StringLength(10), FoundationAbidePattern("number")]
		public string ZIP { get; set; }

		[DisplayName("Type of address")]
		public string Type { get; set; }

		[DisplayName("Type of address")]
		public IEnumerable<SelectListItem> AddressTypeList { get; set; }

		public bool? ShowAddressTypeList { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Type">Default to 1 - Primary Address</param>
		public Address(string type = "1")
		{
			Validate = false;
			Type = type;
			AddressStateList = new List<SelectListItem>();
			AddressTypeList = new List<SelectListItem>();
			ShowAddressTypeList = false;
		}

		public Address()
		{
			Validate = false;
			Type = "1";
			AddressStateList = new List<SelectListItem>();
			AddressTypeList = new List<SelectListItem>();
			ShowAddressTypeList = false;
		}

		public override string ToString()
		{
			return AddressFull;
		}
	}
}