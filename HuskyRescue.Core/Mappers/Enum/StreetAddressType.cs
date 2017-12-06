using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class StreetAddressType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumStreetAddressMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.StreetAddressType, Model.Enum_AddressType>();
			Mapper.CreateMap<Model.Enum_AddressType, ViewModel.Enum.StreetAddressType>();
		}
	}
}
