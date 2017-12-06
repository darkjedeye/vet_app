using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class Misc : Profile
	{
		public override string ProfileName
		{
			get { return "EnumMiscMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.Misc, Model.Enum_Misc>();
			Mapper.CreateMap<Model.Enum_Misc, ViewModel.Enum.Misc>();
		}
	}
}
