using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class Dog : Profile
	{
		public override string ProfileName
		{
			get { return "EntityDogMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.Dog, Model.Entity_Dog>();
			Mapper.CreateMap<Model.Entity_Dog, ViewModel.Entity.Dog>();
		}
	}
}
