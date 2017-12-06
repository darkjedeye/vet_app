using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class Business : Profile
	{
		public override string ProfileName
		{
			get { return "EntityBusinessMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_Organisation, ViewModel.Entity.Business>()
				.ForMember(dest => dest.TypeBusiness, opt => opt.MapFrom(src => src.Type))
				.ForMember(dest => dest.Base, opt => opt.MapFrom(src => src.Entity_Base));
			Mapper.CreateMap<ViewModel.Entity.Business, Model.Entity_Organisation>()
				.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TypeBusiness))
				.ForMember(dest => dest.Entity_Base, opt => opt.MapFrom(src => src.Base));
		}
	}
}
