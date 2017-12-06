using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class OrderDetail
	{
		/// <summary>
		/// Map a OrderDetail database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.OrderDetail ToViewModel(this Entity_StoreOrderDetail item)
		{
			return Mapper.Map<ViewModel.Store.OrderDetail>(item);
		}

		/// <summary>
		/// Map a list of OrderDetail database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.OrderDetail> ToViewModel(this List<Entity_StoreOrderDetail> item)
		{
			return Mapper.Map<List<Entity_StoreOrderDetail>, List<ViewModel.Store.OrderDetail>>(item);
		}

		/// <summary>
		/// Map a OrderDetail View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreOrderDetail ToModel(this ViewModel.Store.OrderDetail item)
		{
			return Mapper.Map<Entity_StoreOrderDetail>(item);
		}
	}
}
