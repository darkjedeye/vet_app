using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Core.ViewModel.Entity;

namespace HuskyRescue.Core.Service.Entity
{
	public class DogImageHandler : BaseHandler<DogImage>
	{
		public override ServiceResultEnum Create(ref DogImage obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Update(ref DogImage obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public override DogImage ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<DogImage> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<DogImage> ReadFiltered(DogImage obj)
		{
			throw new NotImplementedException();
		}
	}
}