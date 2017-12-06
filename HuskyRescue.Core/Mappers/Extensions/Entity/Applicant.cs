using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class Applicant
	{
		/// <summary>
		/// Map a Applicant database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.Applicant ToViewModel(this Model.Applicant item)
		{
			return Mapper.Map<ViewModel.Entity.Applicant>(item);
		}

		/// <summary>
		/// Map a list of Applicant database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.Applicant> ToViewModel(this List<Model.Applicant> item)
		{
			return Mapper.Map<List<Model.Applicant>, List<ViewModel.Entity.Applicant>>(item);
		}

		/// <summary>
		/// Map a Applicant View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Model.Applicant ToModel(this ViewModel.Entity.Applicant item)
		{
			return Mapper.Map<Model.Applicant>(item);
		}
	}
}
