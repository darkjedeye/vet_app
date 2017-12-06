using System;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class CartItem
	{
		public CartItem()
		{
		}

		public int Id { get; set; }

		public Guid CartId { get; set; }
		public Cart Cart { get; set; }

		public Guid ProductVariantId { get; set; }
		public ProductVariant ProductVariant { get; set; }

		[DisplayName("Quantity")]
		public int Quantity { get; set; }
	}
}
