using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class Order
	{
		/// <summary>
		/// Map a Order database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.Order ToViewModel(this Entity_StoreOrder item)
		{
			return Mapper.Map<ViewModel.Store.Order>(item);
		}

		/// <summary>
		/// Map a list of Order database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.Order> ToViewModel(this List<Entity_StoreOrder> item)
		{
			return Mapper.Map<List<Entity_StoreOrder>, List<ViewModel.Store.Order>>(item);
		}

		/// <summary>
		/// Map a Order View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreOrder ToModel(this ViewModel.Store.Order item)
		{
			return Mapper.Map<Entity_StoreOrder>(item);
		}
	}
}
