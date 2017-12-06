using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Blog
{
	public static class Tags
	{
		/// <summary>
		/// Map a Tags database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Blog.Tags ToViewModel(this Blog_Tags item)
		{
			return Mapper.Map<ViewModel.Blog.Tags>(item);
		}

		/// <summary>
		/// Map a list of Tags database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Blog.Tags> ToViewModel(this List<Blog_Tags> item)
		{
			return Mapper.Map<List<Blog_Tags>, List<ViewModel.Blog.Tags>>(item);
		}

		/// <summary>
		/// Map a Tags View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Blog_Tags ToModel(this ViewModel.Blog.Tags item)
		{
			return Mapper.Map<Blog_Tags>(item);
		}
	}
}
