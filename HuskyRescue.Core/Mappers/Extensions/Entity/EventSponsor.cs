using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class EventSponsor
	{
		/// <summary>
		/// Map a EventSponsor Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.EventSponsor ToViewModel(this Event_Sponsor item)
		{
			return Mapper.Map<ViewModel.Entity.EventSponsor>(item);
		}

		/// <summary>
		/// Map a list of EventSponsor model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.EventSponsor> ToViewModel(this List<Event_Sponsor> item)
		{
			return Mapper.Map<List<Event_Sponsor>, List<ViewModel.Entity.EventSponsor>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Event_Sponsor ToModel(this ViewModel.Entity.EventSponsor item)
		{
			return Mapper.Map<Event_Sponsor>(item);
		}
	}
}
