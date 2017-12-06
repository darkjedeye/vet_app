using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class ProductProperty : Profile
	{
		public override string ProfileName
		{
			get { return "StoreProductPropertyMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreProperty, ViewModel.Store.ProductProperty>()
				.ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Entity_StoreProduct));
			Mapper.CreateMap<ViewModel.Store.ProductProperty, Model.Entity_StoreProperty>()
				.ForSourceMember(src => src.Products, opt => opt.Ignore());
		}
	}
}
