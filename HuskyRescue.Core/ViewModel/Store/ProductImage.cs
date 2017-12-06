using System;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class ProductImage
	{
		public Guid Id { get; set; }

		public Guid ProductId { get; set; }
		public Product Product { get; set; }

		[DisplayName("Path to image")]
		public string Path { get; set; }

		[DisplayName("Alt text for image")]
		public string Description { get; set; }
	}
}
