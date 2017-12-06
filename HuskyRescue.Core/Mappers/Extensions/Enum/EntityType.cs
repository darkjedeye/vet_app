using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class EntityType
	{
		/// <summary>
		/// Map a EntityType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.EntityType ToViewModel(this Enum_EntityType item)
		{
			return Mapper.Map<ViewModel.Enum.EntityType>(item);
		}

		/// <summary>
		/// Map a list of EntityType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.EntityType> ToViewModel(this List<Enum_EntityType> item)
		{
			return Mapper.Map<List<Enum_EntityType>, List<ViewModel.Enum.EntityType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_EntityType ToModel(this ViewModel.Enum.EntityType item)
		{
			return Mapper.Map<Enum_EntityType>(item);
		}
	}
}
