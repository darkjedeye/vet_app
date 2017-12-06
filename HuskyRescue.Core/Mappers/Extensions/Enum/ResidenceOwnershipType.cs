using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class ResidenceOwnershipType
	{
		/// <summary>
		/// Map a ResidenceOwnershipType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.ResidenceOwnershipType ToViewModel(this Enum_ResidenceOwnershipType item)
		{
			return Mapper.Map<ViewModel.Enum.ResidenceOwnershipType>(item);
		}

		/// <summary>
		/// Map a list of ResidenceOwnershipType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.ResidenceOwnershipType> ToViewModel(this List<Enum_ResidenceOwnershipType> item)
		{
			return Mapper.Map<List<Enum_ResidenceOwnershipType>, List<ViewModel.Enum.ResidenceOwnershipType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_ResidenceOwnershipType ToModel(this ViewModel.Enum.ResidenceOwnershipType item)
		{
			return Mapper.Map<Enum_ResidenceOwnershipType>(item);
		}
	}
}
