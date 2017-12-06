using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class Cart : Profile
	{
		public override string ProfileName
		{
			get { return "StoreCartMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreCart, ViewModel.Store.Cart>()
				.ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.Entity_StoreCartItem));
			Mapper.CreateMap<ViewModel.Store.Cart, Model.Entity_StoreCart>()
				.ForMember(dest => dest.Entity_StoreCartItem, opt => opt.MapFrom(src => src.CartItems));
		}
	}
}
