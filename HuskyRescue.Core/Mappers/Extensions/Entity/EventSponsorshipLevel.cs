using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class EventSponsorshipLevel
	{
		/// <summary>
		/// Map a EventSponsorshipLevel Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.EventSponsorshipLevel ToViewModel(this Event_SponsorshipLevel item)
		{
			return Mapper.Map<ViewModel.Entity.EventSponsorshipLevel>(item);
		}

		/// <summary>
		/// Map a list of EventSponsorshipLevel model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.EventSponsorshipLevel> ToViewModel(this List<Event_SponsorshipLevel> item)
		{
			return Mapper.Map<List<Event_SponsorshipLevel>, List<ViewModel.Entity.EventSponsorshipLevel>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Event_SponsorshipLevel ToModel(this ViewModel.Entity.EventSponsorshipLevel item)
		{
			return Mapper.Map<Event_SponsorshipLevel>(item);
		}
	}
}
