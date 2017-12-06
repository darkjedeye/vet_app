using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class Cart
	{
		/// <summary>
		/// Map a Cart database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.Cart ToViewModel(this Entity_StoreCart item)
		{
			return Mapper.Map<ViewModel.Store.Cart>(item);
		}

		/// <summary>
		/// Map a list of Cart database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.Cart> ToViewModel(this List<Entity_StoreCart> item)
		{
			return Mapper.Map<List<Entity_StoreCart>, List<ViewModel.Store.Cart>>(item);
		}

		/// <summary>
		/// Map a Cart View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreCart ToModel(this ViewModel.Store.Cart item)
		{
			return Mapper.Map<Entity_StoreCart>(item);
		}
	}
}
