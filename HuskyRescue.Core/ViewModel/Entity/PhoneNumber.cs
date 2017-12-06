using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class PhoneNumber
	{
		public int ID { get; set; }

		public Guid EntityID { get; set; }

		/// <summary>
		/// If true then forces validation of specific properties
		/// </summary>
		public bool Validate { get; set; }

		/// <summary>
		/// type of phone number code
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// 0  	Unknown
		/// 1  	Home
		/// 2  	Work
		/// 3  	Mobile
		/// 4  	Fax
		/// 5  	Other
		/// </summary>
		public string TypeDesc
		{
			get
			{
				var desc = string.Empty;
				switch (Type.Trim())
				{
					case "0":
						desc = "Unknown";
						break;
					case "1":
						desc = "Home";
						break;
					case "2":
						desc = "Work";
						break;
					case "3":
						desc = "Mobile";
						break;
					case "4":
						desc = "Fax";
						break;
					case "5":
						desc = "Other";
						break;
				}
				return desc;
			}
		}

		[DisplayName("Phone Type")]
		public IEnumerable<SelectListItem> PhoneNumberTypeList { get; set; }

		//[RequiredIfTrue("Validate", ErrorMessage = "Phone number is required")]
		[DisplayName("Phone"), Required, DataType(DataType.PhoneNumber), StringLength(14), FoundationAbidePattern("phone", "Must be a phone number")]
		public string Number { get; set; }

		public PhoneNumber()
		{
			Validate = false;
			Type = "0";
			PhoneNumberTypeList = new List<SelectListItem>();
		}

		public PhoneNumber(string type = "0")
		{
			Validate = false;
			Type = type;
			PhoneNumberTypeList = new List<SelectListItem>();
		}
	}
}