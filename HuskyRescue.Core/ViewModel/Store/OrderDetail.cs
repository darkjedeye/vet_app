using System;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class OrderDetail
	{
		public OrderDetail()
		{

		}
	
		public int Id { get; set; }
		
		public Guid OrderId { get; set; }
		public Order Order { get; set; }

		public Guid ProductVariantId { get; set; }
		public ProductVariant ProductVariant { get; set; }

		[DisplayName("Quantity")]
		public int Quantity { get; set; }

		[DisplayName("Price")]
		public decimal Price { get; set; }

	}
}
