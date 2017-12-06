using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class Payment : Profile
	{
		public override string ProfileName
		{
			get { return "StorePaymentMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StorePayment, ViewModel.Store.Payment>()
				.ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Entity_StoreOrder))
				.ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.Entity_StorePaymentMethod));
			Mapper.CreateMap<ViewModel.Store.Payment, Model.Entity_StorePayment>()
				.ForSourceMember(src => src.PaymentMethod, opt => opt.Ignore())
				.ForSourceMember(src => src.Order, opt => opt.Ignore());
		}
	}
}
