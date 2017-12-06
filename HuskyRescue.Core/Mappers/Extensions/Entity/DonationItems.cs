using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class DonationItems
	{
		/// <summary>
		/// Map a DonationItems dataDonationItems Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDonationItems model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.DonationItems ToViewModel(this Entity_DonationItems item)
		{
			return Mapper.Map<ViewModel.Entity.DonationItems>(item);
		}

		/// <summary>
		/// Map a list of DonationItems dataDonationItems model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDonationItems model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.DonationItems> ToViewModel(this List<Entity_DonationItems> item)
		{
			return Mapper.Map<List<Entity_DonationItems>, List<ViewModel.Entity.DonationItems>>(item);
		}

		/// <summary>
		/// Map a DonationItems View Model object to a dataDonationItems Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDonationItems model object</returns>
		public static Entity_DonationItems ToModel(this ViewModel.Entity.DonationItems item)
		{
			return Mapper.Map<Entity_DonationItems>(item);
		}
	}
}
