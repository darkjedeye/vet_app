using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class ProductProperty
	{
		/// <summary>
		/// Map a ProductProperty database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.ProductProperty ToViewModel(this Entity_StoreProperty item)
		{
			return Mapper.Map<ViewModel.Store.ProductProperty>(item);
		}

		/// <summary>
		/// Map a list of ProductProperty database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.ProductProperty> ToViewModel(this List<Entity_StoreProperty> item)
		{
			return Mapper.Map<List<Entity_StoreProperty>, List<ViewModel.Store.ProductProperty>>(item);
		}

		/// <summary>
		/// Map a ProductProperty View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreProperty ToModel(this ViewModel.Store.ProductProperty item)
		{
			return Mapper.Map<Entity_StoreProperty>(item);
		}
	}
}
