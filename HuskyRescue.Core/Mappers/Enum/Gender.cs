using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class Gender : Profile
	{
		public override string ProfileName
		{
			get { return "EnumGenderMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.Gender, Model.Enum_Gender>();
			Mapper.CreateMap<Model.Enum_Gender, ViewModel.Enum.Gender>();
		}
	}
}
