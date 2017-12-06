using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class Product : Profile
	{
		public override string ProfileName
		{
			get { return "StoreProductMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreProduct, ViewModel.Store.Product>()
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Entity_StoreCategory))
				.ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.Entity_StoreProductImage))
				.ForMember(dest => dest.ProductOptionTypes, opt => opt.MapFrom(src => src.Entity_StoreOptionType))
				.ForMember(dest => dest.ProductProperties, opt => opt.MapFrom(src => src.Entity_StoreProperty))
				.ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.Entity_StoreProductVariant));
			Mapper.CreateMap<ViewModel.Store.Product, Model.Entity_StoreProduct>()
				.ForMember(dest => dest.Entity_StoreCategory, opt => opt.MapFrom(src => src.Category))
				.ForMember(dest => dest.Entity_StoreProductImage, opt => opt.MapFrom(src => src.ProductImages))
				.ForMember(dest => dest.Entity_StoreProperty, opt => opt.MapFrom(src => src.ProductProperties))
				.ForSourceMember(src => src.ProductOptionTypes, opt => opt.Ignore())
				.ForSourceMember(src => src.ProductVariants, opt => opt.Ignore());
		}
	}
}
