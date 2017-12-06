using System;
using System.Collections.Generic;

namespace HuskyRescue.Core.ViewModel.Blog
{
	public class PostList
	{
		public List<Post> Posts { get; set; }

		public Int32 PostCount { get; private set; }
	}
}
