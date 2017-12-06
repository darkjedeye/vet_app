using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class Product
	{
		public Guid Id { get; set; }

		[DisplayName("Active?")]
		public bool IsActive { get; set; }

		[DisplayName("Category")]
		public Guid CategoryId { get; set; }
		public ProductCategory Category { get; set; }

		[DisplayName("Product Name")]
		public string Name { get; set; }

		[DisplayName("Created On")]
		public DateTime CreatedOn { get; set; }
		
		[DisplayName("Created By")]
		public string CreatedByUser { get; set; }
		
		[DisplayName("Updated On")]
		public DateTime UpdatedOn { get; set; }
		
		[DisplayName("Updated By")]
		public string UpdatedByUser { get; set; }
		
		[DisplayName("Deleted On")]
		public DateTime? DeletedOn { get; set; }
		
		[DisplayName("Deleted By")]
		public string DeletedByUser { get; set; }
		
		[DisplayName("Description")]
		public string Description { get; set; }

		public List<ProductVariant> ProductVariants { get; set; } 
		public List<ProductImage> ProductImages { get; set; } 
		public List<ProductProperty> ProductProperties { get; set; }
		public List<OptionType> ProductOptionTypes { get; set; } 

		public Product()
		{
			IsActive = true;
			ProductVariants = new List<ProductVariant>();
			ProductImages = new List<ProductImage>();
			ProductProperties = new List<ProductProperty>();
			ProductOptionTypes = new List<OptionType>();
		}
	}
}
