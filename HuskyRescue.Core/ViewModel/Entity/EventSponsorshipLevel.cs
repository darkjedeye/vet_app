using System;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class EventSponsorshipLevel
	{
		public EventSponsorshipLevel()
		{
		}

		public int ID { get; set; }

		public Guid SponsorID { get; set; }

		public int SponsorshipLevelType { get; set; }
		
	}
}