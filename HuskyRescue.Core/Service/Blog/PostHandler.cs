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
	public class PostHandler : BaseHandler<Post>
	{
		public PostHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		public override ServiceResultEnum Create(ref Post obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Update(ref Post obj)
		{
			throw new NotImplementedException();
		}

		public override ServiceResultEnum Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public override Post ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<Post> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<Post> ReadFiltered(Post obj)
		{
			throw new NotImplementedException();
		}
	}
}
