using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class Shipment
	{
		/// <summary>
		/// Map a Shipment database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.Shipment ToViewModel(this Entity_StoreShipment item)
		{
			return Mapper.Map<ViewModel.Store.Shipment>(item);
		}

		/// <summary>
		/// Map a list of Shipment database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.Shipment> ToViewModel(this List<Entity_StoreShipment> item)
		{
			return Mapper.Map<List<Entity_StoreShipment>, List<ViewModel.Store.Shipment>>(item);
		}

		/// <summary>
		/// Map a Shipment View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreShipment ToModel(this ViewModel.Store.Shipment item)
		{
			return Mapper.Map<Entity_StoreShipment>(item);
		}
	}
}
