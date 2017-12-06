using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class DonationItemType
	{
		/// <summary>
		/// Map a DonationItemType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.DonationItemType ToViewModel(this Enum_DonationItemType item)
		{
			return Mapper.Map<ViewModel.Enum.DonationItemType>(item);
		}

		/// <summary>
		/// Map a list of DonationItemType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.DonationItemType> ToViewModel(this List<Enum_DonationItemType> item)
		{
			return Mapper.Map<List<Enum_DonationItemType>, List<ViewModel.Enum.DonationItemType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_DonationItemType ToModel(this ViewModel.Enum.DonationItemType item)
		{
			return Mapper.Map<Enum_DonationItemType>(item);
		}
	}
}
