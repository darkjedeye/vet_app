using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class Cart
	{
		public Cart()
		{
			CartItems = new List<CartItem>();
		}

		public Guid Id { get; set; }

		[DisplayName("User the cart belongs to")]
		public string UserName { get; set; }

		[DisplayName("Created On")]
		public DateTime CreatedOn { get; set; }

		[DisplayName("Updated On")]
		public DateTime UpdatedOn { get; set; }

		[DisplayName("Total price of cart items")]
		public decimal TotalPrice { get; set; }

		public List<CartItem> CartItems { get; set; }
	}
}
