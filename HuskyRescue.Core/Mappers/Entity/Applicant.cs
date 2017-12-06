using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class Applicant : Profile
	{
		public override string ProfileName
		{
			get { return "EntityApplicantMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.Applicant, Model.Applicant>()
				.ForMember(dest => dest.ApplicantVeterinarian, opt => opt.MapFrom(src => src.ApplicantVeterinarian))
				.ForMember(dest => dest.ApplicantOwnedAnimals, opt => opt.MapFrom(src => src.ApplicantOwnedAnimal));
			Mapper.CreateMap<Model.Applicant, ViewModel.Entity.Applicant>()
				.ForMember(dest => dest.ApplicantVeterinarian, opt => opt.MapFrom(src => src.ApplicantVeterinarian))
				.ForMember(dest => dest.ApplicantOwnedAnimal, opt => opt.MapFrom(src => src.ApplicantOwnedAnimals));
		}
	}
}
