using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class ProductImage : Profile
	{
		public override string ProfileName
		{
			get { return "StoreProductImageMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreProductImage, ViewModel.Store.ProductImage>()
				.ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Entity_StoreProduct));
			Mapper.CreateMap<ViewModel.Store.ProductImage, Model.Entity_StoreProductImage>()
				.ForSourceMember(src => src.Product, opt => opt.Ignore());
		}
	}
}
