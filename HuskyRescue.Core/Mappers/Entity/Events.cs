using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class Event : Profile
	{
		public override string ProfileName
		{
			get { return "EventMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.Event, Model.Event>()
				.ForSourceMember(src => src.Locations, opt => opt.Ignore())
				.ForSourceMember(src => src.Business, opt => opt.Ignore())
				.ForMember(src => src.Entity_Organisation, opt => opt.Ignore())
				.ForMember(src => src.OrganisationID, opt => opt.MapFrom(dest => dest.BusinessId))
				.ForMember(src => src.Event_Registration, opt => opt.MapFrom(dest => dest.Registrations));
			Mapper.CreateMap<Model.Event, ViewModel.Entity.Event>()
				.ForMember(dest => dest.Registrations, opt => opt.MapFrom(src => src.Event_Registration))
				.ForMember(dest => dest.Locations, opt => opt.Ignore())
				.ForMember(dest => dest.Business, opt => opt.MapFrom(src => src.Entity_Organisation))
				.ForMember(src => src.BusinessId, opt => opt.MapFrom(dest => dest.OrganisationID));
		}
	}
}
