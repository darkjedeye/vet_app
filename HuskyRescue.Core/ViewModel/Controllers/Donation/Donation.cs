using Fabrik.Common;
using HuskyRescue.Core.Service.Enum;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Core.ViewModel.Extensions;
using HuskyRescue.Core.ViewModel.Payments;

namespace HuskyRescue.Core.ViewModel.Controllers.Donation
{
	public class Donation
	{
		public Entity.Donation DonationInformation { get; set; }

		public BillingInformation BillingInformation { get; set; }

		/// <summary>
		/// True if viewed from admin view, default to false
		/// </summary>
		public bool IsAdminView { get; set; }

		/// <summary>
		/// If editing an existing registration then set to false, default to true
		/// </summary>
		public bool ShowPaymentSection { get; set; }


		public Donation()
		{
			ShowPaymentSection = true;
			IsAdminView = false;
			DonationInformation = new Entity.Donation { BaseType = "PER" };

			BillingInformation = new BillingInformation();
			
			SetupDonor(true);
		}

		public Donation(Entity.Donation donation, BillingInformation billingInformation)
		{
			ShowPaymentSection = true;
			IsAdminView = false;
			DonationInformation = donation;
			donation.BaseType = "PER";

			BillingInformation = billingInformation;

			SetupDonor(true);
		}

		public void SetupDonor(bool isNew = false)
		{
			var usaStatesHandler = new UsaStatesHandler();

			BillingInformation.Person.Base.Addresses[0].AddressStateList = usaStatesHandler.ReadAll().ToSelectListItems(isNew ? "TX" : BillingInformation.Person.Base.Addresses[0].StateID);

			DonationInformation.Person = new Person();
			var baseEntity = DonationInformation.Person.Base;
			SetupBase(ref baseEntity, isNew, usaStatesHandler);

			//baseEntity = DonationInformation.Business.Base;
			//SetupBase(ref baseEntity, isNew, usaStatesHandler);
		}

		private void SetupBase(ref Base Base, bool isNew, UsaStatesHandler usaStatesHandler)
		{
			if (isNew || Base.Addresses.Count == 0)
			{
				// add one default address
				Base.BuildAddresses();
			}
			foreach (var address in Base.Addresses)
			{
				address.AddressStateList = usaStatesHandler.ReadAll().ToSelectListItems(address.StateID.IsNullOrEmpty() ? "TX" : address.StateID);
			}

			if (isNew || Base.EmailAddresses.Count == 0)
			{
				// add two default email addresses
				Base.BuildEmailAddresses();
			}
			if (isNew || Base.PhoneNumbers.Count == 0)
			{
				// add three default phone numbers
				Base.BuildPhoneNumbers();
			}
		}

		public PaymentInformation GetPaymentInformation()
		{
			var payment = new PaymentInformation
			{
				Amount = DonationInformation.Amount,
				CreditCardHolderName = BillingInformation.Person.FullName,
				CreditCardNumber = BillingInformation.CreditCardNumber,
				CreditCardExpireMonth = BillingInformation.CreditCardExpireMonth,
				CreditCardExpireYear = BillingInformation.CreditCardExpireYear,
				CreditCardCvv = BillingInformation.CreditCardCvv,
				CustomerNameFirst = BillingInformation.Person.FirstName,
				CustomerNameLast = BillingInformation.Person.LastName,
				CustomerPhone = BillingInformation.Person.Base.PhoneNumbers[0].Number,
				CustomerEmail = BillingInformation.Person.Base.EmailAddresses[0].Address,
				BillingNameFirst = BillingInformation.Person.FirstName,
				BillingNameLast = BillingInformation.Person.LastName,
				BillingAddressStreet = BillingInformation.Person.Base.Addresses[0].Street,
				BillingAddressStreet2 = BillingInformation.Person.Base.Addresses[0].Street2,
				BillingAddressLocality = BillingInformation.Person.Base.Addresses[0].City,
				BillingAddressRegion = BillingInformation.Person.Base.Addresses[0].StateID,
				BillingAddressPostalCode = BillingInformation.Person.Base.Addresses[0].ZIP
			};

			return payment;
		}
	}
}
