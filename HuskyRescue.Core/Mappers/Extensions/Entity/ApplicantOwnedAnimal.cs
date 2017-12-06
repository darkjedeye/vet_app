using System.Collections.Generic;
using AutoMapper;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Mappers.Extensions.Entity
{
	public static class ApplicantOwnedAnimal
	{
		/// <summary>
		/// Map a ApplicantOwnedAnimal database Model object to a View Model object for presentation
		/// </summary>
		/// <param name="item">database model object</param>
		/// <returns>view model presentation object</returns>
		public static ViewModel.Entity.ApplicantOwnedAnimal ToViewModel(this Model.ApplicantOwnedAnimal item)
		{
			return Mapper.Map<ViewModel.Entity.ApplicantOwnedAnimal>(item);
		}

		/// <summary>
		/// Map a list of ApplicantOwnedAnimal database model objects to a list of view model objects for presentation
		/// </summary>
		/// <param name="item">list of database model objects</param>
		/// <returns>list of presentation objects</returns>
		public static List<ViewModel.Entity.ApplicantOwnedAnimal> ToViewModel(this List<Model.ApplicantOwnedAnimal> item)
		{
			return Mapper.Map<List<Model.ApplicantOwnedAnimal>, List<ViewModel.Entity.ApplicantOwnedAnimal>>(item);
		}

		/// <summary>
		/// Map a ApplicantOwnedAnimal View Model object to a database Model object
		/// </summary>
		/// <param name="item">presentation view model object</param>
		/// <returns>database model object</returns>
		public static Model.ApplicantOwnedAnimal ToModel(this ViewModel.Entity.ApplicantOwnedAnimal item)
		{
			return Mapper.Map<Model.ApplicantOwnedAnimal>(item);
		}
	}
}
