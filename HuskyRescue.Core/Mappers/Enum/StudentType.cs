using AutoMapper;

namespace HuskyRescue.Core.Mappers.Enum
{
	public class StudentType : Profile
	{
		public override string ProfileName
		{
			get { return "EnumStudentTypeMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Enum.StudentType, Model.Enum_StudentType>();
			Mapper.CreateMap<Model.Enum_StudentType, ViewModel.Enum.StudentType>();
		}
	}
}
