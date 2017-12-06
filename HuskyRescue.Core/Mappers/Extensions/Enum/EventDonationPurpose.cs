using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class EventDonationPurpose
	{
		/// <summary>
		/// Map a EventDonationPurpose Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.EventDonationPurpose ToViewModel(this Enum_EventDonationPurpose item)
		{
			return Mapper.Map<ViewModel.Enum.EventDonationPurpose>(item);
		}

		/// <summary>
		/// Map a list of EventDonationPurpose model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.EventDonationPurpose> ToViewModel(this List<Enum_EventDonationPurpose> item)
		{
			return Mapper.Map<List<Enum_EventDonationPurpose>, List<ViewModel.Enum.EventDonationPurpose>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_EventDonationPurpose ToModel(this ViewModel.Enum.EventDonationPurpose item)
		{
			return Mapper.Map<Enum_EventDonationPurpose>(item);
		}
	}
}
