using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Donation
	{
		/// <summary>
		/// Map a Donation dataDonation Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDonation model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Donation ToViewModel(this Entity_Donation item)
		{
			return Mapper.Map<ViewModel.Entity.Donation>(item);
		}

		/// <summary>
		/// Map a list of Donation dataDonation model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDonation model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Donation> ToViewModel(this List<Entity_Donation> item)
		{
			return Mapper.Map<List<Entity_Donation>, List<ViewModel.Entity.Donation>>(item);
		}

		/// <summary>
		/// Map a Donation View Model object to a dataDonation Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDonation model object</returns>
		public static Entity_Donation ToModel(this ViewModel.Entity.Donation item)
		{
			return Mapper.Map<Entity_Donation>(item);
		}
	}
}
