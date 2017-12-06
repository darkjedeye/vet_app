using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class PersonList
	{
		[DisplayName("First Name")]
		[DataType(DataType.Text)]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		[DataType(DataType.Text)]
		public string LastName { get; set; }

		[DisplayName("License Number")]
		[DataType(DataType.Text)]
		public string LicenseNumber { get; set; }

		[DisplayName("Is Active")]
		public bool IsActive { get; set; }

		[DisplayName("Delete?")]
		public bool IsDeleted { get; set; }

		[DisplayName("Can receive mail (usps)?")]
		public bool IsMailable { get; set; }

		[DisplayName("Can receive e-mail?")]
		public bool IsEmailable { get; set; }

		[DisplayName("Date activated")]
		public DateTime? DateActive { get; private set; }

		[DisplayName("Date inactivated")]
		public DateTime? DateInActive { get; private set; }

		[DisplayName("Street Address")]
		[DataType(DataType.Text)]
		public string Street { get; set; }

		[DisplayName("City")]
		[DataType(DataType.Text)]
		public string City { get; set; }

		public string StateID { get; set; }

		[DisplayName("ZIP")]
		[DataType(DataType.Text)]
		public string ZIP { get; set; }

		public PersonList()
		{
			
		}
	}
}