using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class EventAttendeeType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumEventAttendeeTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.EventAttendeeType, Model.Enum_EventAttendeeType>();
			Mapper.CreateMap<Model.Enum_EventAttendeeType, ViewModel.Enum.EventAttendeeType>();
		}
	}
}
