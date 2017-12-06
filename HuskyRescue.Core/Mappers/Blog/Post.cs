using AutoMapper;

namespace HuskyRescue.Core.Mappers.Blog
{
	public class Post : Profile
	{
		public override string ProfileName
		{
			get { return "BlogPostMappings"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Blog.Post, Model.Blog_Post>()
				.ForMember(dest => dest.Blog_Tags, opt => opt.MapFrom(src => src.Tags))
				.ForMember(dest => dest.Blog_Comments, opt => opt.MapFrom(src => src.Comments));
			Mapper.CreateMap<Model.Blog_Post, ViewModel.Blog.Post>()
				.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Blog_Tags))
				.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Blog_Comments));
		}
	}
}
