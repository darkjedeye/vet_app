using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class ProductVariant
	{
		public Guid Id { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }

		[DisplayName("Active Product?")]
		public bool IsActive { get; set; }

		[DisplayName("Quantity")]
		public int Quantity { get; set; }

		[DisplayName("Price")]
		public decimal Price { get; set; }

		[DisplayName("Cost to the group")]
		public decimal CostPrice { get; set; }

		[DisplayName("Weight (oz)")]
		public decimal Weight { get; set; }

		[DisplayName("Flat Shipping Cost")]
		public decimal? ShippingCost { get; set; }

		[DisplayName("Created On")]
		public DateTime CreatedOn { get; set; }

		[DisplayName("Created By")]
		public string CreatedByUser { get; set; }

		[DisplayName("Updated On")]
		public DateTime UpdatedOn { get; set; }

		[DisplayName("Updated By")]
		public string UpdatedByUser { get; set; }

		[DisplayName("Deleted On")]
		public DateTime DeletedOn { get; set; }

		[DisplayName("Deleted By")]
		public string DeletedByUser { get; set; }

		public List<CartItem> CartItems { get; set; }
		public List<OrderDetail> OrderDetails { get; set; } 
		public List<OptionValue> OptionValues { get; set; } 
	}
}
