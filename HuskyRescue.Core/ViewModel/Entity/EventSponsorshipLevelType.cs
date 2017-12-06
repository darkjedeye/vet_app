using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class EventSponsorshipLevelType
	{
		public int ID { get; set; }

		[DisplayName("Sponsorship Name")]
		[Required(ErrorMessage = "Required")]
		[StringLength(100)]
		public string Name { get; set; }

		public string Description { get; set; }

		[DisplayName("Description")]
		[DataType(DataType.MultilineText)]
		public List<string> DescriptionHTML
		{
			get
			{
				var desc = Description.Split(Environment.NewLine.ToCharArray()).ToList();
				desc.RemoveAll(string.IsNullOrEmpty);
				return desc;	
			}
		}

		[DisplayName("Amount to sponsor")]
		[DataType(DataType.Currency)]
		public decimal? SponsorAmount { get; set; }

		public EventSponsorshipLevelType()
		{
			Description = string.Empty;
			Name = string.Empty;
		}
	}
}