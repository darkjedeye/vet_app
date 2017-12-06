using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class PaymentMethod : Profile
	{
		public override string ProfileName
		{
			get { return "StorePaymentMethodMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StorePaymentMethod, ViewModel.Store.PaymentMethod>()
				.ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Entity_StorePayment));
			Mapper.CreateMap<ViewModel.Store.PaymentMethod, Model.Entity_StorePaymentMethod>()
				.ForSourceMember(src => src.Payments, opt => opt.Ignore());
		}
	}
}
