using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class UsaStates : Profile
	{
		public override string ProfileName
		{
			get { return "EnumUsaStatesMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.UsaStates, Model.Enum_UsaStates>();
			Mapper.CreateMap<Model.Enum_UsaStates, ViewModel.Enum.UsaStates>();
		}
	}
}
