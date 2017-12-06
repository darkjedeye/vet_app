using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class EntityType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumEntityTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.EntityType, Model.Enum_EntityType>();
			Mapper.CreateMap<Model.Enum_EntityType, ViewModel.Enum.EntityType>();
		}
	}
}
