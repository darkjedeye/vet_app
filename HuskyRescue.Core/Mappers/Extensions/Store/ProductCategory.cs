using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class ProductCategory
	{
		/// <summary>
		/// Map a ProductCategory database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.ProductCategory ToViewModel(this Entity_StoreCategory item)
		{
			return Mapper.Map<ViewModel.Store.ProductCategory>(item);
		}

		/// <summary>
		/// Map a list of ProductCategory database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.ProductCategory> ToViewModel(this List<Entity_StoreCategory> item)
		{
			return Mapper.Map<List<Entity_StoreCategory>, List<ViewModel.Store.ProductCategory>>(item);
		}

		/// <summary>
		/// Map a ProductCategory View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreCategory ToModel(this ViewModel.Store.ProductCategory item)
		{
			return Mapper.Map<Entity_StoreCategory>(item);
		}
	}
}
