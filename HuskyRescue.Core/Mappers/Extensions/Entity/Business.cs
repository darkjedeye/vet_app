using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Business
	{
		/// <summary>
		/// Map a Business dataBusiness Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">dataBusiness model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Business ToViewModel(this Entity_Organisation item)
		{
			return Mapper.Map<ViewModel.Entity.Business>(item);
		}

		/// <summary>
		/// Map a list of Business dataBusiness model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of dataBusiness model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Business> ToViewModel(this List<Entity_Organisation> item)
		{
			return Mapper.Map<List<Entity_Organisation>, List<ViewModel.Entity.Business>>(item);
		}

		/// <summary>
		/// Map a Business View Model object to a dataBusiness Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>dataBusiness model object</returns>
		public static Entity_Organisation ToModel(this ViewModel.Entity.Business item)
		{
			return Mapper.Map<Entity_Organisation>(item);
		}
	}
}
