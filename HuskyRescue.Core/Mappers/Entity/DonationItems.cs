using AutoMapper;


namespace HuskyRescue.Core.Mappers.Entity
{
	public class DonationItems : Profile
	{
		public override string ProfileName
		{
			get { return "EntityDonationItemsMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Entity.DonationItems, Model.Entity_DonationItems>();
			Mapper.CreateMap<Model.Entity_DonationItems, ViewModel.Entity.DonationItems>();
		}
	}
}
