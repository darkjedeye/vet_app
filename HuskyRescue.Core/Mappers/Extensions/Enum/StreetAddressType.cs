using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class StreetAddressType
	{
		/// <summary>
		/// Map a StreetAddressType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.StreetAddressType ToViewModel(this Enum_AddressType item)
		{
			return Mapper.Map<ViewModel.Enum.StreetAddressType>(item);
		}

		/// <summary>
		/// Map a list of StreetAddressType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.StreetAddressType> ToViewModel(this List<Enum_AddressType> item)
		{
			return Mapper.Map<List<Enum_AddressType>, List<ViewModel.Enum.StreetAddressType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_AddressType ToModel(this ViewModel.Enum.StreetAddressType item)
		{
			return Mapper.Map<Enum_AddressType>(item);
		}
	}
}
