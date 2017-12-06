using AutoMapper;

namespace HuskyRescue.Core.Mappers.Blog
{
	public class Tags : Profile
	{
		public override string ProfileName
		{
			get { return "BlogTagsMappings"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Blog.Tags, Model.Blog_Tags>();
			Mapper.CreateMap<Model.Blog_Tags, ViewModel.Blog.Tags>();
		}
	}
}
