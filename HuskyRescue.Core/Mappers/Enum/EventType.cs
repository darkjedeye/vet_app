using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class EventType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumEventTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.EventType, Model.Enum_EventType>();
			Mapper.CreateMap<Model.Enum_EventType, ViewModel.Enum.EventType>();
		}
	}
}
