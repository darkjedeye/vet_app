using System;

namespace HuskyRescue.Core.ViewModel.Blog
{
	public class Comments
	{
		public Guid ID { get; set; }

		public Guid PostID { get; set; }

		public Guid? ParentCommentID { get; set; }

		public Boolean IsDeleted { get; set; }

		public Boolean IsSpam { get; set; }

		public DateTime DateCreated { get; set; }

		public String AuthorIP { get; set; }

		public Guid? ModeratedByUserID { get; set; }

		public DateTime? ModeratedDate { get; set; }

		public Guid? AuthorRegisteredUserID { get; set; }

		public String AuthorName { get; set; }

		public String AuthorEmail { get; set; }

		public String AuthorWebsite { get; set; }

		public String Comment { get; set; }
	}
}
