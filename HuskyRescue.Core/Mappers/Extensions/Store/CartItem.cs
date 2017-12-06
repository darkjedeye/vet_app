using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class CartItem
	{
		/// <summary>
		/// Map a CartItem database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.CartItem ToViewModel(this Entity_StoreCartItem item)
		{
			return Mapper.Map<ViewModel.Store.CartItem>(item);
		}

		/// <summary>
		/// Map a list of CartItem database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.CartItem> ToViewModel(this List<Entity_StoreCartItem> item)
		{
			return Mapper.Map<List<Entity_StoreCartItem>, List<ViewModel.Store.CartItem>>(item);
		}

		/// <summary>
		/// Map a CartItem View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreCartItem ToModel(this ViewModel.Store.CartItem item)
		{
			return Mapper.Map<Entity_StoreCartItem>(item);
		}
	}
}
