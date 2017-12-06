using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class ProductVariant : Profile
	{
		public override string ProfileName
		{
			get { return "StoreProductVariantMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreProductVariant, ViewModel.Store.ProductVariant>()
				.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Entity_StoreProduct))
				.ForMember(dest => dest.OptionValues, opt => opt.MapFrom(src => src.Entity_StoreOptionValue))
				.ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.Entity_StoreOrderDetail))
				.ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.Entity_StoreCartItem));
			Mapper.CreateMap<ViewModel.Store.ProductVariant, Model.Entity_StoreProductVariant>()
				.ForMember(dest => dest.Entity_StoreOptionValue, opt => opt.MapFrom(src => src.OptionValues))
				.ForSourceMember(src => src.Product, opt => opt.Ignore())
				.ForSourceMember(src => src.OrderDetails, opt => opt.Ignore())
				.ForSourceMember(src => src.CartItems, opt => opt.Ignore());
		}
	}
}
