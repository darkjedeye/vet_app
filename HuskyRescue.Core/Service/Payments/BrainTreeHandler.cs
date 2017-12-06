using System;
using System.Collections.Generic;
using System.Diagnostics;
using Braintree;
using Fabrik.Common;
using HuskyRescue.Core.ViewModel.Payments;

namespace HuskyRescue.Core.Service.Payments
{
	public class BrainTreeHandler : NewBaseHandler
	{
		public ServiceResultEnum SendTransactionRequest(ref PaymentInformation payment)
		{
			var request = new TransactionRequest
			{
				OrderId = payment.OrderId,
				Amount = payment.Amount,
				TaxExempt = true,
				CreditCard = new TransactionCreditCardRequest
				{
					Number = payment.CreditCardNumber,
					CVV = payment.CreditCardCvv,
					ExpirationMonth = payment.CreditCardExpireMonth,
					ExpirationYear = payment.CreditCardExpireYear
				},
				Customer = new CustomerRequest
				{
					Id = payment.CustomerId,
					FirstName = payment.CustomerNameFirst,
					LastName = payment.CustomerNameLast,
					Email = payment.CustomerEmail,
					Phone = payment.CustomerPhone,
					Website = payment.CustomerWebsite
				},
				BillingAddress = new AddressRequest
				{
					FirstName = payment.BillingNameFirst,
					LastName = payment.BillingNameLast,
					StreetAddress = payment.BillingAddressStreet,
					ExtendedAddress = payment.BillingAddressStreet2,
					Locality = payment.BillingAddressLocality,
					Region = payment.BillingAddressRegion,
					PostalCode = payment.BillingAddressPostalCode,
					CountryCodeAlpha2 = "US"
				},
				Options = new TransactionOptionsRequest
				{
					StoreInVaultOnSuccess = payment.OptionStoreInVault,
					AddBillingAddressToPaymentMethod = true,
					SubmitForSettlement = payment.OptionSubmitForSettlement,
					StoreShippingAddressInVault = payment.OptionStoreInVault
				},
				CustomFields = new Dictionary<string, string>
				{
					{"transaction_desc", payment.TransactionDescription}
				}
			};

			if (payment.ShippingAddressStreet.IsNullOrEmpty())
			{
				request.ShippingAddress = new AddressRequest
										  {
											  FirstName = payment.ShippingNameFirst,
											  LastName = payment.ShippingNameLast,
											  StreetAddress = payment.ShippingAddressStreet,
											  ExtendedAddress = payment.ShippingAddressStreet2,
											  Locality = payment.ShippingAddressLocality,
											  Region = payment.ShippingAddressRegion,
											  PostalCode = payment.ShippingAddressPostalCode,
											  CountryCodeAlpha2 = "US"
										  };
			}

			var result = Constants.BraintreeGateway.Transaction.Sale(request);

			payment.IsSuccess = result.IsSuccess();
			ServiceResult = payment.IsSuccess ? ServiceResultEnum.Success : ServiceResultEnum.Failure;
			payment.TransactionResult = result;
			return ServiceResult;
		}
	}
}
