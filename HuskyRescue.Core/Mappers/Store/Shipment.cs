using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class Shipment : Profile
	{
		public override string ProfileName
		{
			get { return "StoreShipmentMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreShipment, ViewModel.Store.Shipment>()
				.ForMember(dest => dest.ShippingMethod, opt => opt.MapFrom(src => src.Entity_StoreShippingMethod))
				.ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Entity_StoreOrder));
			Mapper.CreateMap<ViewModel.Store.Shipment, Model.Entity_StoreShipment>()
				.ForSourceMember(src => src.Order, opt => opt.Ignore())
				.ForSourceMember(src => src.ShippingMethod, opt => opt.Ignore());
		}
	}
}
