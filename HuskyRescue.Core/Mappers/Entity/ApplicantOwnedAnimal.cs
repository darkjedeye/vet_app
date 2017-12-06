using AutoMapper;

namespace HuskyRescue.Core.Mappers.Entity
{
	public class ApplicantOwnedAnimal : Profile
	{
		public override string ProfileName
		{
			get { return "EntityApplicantOwnedAnimalMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.ApplicantOwnedAnimal, Model.ApplicantOwnedAnimal>();
			Mapper.CreateMap<Model.ApplicantOwnedAnimal, ViewModel.Entity.ApplicantOwnedAnimal>();
		}
	}
}
