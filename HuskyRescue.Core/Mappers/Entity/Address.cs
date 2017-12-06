using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class Address : Profile
	{
		public override string ProfileName
		{
			get { return "EntityAddressMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.Address, Model.Entity_Addresses>()
				.ForSourceMember(src => src.AddressStateList, opt => opt.Ignore())
				.ForSourceMember(src => src.AddressTypeList, opt => opt.Ignore())
				.ForSourceMember(src => src.ShowAddressTypeList, opt => opt.Ignore());
			Mapper.CreateMap<Model.Entity_Addresses, ViewModel.Entity.Address>()
				.ForMember(dest => dest.AddressStateList, opt => opt.Ignore())
				.ForMember(dest => dest.AddressTypeList, opt => opt.Ignore())
				.ForMember(dest => dest.ShowAddressTypeList, opt => opt.Ignore());
		}
	}
}
