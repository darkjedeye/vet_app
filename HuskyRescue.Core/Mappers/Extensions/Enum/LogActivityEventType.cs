using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class LogActivityEventType
	{
		/// <summary>
		/// Map a LogActivityEventType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.LogActivityEventType ToViewModel(this Enum_LogActivityEventType item)
		{
			return Mapper.Map<ViewModel.Enum.LogActivityEventType>(item);
		}

		/// <summary>
		/// Map a list of LogActivityEventType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.LogActivityEventType> ToViewModel(this List<Enum_LogActivityEventType> item)
		{
			return Mapper.Map<List<Enum_LogActivityEventType>, List<ViewModel.Enum.LogActivityEventType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_LogActivityEventType ToModel(this ViewModel.Enum.LogActivityEventType item)
		{
			return Mapper.Map<Enum_LogActivityEventType>(item);
		}
	}
}
