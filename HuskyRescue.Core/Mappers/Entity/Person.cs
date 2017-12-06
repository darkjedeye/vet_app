using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class Person : Profile
	{
		public override string ProfileName
		{
			get { return "EntityPersonMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.Person, Model.Entity_Person>()
				.ForMember(dest => dest.Entity_Base, opt => opt.MapFrom(src => src.Base));
			Mapper.CreateMap<Model.Entity_Person, ViewModel.Entity.Person>()
				.ForMember(dest => dest.Base, opt => opt.MapFrom(src => src.Entity_Base));
		}
	}
}
