using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class OptionType
	{
		public OptionType()
        {
            OptionValues = new List<OptionValue>();
            Products = new List<Product>();
        }
    
        public Guid Id { get; set; }

		[DisplayName("Name")]
        public string Name { get; set; }
    
        public List<OptionValue> OptionValues { get; set; }
        public List<Product> Products { get; set; }
	}
}
