using System;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class Shipment
	{
		public Guid Id { get; set; }

		public Guid OrderId { get; set; }
		public Order Order { get; set; }

		public Guid ShippingMethodId { get; set; }
		public ShippingMethod ShippingMethod { get; set; }

		[DisplayName("Status")]
		public string Status { get; set; }

		[DisplayName("Shipping Cost")]
		public decimal Cost { get; set; }

		[DisplayName("Created On")]
		public DateTime CreatedOn { get; set; }

		[DisplayName("Updated On")]
		public DateTime UpdatedOn { get; set; }

		[DisplayName("Updated By")]
		public string UpdatedByUser { get; set; }

		[DisplayName("Shipped On")]
		public DateTime? ShippedOn { get; set; }

		[DisplayName("Shipped By")]
		public string ShippedByUser { get; set; }
	}
}
