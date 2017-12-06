using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class OrderDetail : Profile
	{
		public override string ProfileName
		{
			get { return "StoreOrderDetailMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreOrderDetail, ViewModel.Store.OrderDetail>()
				.ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Entity_StoreOrder))
				.ForMember(dest => dest.ProductVariant, opt => opt.MapFrom(src => src.Entity_StoreProductVariant));
			Mapper.CreateMap<ViewModel.Store.OrderDetail, Model.Entity_StoreOrderDetail>()
				.ForSourceMember(src => src.ProductVariant, opt => opt.Ignore())
				.ForSourceMember(src => src.Order, opt => opt.Ignore());
		}
	}
}
