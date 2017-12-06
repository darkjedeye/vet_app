using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class Gender
	{
		/// <summary>
		/// Map a Gender Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.Gender ToViewModel(this Enum_Gender item)
		{
			return Mapper.Map<ViewModel.Enum.Gender>(item);
		}

		/// <summary>
		/// Map a list of Gender model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.Gender> ToViewModel(this List<Enum_Gender> item)
		{
			return Mapper.Map<List<Enum_Gender>, List<ViewModel.Enum.Gender>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_Gender ToModel(this ViewModel.Enum.Gender item)
		{
			return Mapper.Map<Enum_Gender>(item);
		}
	}
}
