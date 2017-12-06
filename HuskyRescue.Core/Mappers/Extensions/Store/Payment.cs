using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class Payment
	{
		/// <summary>
		/// Map a Payment database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.Payment ToViewModel(this Entity_StorePayment item)
		{
			return Mapper.Map<ViewModel.Store.Payment>(item);
		}

		/// <summary>
		/// Map a list of Payment database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.Payment> ToViewModel(this List<Entity_StorePayment> item)
		{
			return Mapper.Map<List<Entity_StorePayment>, List<ViewModel.Store.Payment>>(item);
		}

		/// <summary>
		/// Map a Payment View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StorePayment ToModel(this ViewModel.Store.Payment item)
		{
			return Mapper.Map<Entity_StorePayment>(item);
		}
	}
}
