using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class ShippingMethod : Profile
	{
		public override string ProfileName
		{
			get { return "StoreShippingMethodMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreShippingMethod, ViewModel.Store.ShippingMethod>()
				.ForMember(dest => dest.Shipments, opt => opt.MapFrom(src => src.Entity_StoreShipment));
			Mapper.CreateMap<ViewModel.Store.ShippingMethod, Model.Entity_StoreShippingMethod>()
				.ForSourceMember(src => src.Shipments, opt => opt.Ignore());
		}
	}
}
