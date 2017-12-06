﻿using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class PetDepositCoverageType
	{
		/// <summary>
		/// Map a PetDepositCoverageType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.PetDepositCoverageType ToViewModel(this Enum_PetDepositCoverage item)
		{
			return Mapper.Map<ViewModel.Enum.PetDepositCoverageType>(item);
		}

		/// <summary>
		/// Map a list of PetDepositCoverageType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.PetDepositCoverageType> ToViewModel(this List<Enum_PetDepositCoverage> item)
		{
			return Mapper.Map<List<Enum_PetDepositCoverage>, List<ViewModel.Enum.PetDepositCoverageType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_PetDepositCoverage ToModel(this ViewModel.Enum.PetDepositCoverageType item)
		{
			return Mapper.Map<Enum_PetDepositCoverage>(item);
		}
	}
}
