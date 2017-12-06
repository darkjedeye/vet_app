using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class Product
	{
		/// <summary>
		/// Map a Product database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.Product ToViewModel(this Entity_StoreProduct item)
		{
			return Mapper.Map<ViewModel.Store.Product>(item);
		}

		/// <summary>
		/// Map a list of Product database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.Product> ToViewModel(this List<Entity_StoreProduct> item)
		{
			return Mapper.Map<List<Entity_StoreProduct>, List<ViewModel.Store.Product>>(item);
		}

		/// <summary>
		/// Map a Product View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreProduct ToModel(this ViewModel.Store.Product item)
		{
			return Mapper.Map<Entity_StoreProduct>(item);
		}
	}
}
