using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class PhoneNumberType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumPhoneNumberTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.PhoneNumberType, Model.Enum_PhoneType>();
			Mapper.CreateMap<Model.Enum_PhoneType, ViewModel.Enum.PhoneNumberType>();
		}
	}
}
