using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class PhoneNumber
	{
		/// <summary>
		/// Map a PhoneNumber Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.PhoneNumber ToViewModel(this Entity_PhoneNumber item)
		{
			return Mapper.Map<ViewModel.Entity.PhoneNumber>(item);
		}

		/// <summary>
		/// Map a list of PhoneNumber model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.PhoneNumber> ToViewModel(this List<Entity_PhoneNumber> item)
		{
			return Mapper.Map<List<Entity_PhoneNumber>, List<ViewModel.Entity.PhoneNumber>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Entity_PhoneNumber ToModel(this ViewModel.Entity.PhoneNumber item)
		{
			return Mapper.Map<Entity_PhoneNumber>(item);
		}
	}
}
