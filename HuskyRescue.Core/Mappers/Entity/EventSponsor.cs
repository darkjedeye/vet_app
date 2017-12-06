using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class EventSponsor : Profile
	{
		public override string ProfileName
		{
			get { return "EventSponsorMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.EventSponsor, Model.Event_Sponsor>()
				.ForSourceMember(src => src.SponsorshipLevels, opt => opt.Ignore())
				.ForSourceMember(src => src.DonationItems, opt => opt.Ignore());
			Mapper.CreateMap<Model.Event_Sponsor, ViewModel.Entity.EventSponsor>()
				.ForMember(dest => dest.SponsorshipLevels, opt => opt.Ignore())
				.ForMember(dest => dest.DonationItems, opt => opt.Ignore());
		}
	}
}
