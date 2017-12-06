using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class Order : Profile
	{
		public override string ProfileName
		{
			get { return "StoreOrderMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreOrder, ViewModel.Store.Order>()
				.ForMember(dest => dest.CustomerBase, opt => opt.MapFrom(src => src.Entity_Base))
				.ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.Entity_Addresses))
				.ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.Entity_Addresses1))
				.ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.Entity_StoreOrderDetail))
				.ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Entity_StorePayment))
				.ForMember(dest => dest.Shipments, opt => opt.MapFrom(src => src.Entity_StoreShipment));
			Mapper.CreateMap<ViewModel.Store.Order, Model.Entity_StoreOrder>()
				.ForMember(dest => dest.Entity_StoreOrderDetail, opt => opt.MapFrom(src => src.OrderDetails))
				.ForSourceMember(src => src.BillingAddress, opt => opt.Ignore())
				.ForSourceMember(src => src.CustomerBase, opt => opt.Ignore())
				.ForSourceMember(src => src.Payments, opt => opt.Ignore())
				.ForSourceMember(src => src.Shipments, opt => opt.Ignore())
				.ForSourceMember(src => src.ShippingAddress, opt => opt.Ignore());
		}
	}
}
