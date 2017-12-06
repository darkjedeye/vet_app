using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class OptionType : Profile
	{
		public override string ProfileName
		{
			get { return "StoreOptionTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreOptionType, ViewModel.Store.OptionType>()
				.ForMember(dest => dest.OptionValues, opt => opt.MapFrom(src => src.Entity_StoreOptionValue))
				.ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Entity_StoreProduct));
			Mapper.CreateMap<ViewModel.Store.OptionType, Model.Entity_StoreOptionType>()
				.ForMember(dest => dest.Entity_StoreOptionValue, opt => opt.MapFrom(src => src.OptionValues))
				.ForSourceMember(src => src.Products, opt => opt.Ignore());
		}
	}
}
