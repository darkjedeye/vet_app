using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class PaymentMethod
	{
		/// <summary>
		/// Map a PaymentMethod database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.PaymentMethod ToViewModel(this Entity_StorePaymentMethod item)
		{
			return Mapper.Map<ViewModel.Store.PaymentMethod>(item);
		}

		/// <summary>
		/// Map a list of PaymentMethod database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.PaymentMethod> ToViewModel(this List<Entity_StorePaymentMethod> item)
		{
			return Mapper.Map<List<Entity_StorePaymentMethod>, List<ViewModel.Store.PaymentMethod>>(item);
		}

		/// <summary>
		/// Map a PaymentMethod View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StorePaymentMethod ToModel(this ViewModel.Store.PaymentMethod item)
		{
			return Mapper.Map<Entity_StorePaymentMethod>(item);
		}
	}
}
