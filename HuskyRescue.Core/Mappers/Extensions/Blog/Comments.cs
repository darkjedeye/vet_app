using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Blog
{
	public static class Comments
	{
		/// <summary>
		/// Map a Comments database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Blog.Comments ToViewModel(this Blog_Comments item)
		{
			return Mapper.Map<ViewModel.Blog.Comments>(item);
		}

		/// <summary>
		/// Map a list of Comments database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Blog.Comments> ToViewModel(this List<Blog_Comments> item)
		{
			return Mapper.Map<List<Blog_Comments>, List<ViewModel.Blog.Comments>>(item);
		}

		/// <summary>
		/// Map a Comments View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Blog_Comments ToModel(this ViewModel.Blog.Comments item)
		{
			return Mapper.Map<Blog_Comments>(item);
		}
	}
}
