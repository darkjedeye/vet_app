using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class LogActivityEventType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumLogActivityEventTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.LogActivityEventType, Model.Enum_LogActivityEventType>();
			Mapper.CreateMap<Model.Enum_LogActivityEventType, ViewModel.Enum.LogActivityEventType>();
		}
	}
}
