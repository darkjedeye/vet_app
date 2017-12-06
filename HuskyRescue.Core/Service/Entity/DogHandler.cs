using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Core.ViewModel.Entity;

namespace HuskyRescue.Core.Service.Entity
{
	public class DogHandler : BaseHandler<Dog>
	{
		public override ServiceResultEnum Create(ref Dog obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Update(ref Dog obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public override Dog ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<Dog> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<Dog> ReadFiltered(Dog obj)
		{
			throw new NotImplementedException();
		}
	}
}