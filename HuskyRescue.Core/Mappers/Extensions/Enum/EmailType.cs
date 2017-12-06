using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class EmailType
	{
		/// <summary>
		/// Map a EmailType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.EmailType ToViewModel(this Enum_EmailType item)
		{
			return Mapper.Map<ViewModel.Enum.EmailType>(item);
		}

		/// <summary>
		/// Map a list of EmailType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.EmailType> ToViewModel(this List<Enum_EmailType> item)
		{
			return Mapper.Map<List<Enum_EmailType>, List<ViewModel.Enum.EmailType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_EmailType ToModel(this ViewModel.Enum.EmailType item)
		{
			return Mapper.Map<Enum_EmailType>(item);
		}
	}
}
