using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class File
	{
		/// <summary>
		/// Map a File Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.File ToViewModel(this Entity_File item)
		{
			return Mapper.Map<ViewModel.Entity.File>(item);
		}

		/// <summary>
		/// Map a list of File model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.File> ToViewModel(this List<Entity_File> item)
		{
			return Mapper.Map<List<Entity_File>, List<ViewModel.Entity.File>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Entity_File ToModel(this ViewModel.Entity.File item)
		{
			return Mapper.Map<Entity_File>(item);
		}
	}
}
