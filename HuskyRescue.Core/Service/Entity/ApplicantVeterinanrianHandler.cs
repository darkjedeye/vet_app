using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using ApplicantVeterinarian = HuskyRescue.Core.ViewModel.Entity.ApplicantVeterinarian;

namespace HuskyRescue.Core.Service.Entity
{
	public class ApplicantVeterinarianHandler : BaseHandler<ApplicantVeterinarian>
	{
		public override ServiceResultEnum Create(ref ApplicantVeterinarian obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Update(ref ApplicantVeterinarian obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public override ApplicantVeterinarian ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<ApplicantVeterinarian> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<ApplicantVeterinarian> ReadFiltered(ApplicantVeterinarian obj)
		{
			throw new NotImplementedException();
		}
	}
}