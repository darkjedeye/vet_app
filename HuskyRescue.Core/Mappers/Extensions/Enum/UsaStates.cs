using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class UsaStates
	{
		/// <summary>
		/// Map a UsaStates Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.UsaStates ToViewModel(this Enum_UsaStates item)
		{
			return Mapper.Map<ViewModel.Enum.UsaStates>(item);
		}

		/// <summary>
		/// Map a list of UsaStates model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.UsaStates> ToViewModel(this List<Enum_UsaStates> item)
		{
			return Mapper.Map<List<Enum_UsaStates>, List<ViewModel.Enum.UsaStates>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_UsaStates ToModel(this ViewModel.Enum.UsaStates item)
		{
			return Mapper.Map<Enum_UsaStates>(item);
		}
	}
}
