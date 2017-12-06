using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class EventAttendee
	{
		/// <summary>
		/// Map a EventAttendee Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.EventAttendee ToViewModel(this Event_Attendee item)
		{
			return Mapper.Map<ViewModel.Entity.EventAttendee>(item);
		}

		/// <summary>
		/// Map a list of EventAttendee model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.EventAttendee> ToViewModel(this List<Event_Attendee> item)
		{
			return Mapper.Map<List<Event_Attendee>, List<ViewModel.Entity.EventAttendee>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Event_Attendee ToModel(this ViewModel.Entity.EventAttendee item)
		{
			return Mapper.Map<Event_Attendee>(item);
		}
	}
}
