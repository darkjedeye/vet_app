using System.Collections.Generic;

namespace HuskyRescue.Core.ViewModel.Blog
{
	public class Tags
	{
		public int ID { get; set; }

		public string Value { get; set; }

		public List<Post> Posts { get; set; }

		public Tags()
		{
			Posts = new List<Post>();
		}
	}
}
