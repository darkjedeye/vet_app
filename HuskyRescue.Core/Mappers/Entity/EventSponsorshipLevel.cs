using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class EventSponsorshipLevel : Profile
	{
		public override string ProfileName
		{
			get { return "EventSponsorshipLevelMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.EventSponsorshipLevel, Model.Event_SponsorshipLevel>();
			Mapper.CreateMap<Model.Event_SponsorshipLevel, ViewModel.Entity.EventSponsorshipLevel>();
		}
	}
}
