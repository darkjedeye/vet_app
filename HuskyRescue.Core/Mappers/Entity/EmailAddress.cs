using AutoMapper;

namespace HuskyRescue.Core.Mappers.Entity
{
	public class EmailAddress : Profile
	{
		public override string ProfileName
		{
			get { return "EntityEmailAddressMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.EmailAddress, Model.Entity_EmailAddress>()
				.ForSourceMember(src => src.EmailTypeList, opt => opt.Ignore());
			Mapper.CreateMap<Model.Entity_EmailAddress, ViewModel.Entity.EmailAddress>()
				.ForMember(dest => dest.EmailTypeList, opt => opt.Ignore());
		}
	}
}
