using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class EventRegistration : Profile
	{
		public override string ProfileName
		{
			get { return "EventRegistrationMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.EventRegistration, Model.Event_Registration>()
				.ForSourceMember(src => src.ListPlayerCount, opt => opt.Ignore())
				.ForSourceMember(src => src.PlayerCount, opt => opt.Ignore())
				.ForMember(dest => dest.Event_Attendee, opt => opt.MapFrom(src => src.Attendees));
			Mapper.CreateMap<Model.Event_Registration, ViewModel.Entity.EventRegistration>()
				.ForMember(dest => dest.ListPlayerCount, opt => opt.Ignore())
				.ForMember(dest => dest.PlayerCount, opt => opt.Ignore())
				.ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event))
				.ForMember(dest => dest.Attendees, opt => opt.MapFrom(src => src.Event_Attendee));
		}
	}
}
