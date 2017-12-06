using AutoMapper;

namespace HuskyRescue.Core.Mappers.Blog
{
	public class Comments : Profile
	{
		public override string ProfileName
		{
			get { return "BlogCommentsMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Blog.Comments, Model.Blog_Comments>();
			Mapper.CreateMap<Model.Blog_Comments, ViewModel.Blog.Comments>();
		}
	}
}
