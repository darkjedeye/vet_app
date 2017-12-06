using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class ShippingMethod
	{
		/// <summary>
		/// Map a ShippingMethod database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.ShippingMethod ToViewModel(this Entity_StoreShippingMethod item)
		{
			return Mapper.Map<ViewModel.Store.ShippingMethod>(item);
		}

		/// <summary>
		/// Map a list of ShippingMethod database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.ShippingMethod> ToViewModel(this List<Entity_StoreShippingMethod> item)
		{
			return Mapper.Map<List<Entity_StoreShippingMethod>, List<ViewModel.Store.ShippingMethod>>(item);
		}

		/// <summary>
		/// Map a ShippingMethod View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreShippingMethod ToModel(this ViewModel.Store.ShippingMethod item)
		{
			return Mapper.Map<Entity_StoreShippingMethod>(item);
		}
	}
}
