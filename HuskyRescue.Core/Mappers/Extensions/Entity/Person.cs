using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Person
	{
		/// <summary>
		/// Map a Person Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Person ToViewModel(this Entity_Person item)
		{
			return Mapper.Map<ViewModel.Entity.Person>(item);
		}

		/// <summary>
		/// Map a list of Person model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Person> ToViewModel(this List<Entity_Person> item)
		{
			return Mapper.Map<List<Entity_Person>, List<ViewModel.Entity.Person>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Entity_Person ToModel(this ViewModel.Entity.Person item)
		{
			return Mapper.Map<Entity_Person>(item);
		}
	}
}
