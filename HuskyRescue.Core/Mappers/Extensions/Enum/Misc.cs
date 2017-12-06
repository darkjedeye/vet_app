using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class Misc
	{
		/// <summary>
		/// Map a Misc Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.Misc ToViewModel(this Enum_Misc item)
		{
			return Mapper.Map<ViewModel.Enum.Misc>(item);
		}

		/// <summary>
		/// Map a list of Misc model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.Misc> ToViewModel(this List<Enum_Misc> item)
		{
			return Mapper.Map<List<Enum_Misc>, List<ViewModel.Enum.Misc>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_Misc ToModel(this ViewModel.Enum.Misc item)
		{
			return Mapper.Map<Enum_Misc>(item);
		}
	}
}
