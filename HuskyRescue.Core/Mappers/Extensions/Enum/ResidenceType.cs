﻿using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Enum
{
	public static class ResidenceType
	{
		/// <summary>
		/// Map a ResidenceType Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataDog model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Enum.ResidenceType ToViewModel(this Enum_ResidenceType item)
		{
			return Mapper.Map<ViewModel.Enum.ResidenceType>(item);
		}

		/// <summary>
		/// Map a list of ResidenceType model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataDog model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Enum.ResidenceType> ToViewModel(this List<Enum_ResidenceType> item)
		{
			return Mapper.Map<List<Enum_ResidenceType>, List<ViewModel.Enum.ResidenceType>>(item);
		}

		/// <summary>
		/// Map a Dog View Model object to a dataDog Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataDog model object</returns>
		public static Enum_ResidenceType ToModel(this ViewModel.Enum.ResidenceType item)
		{
			return Mapper.Map<Enum_ResidenceType>(item);
		}
	}
}
