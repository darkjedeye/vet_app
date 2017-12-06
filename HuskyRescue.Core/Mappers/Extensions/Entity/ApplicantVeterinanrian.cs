using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class ApplicantVeterinarian
	{
		/// <summary>
		/// Map a ApplicantVeterinarian database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.ApplicantVeterinarian ToViewModel(this Model.ApplicantVeterinarian item)
		{
			return Mapper.Map<ViewModel.Entity.ApplicantVeterinarian>(item);
		}

		/// <summary>
		/// Map a list of ApplicantVeterinarian database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.ApplicantVeterinarian> ToViewModel(this List<Model.ApplicantVeterinarian> item)
		{
			return Mapper.Map<List<Model.ApplicantVeterinarian>, List<ViewModel.Entity.ApplicantVeterinarian>>(item);
		}

		/// <summary>
		/// Map a ApplicantVeterinarian View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Model.ApplicantVeterinarian ToModel(this ViewModel.Entity.ApplicantVeterinarian item)
		{
			return Mapper.Map<Model.ApplicantVeterinarian>(item);
		}
	}
}
