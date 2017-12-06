using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class ProductProperty
	{
		public Guid Id { get; set; }

		[DisplayName("Publicly visible?")]
		public bool IsPublic { get; set; }

		[DisplayName("Name")]
		public string Name { get; set; }

		[DisplayName("Argument")]
		public string Value { get; set; }

		public List<Product> Products { get; set; }

		public ProductProperty()
		{
			Products = new List<Product>();
			IsPublic = true;
		}
	}
}
