using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class EmailType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumEmailTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.EmailType, Model.Enum_EmailType>();
			Mapper.CreateMap<Model.Enum_EmailType, ViewModel.Enum.EmailType>();
		}
	}
}
