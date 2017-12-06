using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.System
{
	public static class SystemConfig
	{
		/// <summary>
		/// Map a SystemConfig database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.System.SystemConfig ToViewModel(this System_Config item)
		{
			return Mapper.Map<ViewModel.System.SystemConfig>(item);
		}

		/// <summary>
		/// Map a list of SystemConfig database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.System.SystemConfig> ToViewModel(this List<System_Config> item)
		{
			return Mapper.Map<List<System_Config>, List<ViewModel.System.SystemConfig>>(item);
		}

		/// <summary>
		/// Map a SystemConfig View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static System_Config ToModel(this ViewModel.System.SystemConfig item)
		{
			return Mapper.Map<System_Config>(item);
		}
	}
}
