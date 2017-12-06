using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class File
	{
		/// <summary>
		/// Unique Id of the File
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Unique Id of the Person
		/// </summary>
		public Guid? PersonID { get; set; }

		/// <summary>
		/// Unique Id of the Business
		/// </summary>
		public Guid? BusinessID { get; set; }

		/// <summary>
		/// Unique Id of the Husky
		/// </summary>
		public Guid? DogID { get; set; }

		/// <summary>
		/// A description of the file contents
		/// </summary>
		[StringLength(100)]
		public string ContentType { get; set; }

		[StringLength(2000)]
		[DataType(DataType.Text)]
		public string ServerPath { get; set; }

		public DateTimeOffset DateCreated { get; set; }

		public string Url
		{
			get
			{
				return VirtualPathUtility.ToAbsolute(ServerPath);
			}
		}

		public string FileName
		{
			get
			{
				return HttpContext.Current.Server.UrlDecode(Path.GetFileName(ServerPath));
			}
		}

		public string FileExtension
		{
			get
			{
				return Path.GetExtension(ServerPath);
			}
		}


		public string LinkPath
		{
			get
			{
				return HttpContext.Current.Server.MapPath(this.ServerPath);
			}
		}
	}
}