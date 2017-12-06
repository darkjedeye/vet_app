using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class BusinessType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumBusinessTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.BusinessType, Model.Enum_OrganisationType>();
			Mapper.CreateMap<Model.Enum_OrganisationType, ViewModel.Enum.BusinessType>();
		}
	}
}
