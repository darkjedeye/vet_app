using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class ProductCategory
	{
		public ProductCategory()
		{
			Products = new List<Product>();
		}

		public Guid Id { get; set; }
		
		[DisplayName("Category Name")]
		public string Name { get; set; }

		[DisplayName("Description")]
		public string Description { get; set; }

		[DisplayName("Link to Banner image")]
		public string BannerImageLink { get; set; }

		public List<Product> Products { get; set; } 
	}
}
