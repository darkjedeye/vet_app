using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class EventType
	{
		/// <summary>
		/// Map a EventType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.EventType ToViewModel(this Enum_EventType item)
		{
			return Mapper.Map<ViewModel.Enum.EventType>(item);
		}

		/// <summary>
		/// Map a list of EventType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.EventType> ToViewModel(this List<Enum_EventType> item)
		{
			return Mapper.Map<List<Enum_EventType>, List<ViewModel.Enum.EventType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_EventType ToModel(this ViewModel.Enum.EventType item)
		{
			return Mapper.Map<Enum_EventType>(item);
		}
	}
}
