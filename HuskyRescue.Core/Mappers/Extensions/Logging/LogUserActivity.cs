using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Logging
{
	public static class LogUserActivity
	{
		/// <summary>
		/// Map a SystemConfig database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Logging.LogUserActivity ToViewModel(this Model.LogUserActivity item)
		{
			return Mapper.Map<ViewModel.Logging.LogUserActivity>(item);
		}

		/// <summary>
		/// Map a list of SystemConfig database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Logging.LogUserActivity> ToViewModel(this List<Model.LogUserActivity> item)
		{
			return Mapper.Map<List<Model.LogUserActivity>, List<ViewModel.Logging.LogUserActivity>>(item);
		}

		/// <summary>
		/// Map a SystemConfig View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Model.LogUserActivity ToModel(this ViewModel.Logging.LogUserActivity item)
		{
			return Mapper.Map<Model.LogUserActivity>(item);
		}
	}
}
