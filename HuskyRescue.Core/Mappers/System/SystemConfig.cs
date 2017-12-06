using AutoMapper;


namespace HuskyRescue.Core.Mappers.System
{
	public class SystemConfig : Profile
	{
		public override string ProfileName
		{
			get { return "SystemConfigMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<Model.System_Config, ViewModel.System.SystemConfig>()
				.ForMember(dest => dest.SettingName, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.SettingValue, opt => opt.MapFrom(src => src.Value))
				.ForMember(dest => dest.SettingDescription, opt => opt.MapFrom(src => src.Description))
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.System_ConfigCategory));
			Mapper.CreateMap<ViewModel.System.SystemConfig, Model.System_Config>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SettingName))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.SettingValue))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.SettingDescription))
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName))
				.ForSourceMember(src => src.Category, opt => opt.Ignore());
		}
	}
}
