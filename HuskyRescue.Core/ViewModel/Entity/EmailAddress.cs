using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class EmailAddress
	{
		public int ID { get; set; }

		public Guid EntityID { get; set; }

		/// <summary>
		/// If true then forces validation of specific properties
		/// </summary>
		public bool Validate { get; set; }

		/// <summary>
		/// type of email address code
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// 0  	Unknown
		/// 1  	Home
		/// 2  	Work
		/// 3  	School
		/// 4  	Other
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
						desc = "School";
						break;
					case "4":
						desc = "Other";
						break;
				}
				return desc;
			}
		}

		[DisplayName("Email Type")]
		public IEnumerable<SelectListItem> EmailTypeList { get; set; }

		//[RequiredIfTrue("Validate", ErrorMessage = "Email address is required")]
		[DisplayName("Email"), Required, DataType(DataType.EmailAddress), StringLength(200), FoundationAbidePattern("email")]
		public string Address { get; set; }

		public EmailAddress()
		{
			Validate = false;
			Type = "1";
			EmailTypeList = new List<SelectListItem>();
		}

		public EmailAddress(string type = "1")
		{
			Validate = false;
			Type = type;
			EmailTypeList = new List<SelectListItem>();
		}
	}
}