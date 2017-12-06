using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using HuskyRescue.Web.Core.ViewModel;
using HuskyRescue.Web.Core.FileUpload;
using HuskyRescue.Web.Core.Infrastructure.Extensions;

namespace HuskyRescue.Web.Controllers
{
	public class FilesController : BaseController
	{

		public ActionResult UploadFile()
		{
			return View();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="UploadedFile"></param>
		/// <param name="EntityID"></param>
		/// <param name="EntityType">1: Person, 2: Org/Business, 3: Dog</param>
		/// <returns></returns>
		[HttpPost]
		public FineUploaderResult UploadFile(FineUpload UploadedFile, Guid? EntityID, int? EntityType)
		{
			// 1) Save file to server
			//		save to the folder of the provided ID value
			//		return server path
			string relativeFilePath = string.Empty;
			FineUploaderResult uploadResult = SaveUploadedFile(UploadedFile, EntityID, EntityType, out relativeFilePath);

			// 2) Save file to database
			//		return 
			Entity_FileViewModel File = new Entity_FileViewModel();
			switch (EntityType)
			{
				case 1:
					File.PersonID = EntityID;
					break;
				case 2:
					File.BusinessID = EntityID;
					break;
				case 3:
					File.DogID = EntityID;
					break;
			} 
			File.ServerPath = relativeFilePath;
			File.DateCreated = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(-6));
			File.ContentType = UploadedFile.ContentType;

			var context = new Model.AnimalRescueEntities();
			File.ID = context.Entity_FileCreate(File).ID;

			// 3) Return file ID and Server Path to client
			return new FineUploaderResult(true, new 
			{
				FileName = File.FileName,
				FileID = File.ID.ToString(), 
				FilePath = File.ServerPath
			});
		}

		private FineUploaderResult SaveUploadedFile(FineUpload upload, Guid? EntityID, int? EntityType, out string relativeFilePath)
		{
			string entityType = string.Empty;
			switch (EntityType)
			{
				case 1:
					entityType = "Person";
					break;
				case 2:
					entityType = "Org";
					break;
				case 3:
					entityType = "Dog";
					break;
			}

			string folder = Path.Combine("~/Upload", entityType, EntityID.Value.ToString(), "Files");
			string directory = Server.MapPath(folder);
			var fullFilePath = Path.Combine(directory, HttpContext.Server.UrlDecode(upload.Filename));
			relativeFilePath = Path.Combine(folder, HttpContext.Server.UrlDecode(upload.Filename));

			FineUploaderResult uploadResult = new FineUploaderResult(true);

			try
			{
				upload.SaveAs(fullFilePath);
			}
			catch (Exception ex)
			{
				uploadResult = new FineUploaderResult(false, error: ex.Message);
			}
			return uploadResult;
		}
	}
}
