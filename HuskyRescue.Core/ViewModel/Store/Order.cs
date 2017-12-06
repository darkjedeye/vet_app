using System;
using System.Collections.Generic;
using System.ComponentModel;
using HuskyRescue.Core.ViewModel.Entity;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class Order
	{
		public Order()
		{
			OrderDetails = new List<OrderDetail>();
			Payments = new List<Payment>();
			Shipments = new List<Shipment>();
		}

		public Order(Cart cart)
		{
			OrderDetails = new List<OrderDetail>();
			Payments = new List<Payment>();
			Shipments = new List<Shipment>();

			foreach (var item in cart.CartItems)
			{
				OrderDetails.Add(new OrderDetail()
								 {
									 ProductVariantId = item.ProductVariantId,
									 Quantity = item.Quantity,
									 Price = item.ProductVariant.Price
								 });
			}
		}

		public Guid Id { get; set; }

		[DisplayName("Order belongs to user")]
		public string UserName { get; set; }

		[DisplayName("# Products")]
		public int TotalProducts { get; set; }

		[DisplayName("Total due")]
		public decimal TotalDue { get; set; }

		[DisplayName("Created On")]
		public DateTime CreatedOn { get; set; }

		[DisplayName("Updated On")]
		public DateTime UpdatedOn { get; set; }

		[DisplayName("Completed On")]
		public DateTime? CompletedOn { get; set; }

		[DisplayName("Order Status")]
		public string Status { get; set; }

		[DisplayName("Shipping Status")]
		public string ShippingStatus { get; set; }

		public Base CustomerBase { get; set; }
		public Guid? PersonBaseId { get; set; }
	
		/// <summary>
		/// Name="Entity_Addresses"
		/// </summary>
		public Address BillingAddress { get; set; }
		public Guid? BillingAddressId { get; set; }

		/// <summary>
		/// Name="Entity_Addresses1"
		/// </summary>
		public Address ShippingAddress { get; set; }
		public Guid? ShippingAddressId { get; set; }
		
		public string SpecialInstructions { get; set; }

		public List<OrderDetail> OrderDetails { get; set; }
		public List<Payment> Payments { get; set; }
		public List<Shipment> Shipments { get; set; }
	}
}
