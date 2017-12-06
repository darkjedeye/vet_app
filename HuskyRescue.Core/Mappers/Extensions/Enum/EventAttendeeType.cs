using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class EventAttendeeType
	{
		/// <summary>
		/// Map a EventAttendeeType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.EventAttendeeType ToViewModel(this Enum_EventAttendeeType item)
		{
			return Mapper.Map<ViewModel.Enum.EventAttendeeType>(item);
		}

		/// <summary>
		/// Map a list of EventAttendeeType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.EventAttendeeType> ToViewModel(this List<Enum_EventAttendeeType> item)
		{
			return Mapper.Map<List<Enum_EventAttendeeType>, List<ViewModel.Enum.EventAttendeeType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_EventAttendeeType ToModel(this ViewModel.Enum.EventAttendeeType item)
		{
			return Mapper.Map<Enum_EventAttendeeType>(item);
		}
	}
}
