using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class ApplicantVeterinarian
	{
		#region properties
		public Guid ID { get; set; }

		[DisplayName("Doctor Name"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string NameDr { get; set; }

		[DisplayName("Office Name"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string NameOffice { get; set; }

		[DisplayName("Phone Number"), DataType(DataType.PhoneNumber), StringLength(14), FoundationAbidePattern("phone", "Must be a phone number")]
		public string PhoneNumber { get; set; }
		#endregion
		
		#region methods
		public ApplicantVeterinarian()
		{

		}
		#endregion
	}
}
