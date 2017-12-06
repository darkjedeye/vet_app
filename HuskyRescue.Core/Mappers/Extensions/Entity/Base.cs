using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Base
	{
		/// <summary>
		/// Map a Base database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Base ToViewModel(this Entity_Base item)
		{
			return Mapper.Map<ViewModel.Entity.Base>(item);
		}

		/// <summary>
		/// Map a list of Base database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Base> ToViewModel(this List<Entity_Base> item)
		{
			return Mapper.Map<List<Entity_Base>, List<ViewModel.Entity.Base>>(item);
		}

		/// <summary>
		/// Map a Base View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Entity_Base ToModel(this ViewModel.Entity.Base item)
		{
			return Mapper.Map<Entity_Base>(item);
		}
	}
}
