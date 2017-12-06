using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class OptionValue
	{
		/// <summary>
		/// Map a OptionValue database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.OptionValue ToViewModel(this Entity_StoreOptionValue item)
		{
			return Mapper.Map<ViewModel.Store.OptionValue>(item);
		}

		/// <summary>
		/// Map a list of OptionValue database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.OptionValue> ToViewModel(this List<Entity_StoreOptionValue> item)
		{
			return Mapper.Map<List<Entity_StoreOptionValue>, List<ViewModel.Store.OptionValue>>(item);
		}

		/// <summary>
		/// Map a OptionValue View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreOptionValue ToModel(this ViewModel.Store.OptionValue item)
		{
			return Mapper.Map<Entity_StoreOptionValue>(item);
		}
	}
}
