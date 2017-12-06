using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class EventDonationPurpose : Profile
	{
		public override string ProfileName
		{
			get { return "EnumEventDonationPurposeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.EventDonationPurpose, Model.Enum_EventDonationPurpose>();
			Mapper.CreateMap<Model.Enum_EventDonationPurpose, ViewModel.Enum.EventDonationPurpose>();
		}
	}
}
