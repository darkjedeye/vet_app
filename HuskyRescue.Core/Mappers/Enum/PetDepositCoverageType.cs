using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class PetDepositCoverageType : Profile
	{
		public override string ProfileName
		{
			get
			{
				return "EnumPetDepositCoverageTypeMapping";
			}
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.PetDepositCoverageType, Model.Enum_PetDepositCoverage>();
			Mapper.CreateMap<Model.Enum_PetDepositCoverage, ViewModel.Enum.PetDepositCoverageType>();
		}
	}
}
