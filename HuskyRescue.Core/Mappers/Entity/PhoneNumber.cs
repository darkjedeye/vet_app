using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class PhoneNumber : Profile
	{
		public override string ProfileName
		{
			get { return "EntityPhoneNumberMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.PhoneNumber, Model.Entity_PhoneNumber>()
				.ForSourceMember(src => src.PhoneNumberTypeList, opt => opt.Ignore());
			Mapper.CreateMap<Model.Entity_PhoneNumber, ViewModel.Entity.PhoneNumber>()
				.ForMember(dest => dest.PhoneNumberTypeList, opt => opt.Ignore());
		}
	}
}
