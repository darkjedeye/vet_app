using AutoMapper;


namespace HuskyRescue.Core.Mappers.System
{
	public class SystemConfigCategory : Profile
	{
		public override string ProfileName
		{
			get { return "SystemConfigCategoryMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.System_ConfigCategory, ViewModel.System.SystemConfigCategory>();
			Mapper.CreateMap<ViewModel.System.SystemConfigCategory, Model.System_ConfigCategory>();
		}
	}
}
