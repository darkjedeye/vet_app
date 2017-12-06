using System;
using System.Collections.Generic;

namespace HuskyRescue.Core.ViewModel.Blog
{
	public class Post
	{
		public Guid ID { get; set; }

		public Boolean IsPublished { get; set; }

		public Boolean IsCommentEnabled { get; set; }

		public Boolean IsDeleted { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime? DateModified { get; set; }

		public Guid OriginalAuthor { get; set; }

		public Guid? LastModifyAuthor { get; set; }

		public String Title { get; set; }

		public String Slug { get; set; }

		public String Description { get; set; }

		public String PostContent { get; set; }

		public List<Comments> Comments { get; set; }

		public List<Tags> Tags { get; set; }
	}
}
