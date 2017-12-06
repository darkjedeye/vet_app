using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Donation
	{
		public Donation()
		{
		}

		public Guid Id { get; set; }

		public DateTime DateSubmitted { get; set; }

		public Guid BaseId { get; set; }

		public string BaseType { get; set; }

		public IEnumerable<string> DonorTypeList { get; set; }

		public Person Person { get; set; }

		public Business Business { get; set; }

		public decimal Amount { get; set; }

		public string PaymentTransactionId { get; set; }

		public string DonorComments { get; set; }
	}
}