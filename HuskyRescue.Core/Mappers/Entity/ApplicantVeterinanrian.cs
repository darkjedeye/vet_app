using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class ApplicantVeterinanrian : Profile
	{
		public override string ProfileName
		{
			get { return "EntityApplicantVeterinarianMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.ApplicantVeterinarian, Model.ApplicantVeterinarian>();
			Mapper.CreateMap<Model.ApplicantVeterinarian, ViewModel.Entity.ApplicantVeterinarian>();
		}
	}
}
