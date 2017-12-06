using Fabrik.Common;
using HuskyRescue.Core.Service.Enum;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Core.ViewModel.Extensions;
using HuskyRescue.Core.ViewModel.Payments;

namespace HuskyRescue.Core.ViewModel.Controllers.Events
{
	public class GolfRegistration
	{
		public EventRegistration EventRegistration { get; set; }

		public BillingInformation BillingInformation { get; set; }

		/// <summary>
		/// True if viewed from admin view, default to false
		/// </summary>
		public bool IsAdminView { get; set; }

		/// <summary>
		/// If editing an existing registration then set to false, default to true
		/// </summary>
		public bool ShowPaymentSection { get; set; }

		public GolfRegistration()
		{
			ShowPaymentSection = true;
			IsAdminView = false;
			EventRegistration = new EventRegistration();

			BillingInformation = new BillingInformation();

			SetupAttendees(true);
		}

		public GolfRegistration(EventRegistration eventRegistration, BillingInformation billingInformation)
		{
			ShowPaymentSection = true;
			IsAdminView = false;
			EventRegistration = eventRegistration;

			BillingInformation = billingInformation;

			SetupAttendees(true);
		}

		public void SetupAttendees(bool isNew = false)
		{
			var usaStatesHandler = new UsaStatesHandler();

			BillingInformation.Person.Base.Addresses[0].AddressStateList = usaStatesHandler.ReadAll().ToSelectListItems(isNew ? "TX" : BillingInformation.Person.Base.Addresses[0].StateID);

			if (EventRegistration.Attendees == null)
			{
				EventRegistration.BuildAttendees();
			}

			foreach (var attendee in EventRegistration.Attendees)
			{
				var Base = attendee.Person.Base;

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
		}

		public PaymentInformation GetPaymentInformation()
		{
			var payment = new PaymentInformation
						  {
							  Amount = EventRegistration.AmountDue,
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
