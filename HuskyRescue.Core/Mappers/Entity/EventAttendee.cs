using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class EventAttendee : Profile
	{
		public override string ProfileName
		{
			get { return "EventAttendeeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.EventAttendee, Model.Event_Attendee>()
				.ForSourceMember(src => src.PlayerNumber, opt => opt.Ignore())
				.ForMember(dest => dest.Entity_Person, opt => opt.MapFrom(src => src.Person))
				.ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.EventRegistrationID, opt => opt.MapFrom(src => src.EventRegistrationId))
				.ForMember(dest => dest.Event_Registration, opt => opt.MapFrom(src => src.EventRegistration));
			Mapper.CreateMap<Model.Event_Attendee, ViewModel.Entity.EventAttendee>()
				.ForMember(dest => dest.PlayerNumber, opt => opt.Ignore())
				.ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Entity_Person))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
				.ForMember(dest => dest.EventRegistrationId, opt => opt.MapFrom(src => src.EventRegistrationID))
				.ForMember(dest => dest.EventRegistration, opt => opt.MapFrom(src => src.Event_Registration));
		}
	}
}
