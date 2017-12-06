using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class OptionValue
	{
		public Guid Id { get; set; }

		public Guid OptionId { get; set; }
		public OptionType OptionType { get; set; }

		[DisplayName("Option Value")]
		public string Value { get; set; }

		public List<ProductVariant> ProductVariants { get; set; }

		public OptionValue()
		{
			ProductVariants = new List<ProductVariant>();
		}
	}
}
