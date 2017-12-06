using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class ProductImage
	{
		/// <summary>
		/// Map a ProductImage database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.ProductImage ToViewModel(this Entity_StoreProductImage item)
		{
			return Mapper.Map<ViewModel.Store.ProductImage>(item);
		}

		/// <summary>
		/// Map a list of ProductImage database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.ProductImage> ToViewModel(this List<Entity_StoreProductImage> item)
		{
			return Mapper.Map<List<Entity_StoreProductImage>, List<ViewModel.Store.ProductImage>>(item);
		}

		/// <summary>
		/// Map a ProductImage View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreProductImage ToModel(this ViewModel.Store.ProductImage item)
		{
			return Mapper.Map<Entity_StoreProductImage>(item);
		}
	}
}
