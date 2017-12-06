using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class DonationItemType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumDonationItemTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.DonationItemType, Model.Enum_DonationItemType>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Value));
			Mapper.CreateMap<Model.Enum_DonationItemType, ViewModel.Enum.DonationItemType>()
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));
		}
	}
}
