using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HuskyRescue.Core.ViewModel.Store
{
	public class PaymentMethod
	{
		public PaymentMethod()
		{
			Payments = new List<Payment>();
		}

		public Guid Id { get; set; }

		[DisplayName("Active Method?")]
		public bool IsActive { get; set; }

		[DisplayName("Payment Name")]
		public string Name { get; set; }

		[DisplayName("Description")]
		public string Description { get; set; }

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

		public List<Payment> Payments { get; set; }

	}
}
