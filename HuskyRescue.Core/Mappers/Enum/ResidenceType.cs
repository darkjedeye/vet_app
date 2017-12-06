using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class ResidenceType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumResidenceTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.ResidenceType, Model.Enum_ResidenceType>();
			Mapper.CreateMap<Model.Enum_ResidenceType, ViewModel.Enum.ResidenceType>();
		}
	}
}
