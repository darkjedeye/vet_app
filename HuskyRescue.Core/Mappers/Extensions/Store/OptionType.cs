﻿using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Store
{
	public static class OptionType
	{
		/// <summary>
		/// Map a OptionType database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Store.OptionType ToViewModel(this Entity_StoreOptionType item)
		{
			return Mapper.Map<ViewModel.Store.OptionType>(item);
		}

		/// <summary>
		/// Map a list of OptionType database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Store.OptionType> ToViewModel(this List<Entity_StoreOptionType> item)
		{
			return Mapper.Map<List<Entity_StoreOptionType>, List<ViewModel.Store.OptionType>>(item);
		}

		/// <summary>
		/// Map a OptionType View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_StoreOptionType ToModel(this ViewModel.Store.OptionType item)
		{
			return Mapper.Map<Entity_StoreOptionType>(item);
		}
	}
}