using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.System
{
	public static class SystemConfigCategory
	{
		/// <summary>
		/// Map a SystemConfigCategory database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.System.SystemConfigCategory ToViewModel(this System_ConfigCategory item)
		{
			return Mapper.Map<ViewModel.System.SystemConfigCategory>(item);
		}

		/// <summary>
		/// Map a list of SystemConfigCategory database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.System.SystemConfigCategory> ToViewModel(this List<System_ConfigCategory> item)
		{
			return Mapper.Map<List<System_ConfigCategory>, List<ViewModel.System.SystemConfigCategory>>(item);
		}

		/// <summary>
		/// Map a SystemConfigCategory View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static System_ConfigCategory ToModel(this ViewModel.System.SystemConfigCategory item)
		{
			return Mapper.Map<System_ConfigCategory>(item);
		}
	}
}
