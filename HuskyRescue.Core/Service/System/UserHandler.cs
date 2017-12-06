using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Core.ViewModel.System;
using HuskyRescue.Model;
using User = HuskyRescue.Core.ViewModel.System.User;

namespace HuskyRescue.Core.Service.System
{
	public class UserHandler : BaseHandler<User>
	{
		public UserHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		public override ServiceResultEnum Create(ref User obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Update(ref User obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public override User ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<User> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<User> ReadFiltered(User obj)
		{
			throw new NotImplementedException();
		}
	}
}
