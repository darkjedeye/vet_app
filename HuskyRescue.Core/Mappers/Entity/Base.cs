using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class Base : Profile
	{
		public override string ProfileName
		{
			get { return "EntityBaseMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.Base, Model.Entity_Base>()
				.ForMember(dest => dest.Entity_Addresses, opt => opt.MapFrom(src => src.Addresses))
				.ForMember(dest => dest.Entity_EmailAddress, opt => opt.MapFrom(src => src.EmailAddresses))
				.ForMember(dest => dest.Entity_PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumbers));
			Mapper.CreateMap<Model.Entity_Base, ViewModel.Entity.Base>()
				.ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Entity_Addresses))
				.ForMember(dest => dest.EmailAddresses, opt => opt.MapFrom(src => src.Entity_EmailAddress))
				.ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.Entity_PhoneNumber));
		}
	}
}
