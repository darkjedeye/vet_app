using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Events
	{
		/// <summary>
		/// Map a Events Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Event ToViewModel(this Event item)
		{
			return Mapper.Map<ViewModel.Entity.Event>(item);
		}

		/// <summary>
		/// Map a list of Events model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Event> ToViewModel(this List<Event> item)
		{
			return Mapper.Map<List<Event>, List<ViewModel.Entity.Event>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Event ToModel(this ViewModel.Entity.Event item)
		{
			return Mapper.Map<Event>(item);
		}
	}
}
