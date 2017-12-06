using System.Linq;
using Braintree;
using Environment = System.Environment;

namespace HuskyRescue.Core.ViewModel.Payments
{
	public class PaymentInformation
	{
		public PaymentInformation()
		{
			OptionSubmitForSettlement = true;
			OptionStoreInVault = true;
		}

		public decimal Amount { get; set; }
		public string OrderId { get; set; }
		public bool OptionSubmitForSettlement { get; set; }
		public bool OptionStoreInVault { get; set; }

		public string CreditCardHolderName { get; set; }
		public string CreditCardNumber { get; set; }
		public string CreditCardCvv { get; set; }
		public string CreditCardExpireMonth { get; set; }
		public string CreditCardExpireYear { get; set; }

		public string CustomerId { get; set; }
		public string CustomerNameFirst { get; set; }
		public string CustomerNameLast { get; set; }
		public string CustomerCompany { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerFax { get; set; }
		public string CustomerWebsite { get; set; }
		public string CustomerEmail { get; set; }

		public string BillingNameFirst { get; set; }
		public string BillingNameLast { get; set; }
		public string BillingCompany { get; set; }
		public string BillingAddressStreet { get; set; }
		public string BillingAddressStreet2 { get; set; }
		public string BillingAddressLocality { get; set; }
		public string BillingAddressRegion { get; set; }
		public string BillingAddressPostalCode { get; set; }
		public string BillingAddressCountryCode { get; set; }

		public string ShippingNameFirst { get; set; }
		public string ShippingNameLast { get; set; }
		public string ShippingCompany { get; set; }
		public string ShippingAddressStreet { get; set; }
		public string ShippingAddressStreet2 { get; set; }
		public string ShippingAddressLocality { get; set; }
		public string ShippingAddressRegion { get; set; }
		public string ShippingAddressPostalCode { get; set; }
		public string ShippingAddressCountryCode { get; set; }

		public string TransactionDescription { get; set; }

		public Result<Transaction> TransactionResult { get; set; }
		public bool IsSuccess { get; set; }

		public string ErrorMessage()
		{
			var responseErrorMessage = string.Empty;
			Transaction transaction = null;
			if (TransactionResult.Transaction != null)
			{
				transaction = TransactionResult.Transaction;

				if (transaction.Status == TransactionStatus.AUTHORIZATION_EXPIRED)
				{
					responseErrorMessage = "Authorization Expired";
				}
				else if (transaction.Status == TransactionStatus.FAILED)
				{
					responseErrorMessage = "Failed";
				}
				else if (transaction.Status == TransactionStatus.GATEWAY_REJECTED)
				{
					var reason = (transaction.GatewayRejectionReason.ToString() == "avs") ? "Address Verification Failed" : "Unknown";
					responseErrorMessage = "Gateway Rejected: " + reason;
				}
				else if (transaction.Status == TransactionStatus.PROCESSOR_DECLINED)
				{
					responseErrorMessage = "Processor Declined: " + transaction.ProcessorResponseCode + " - " + transaction.ProcessorResponseText;
				}
				else if (transaction.Status == TransactionStatus.UNRECOGNIZED)
				{
					responseErrorMessage = "Unrecognized";
				}
			}

			var errorList = TransactionResult.Errors.DeepAll().Select(error => "Validation Error on " + error.Attribute + ". Error: " + error.Code + " - " + error.Message).ToList();

			var errorString = string.Empty;
			errorString = errorList.Aggregate(errorString, (current, error) => current + (error + Environment.NewLine));

			var errorLog = "Credit Card Error:" + Environment.NewLine + responseErrorMessage;
			if (transaction != null)
			{
				errorLog = Environment.NewLine + "transaction Id: " + transaction.Id
						   + Environment.NewLine + "ProcessorAuthorizationCode: " + transaction.ProcessorAuthorizationCode
						   + Environment.NewLine + "CvvResponseCode: " + transaction.CvvResponseCode;
			}
			errorLog = Environment.NewLine + errorString;

			return errorLog;
		}
	}
}
