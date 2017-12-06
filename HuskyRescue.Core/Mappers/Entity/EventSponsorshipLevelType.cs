using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class EventSponsorshipLevelType : Profile
	{
		public override string ProfileName
		{
			get { return "EventSponsorshipLevelTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.EventSponsorshipLevelType, Model.Event_SponsorshipLevelTypes>();
			Mapper.CreateMap<Model.Event_SponsorshipLevelTypes, ViewModel.Entity.EventSponsorshipLevelType>();
		}
	}
}
