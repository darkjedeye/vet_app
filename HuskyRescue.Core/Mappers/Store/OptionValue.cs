using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class OptionValue : Profile
	{
		public override string ProfileName
		{
			get { return "StoreOptionValueMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreOptionValue, ViewModel.Store.OptionValue>()
				.ForMember(dest => dest.OptionType, opt => opt.MapFrom(src => src.Entity_StoreOptionType))
				.ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.Entity_StoreProductVariant));
			Mapper.CreateMap<ViewModel.Store.OptionValue, Model.Entity_StoreOptionValue>()
				.ForSourceMember(src => src.OptionType, opt => opt.Ignore())
				.ForSourceMember(src => src.ProductVariants, opt => opt.Ignore());
		}
	}
}
