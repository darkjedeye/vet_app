using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Core.ViewModel.Blog;
using HuskyRescue.Model;

namespace HuskyRescue.Core.Service.Blog
{
	public class TagsHandler : BaseHandler<Tags>
	{
		public TagsHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		public override ServiceResultEnum Create(ref Tags obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Update(ref Tags obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public override Tags ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<Tags> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<Tags> ReadFiltered(Tags obj)
		{
			throw new NotImplementedException();
		}
	}
}
