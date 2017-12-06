using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class ResidenceOwnershipType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumResidenceOwnershipTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.ResidenceOwnershipType, Model.Enum_ResidenceOwnershipType>();
			Mapper.CreateMap<Model.Enum_ResidenceOwnershipType, ViewModel.Enum.ResidenceOwnershipType>();
		}
	}
}
