using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class EventRegistration
	{
		/// <summary>
		/// Map a EventRegistration Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.EventRegistration ToViewModel(this Event_Registration item)
		{
			return Mapper.Map<ViewModel.Entity.EventRegistration>(item);
		}

		/// <summary>
		/// Map a list of EventRegistration model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.EventRegistration> ToViewModel(this List<Event_Registration> item)
		{
			return Mapper.Map<List<Event_Registration>, List<ViewModel.Entity.EventRegistration>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Event_Registration ToModel(this ViewModel.Entity.EventRegistration item)
		{
			return Mapper.Map<Event_Registration>(item);
		}
	}
}
