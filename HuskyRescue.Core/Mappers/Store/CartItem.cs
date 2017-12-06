using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class CartItem : Profile
	{
		public override string ProfileName
		{
			get { return "StoreCartItemMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreCartItem, ViewModel.Store.CartItem>()
				.ForMember(dest => dest.ProductVariant, opt => opt.MapFrom(src => src.Entity_StoreProductVariant))
				.ForMember(dest => dest.Cart, opt => opt.MapFrom(src => src.Entity_StoreCart));
			Mapper.CreateMap<ViewModel.Store.CartItem, Model.Entity_StoreCartItem>()
				.ForSourceMember(src => src.ProductVariant, opt => opt.Ignore())
				.ForSourceMember(src => src.Cart, opt => opt.Ignore());
		}
	}
}
