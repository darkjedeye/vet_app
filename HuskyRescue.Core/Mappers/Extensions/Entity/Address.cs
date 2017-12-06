using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Address
	{
		/// <summary>
		/// Map a Address database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Address ToViewModel(this Entity_Addresses item)
		{
			return Mapper.Map<ViewModel.Entity.Address>(item);
		}

		/// <summary>
		/// Map a list of Address database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Address> ToViewModel(this List<Entity_Addresses> item)
		{
			return Mapper.Map<List<Entity_Addresses>, List<ViewModel.Entity.Address>>(item);
		}

		/// <summary>
		/// Map a Address View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_Addresses ToModel(this ViewModel.Entity.Address item)
		{
			return Mapper.Map<Entity_Addresses>(item);
		}
	}
}
