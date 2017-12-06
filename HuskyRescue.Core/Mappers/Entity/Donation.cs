using AutoMapper;

namespace HuskyRescue.Core.Mappers.Entity
{
	public class Donation : Profile
	{
		public override string ProfileName
		{
			get { return "EntityDonationMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.Donation, Model.Entity_Donation>();
			Mapper.CreateMap<Model.Entity_Donation, ViewModel.Entity.Donation>();
		}
	}
}
