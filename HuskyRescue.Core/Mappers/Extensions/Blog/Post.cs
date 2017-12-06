using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Blog
{
	public static class Post
	{
		/// <summary>
		/// Map a Post database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Blog.Post ToViewModel(this Blog_Post item)
		{
			return Mapper.Map<ViewModel.Blog.Post>(item);
		}

		/// <summary>
		/// Map a list of Post database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Blog.Post> ToViewModel(this List<Blog_Post> item)
		{
			return Mapper.Map<List<Blog_Post>, List<ViewModel.Blog.Post>>(item);
		}

		/// <summary>
		/// Map a Post View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Blog_Post ToModel(this ViewModel.Blog.Post item)
		{
			return Mapper.Map<Blog_Post>(item);
		}
	}
}
