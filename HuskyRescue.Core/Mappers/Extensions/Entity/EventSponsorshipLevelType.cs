using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class EventSponsorshipLevelType
	{
		/// <summary>
		/// Map a EventSponsorshipLevelType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.EventSponsorshipLevelType ToViewModel(this Event_SponsorshipLevelTypes item)
		{
			return Mapper.Map<ViewModel.Entity.EventSponsorshipLevelType>(item);
		}

		/// <summary>
		/// Map a list of EventSponsorshipLevelType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.EventSponsorshipLevelType> ToViewModel(this List<Event_SponsorshipLevelTypes> item)
		{
			return Mapper.Map<List<Event_SponsorshipLevelTypes>, List<ViewModel.Entity.EventSponsorshipLevelType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Event_SponsorshipLevelTypes ToModel(this ViewModel.Entity.EventSponsorshipLevelType item)
		{
			return Mapper.Map<Event_SponsorshipLevelTypes>(item);
		}
	}
}
