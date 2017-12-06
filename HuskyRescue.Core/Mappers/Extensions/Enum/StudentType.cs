using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class StudentType
	{
		/// <summary>
		/// Map a StudentType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.StudentType ToViewModel(this Enum_StudentType item)
		{
			return Mapper.Map<ViewModel.Enum.StudentType>(item);
		}

		/// <summary>
		/// Map a list of StudentType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.StudentType> ToViewModel(this List<Enum_StudentType> item)
		{
			return Mapper.Map<List<Enum_StudentType>, List<ViewModel.Enum.StudentType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_StudentType ToModel(this ViewModel.Enum.StudentType item)
		{
			return Mapper.Map<Enum_StudentType>(item);
		}
	}
}
