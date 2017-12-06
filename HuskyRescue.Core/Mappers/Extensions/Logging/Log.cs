using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Logging
{
	public static class Log
	{
		/// <summary>
		/// Map a Log database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Logging.Log ToViewModel(this Model.Log item)
		{
			return Mapper.Map<ViewModel.Logging.Log>(item);
		}

		/// <summary>
		/// Map a list of Log database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Logging.Log> ToViewModel(this List<Model.Log> item)
		{
			return Mapper.Map<List<Model.Log>, List<ViewModel.Logging.Log>>(item);
		}

		/// <summary>
		/// Map a Log View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Model.Log ToModel(this ViewModel.Logging.Log item)
		{
			return Mapper.Map<Model.Log>(item);
		}
	}
}
