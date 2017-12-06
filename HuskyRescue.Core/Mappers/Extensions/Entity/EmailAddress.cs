using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class EmailAddress
	{
		/// <summary>
		/// Map a EmailAddress dataEmailAddress Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataEmailAddress model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.EmailAddress ToViewModel(this Entity_EmailAddress item)
		{
			return Mapper.Map<ViewModel.Entity.EmailAddress>(item);
		}

		/// <summary>
		/// Map a list of EmailAddress dataEmailAddress model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataEmailAddress model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.EmailAddress> ToViewModel(this List<Entity_EmailAddress> item)
		{
			return Mapper.Map<List<Entity_EmailAddress>, List<ViewModel.Entity.EmailAddress>>(item);
		}

		/// <summary>
		/// Map a EmailAddress View Model object to a dataEmailAddress Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataEmailAddress model object</returns>
		public static Entity_EmailAddress ToModel(this ViewModel.Entity.EmailAddress item)
		{
			return Mapper.Map<Entity_EmailAddress>(item);
		}
	}
}
