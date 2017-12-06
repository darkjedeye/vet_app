using AutoMapper;


namespace HuskyRescue.Core.Mappers.Store
{
	public class ProductCategory : Profile
	{
		public override string ProfileName
		{
			get { return "StoreCategoryMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.Entity_StoreCategory, ViewModel.Store.ProductCategory>()
				.ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Entity_StoreProduct));
			Mapper.CreateMap<ViewModel.Store.ProductCategory, Model.Entity_StoreCategory>()
				.ForSourceMember(src => src.Products, opt => opt.Ignore());
		}
	}
}
