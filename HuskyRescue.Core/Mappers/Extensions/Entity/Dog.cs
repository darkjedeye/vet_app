using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Dog
	{
		/// <summary>
		/// Map a Dog dataDog Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Dog ToViewModel(this Entity_Dog item)
		{
			return Mapper.Map<ViewModel.Entity.Dog>(item);
		}

		/// <summary>
		/// Map a list of Dog dataDog model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Dog> ToViewModel(this List<Entity_Dog> item)
		{
			return Mapper.Map<List<Entity_Dog>, List<ViewModel.Entity.Dog>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Entity_Dog ToModel(this ViewModel.Entity.Dog item)
		{
			return Mapper.Map<Entity_Dog>(item);
		}
	}
}
