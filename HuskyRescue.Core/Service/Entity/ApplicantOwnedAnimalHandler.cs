using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using ApplicantOwnedAnimal = HuskyRescue.Core.ViewModel.Entity.ApplicantOwnedAnimal;

namespace HuskyRescue.Core.Service.Entity
{
	public class ApplicantOwnedAnimalHandler : BaseHandler<ApplicantOwnedAnimal>
	{
		public override ServiceResultEnum Create(ref ApplicantOwnedAnimal obj)
		{
			throw new NotImplementedException();
		}

		public ServiceResultEnum Create(ref List<ApplicantOwnedAnimal> obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Update(ref ApplicantOwnedAnimal obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public override ApplicantOwnedAnimal ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<ApplicantOwnedAnimal> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<ApplicantOwnedAnimal> ReadFiltered(ApplicantOwnedAnimal obj)
		{
			throw new NotImplementedException();
		}
	}
}