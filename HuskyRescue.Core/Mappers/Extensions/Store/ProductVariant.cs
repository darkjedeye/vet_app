using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class ProductVariant
	{
		/// <summary>
		/// Map a ProductVariant database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.ProductVariant ToViewModel(this Entity_StoreProductVariant item)
		{
			return Mapper.Map<ViewModel.Store.ProductVariant>(item);
		}

		/// <summary>
		/// Map a list of ProductVariant database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.ProductVariant> ToViewModel(this List<Entity_StoreProductVariant> item)
		{
			return Mapper.Map<List<Entity_StoreProductVariant>, List<ViewModel.Store.ProductVariant>>(item);
		}

		/// <summary>
		/// Map a ProductVariant View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreProductVariant ToModel(this ViewModel.Store.ProductVariant item)
		{
			return Mapper.Map<Entity_StoreProductVariant>(item);
		}
	}
}
