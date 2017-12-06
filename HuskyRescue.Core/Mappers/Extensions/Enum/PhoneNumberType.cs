using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class PhoneNumberType
	{
		/// <summary>
		/// Map a PhoneNumberType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.PhoneNumberType ToViewModel(this Enum_PhoneType item)
		{
			return Mapper.Map<ViewModel.Enum.PhoneNumberType>(item);
		}

		/// <summary>
		/// Map a list of PhoneNumberType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.PhoneNumberType> ToViewModel(this List<Enum_PhoneType> item)
		{
			return Mapper.Map<List<Enum_PhoneType>, List<ViewModel.Enum.PhoneNumberType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_PhoneType ToModel(this ViewModel.Enum.PhoneNumberType item)
		{
			return Mapper.Map<Enum_PhoneType>(item);
		}
	}
}
