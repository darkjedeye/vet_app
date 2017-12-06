using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Person
	{
		/// <summary>
		/// Unique Id of the Person
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Unique Id of the Base associated with the Person. Use this to access Email, Phone, Address, etc
		/// </summary>
		public Guid BaseID { get; set; }

		/// <summary>
		/// Base object associated with the Person
		/// </summary>
		public Base Base { get; set; }

		/// <summary>
		/// Read only property to get the Person's full name
		/// </summary>
		[DisplayName("Full"), DataType(DataType.Text)]
		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

		//[RoleRequired(ErrorMessage = "First Name Required.", IsRequiredForRoles = true)]
		[DisplayName("First name"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string FirstName { get; set; }

		//[RoleRequired(ErrorMessage = "Last Name Required.", IsRequiredForRoles = true)]
		[DisplayName("Last name"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string LastName { get; set; }

		[DisplayName("Drivers license #"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string LicenseNumber { get; set; }

		[DisplayName("Gender"), DataType(DataType.Text), StringLength(3), FoundationAbidePattern("length_3")]
		public string Gender { get; set; }

		public Person()
		{
			Base = new Base("PER");
		}
	}
}