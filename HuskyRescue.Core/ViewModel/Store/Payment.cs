using System;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class Payment
	{
		public Payment()
		{

		}

		public Guid Id { get; set; }

		public Guid OrderId { get; set; }
		public Order Order { get; set; }

		[DisplayName("Total Payment Amount")]
		public decimal Amount { get; set; }

		public Guid PaymentMethodId { get; set; }
		public PaymentMethod PaymentMethod { get; set; }

		[DisplayName("Created On")]
		public DateTime CreatedOn { get; set; }

		[DisplayName("Updated On")]
		public DateTime UpdatedOn { get; set; }

		[DisplayName("Payment Status")]
		public string Status { get; set; }

		[DisplayName("Gateway Transaction Id")]
		public string GatewayTransactionId { get; set; }

		[DisplayName("Gateway Response Code")]
		public string ResponseCode { get; set; }

		[DisplayName("Gateway Response Text")]
		public string ResponseText { get; set; }
	}
}
