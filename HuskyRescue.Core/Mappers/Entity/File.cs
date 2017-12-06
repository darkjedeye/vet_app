using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class File : Profile
	{
		public override string ProfileName
		{
			get { return "EntityFileMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.File, Model.Entity_File>()
				.ForMember(dest => dest.PersonID, opt => opt.ResolveUsing(src => src.PersonID ?? null))
				.ForMember(dest => dest.OrgID, opt => opt.ResolveUsing(src => src.BusinessID ?? null))
				.ForMember(dest => dest.DogID, opt => opt.ResolveUsing(src => src.DogID ?? null));

			Mapper.CreateMap<Model.Entity_File, ViewModel.Entity.File>();
		}
	}
}
