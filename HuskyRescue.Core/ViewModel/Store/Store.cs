using System.Collections.Generic;
using HuskyRescue.Core.ViewModel.System;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class Store
	{
		public Store()
		{
			Products = new List<Product>();
			Cart = new Cart();
			Order = new Order();
			User = new User();
		}

		public Cart Cart { get; set; }

		public List<Product> Products { get; set; }

		public Order Order { get; set; }

		public User User { get; set; }
	}
}
