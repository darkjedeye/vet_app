using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Entity;

namespace HuskyRescue.Core.ViewModel.Payments
{
	public class BillingInformation
	{
		public Person Person { get; set; }

		[DisplayName("Card number"), DataType(DataType.Text), Required, StringLength(20), FoundationAbidePattern("card")]
		public string CreditCardNumber { get; set; }

		[DisplayName("CVV"), DataType(DataType.Text), Required, StringLength(4), FoundationAbidePattern("cvv")]
		public string CreditCardCvv { get; set; }

		[DisplayName("MM"), DataType(DataType.Text), Required, StringLength(2), FoundationAbidePattern("number")]
		public string CreditCardExpireMonth { get; set; }

		[DisplayName("YYYY"), DataType(DataType.Text), Required, StringLength(4), FoundationAbidePattern("number")]
		public string CreditCardExpireYear { get; set; }

		public BillingInformation()
		{
			Person = new Person();
			Person.Base.BuildAddresses();
			Person.Base.BuildEmailAddresses();
			Person.Base.BuildPhoneNumbers();
		}
	}
}
