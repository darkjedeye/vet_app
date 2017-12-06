using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.IO;
using System.Xml.Serialization;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class ImageViewModel
	{
		public ImageViewModel(string id = "")
		{
			Folders = new List<string>();
			ImageList = new List<Image>();
			if (String.IsNullOrEmpty(id))
			{
				foreach (var s in Directory.GetDirectories(HttpContext.Current.Server.MapPath(Path.Combine("\\Pictures\\", "Huskies"))))
				{
					Folders.Add(s.Split('\\').Last());
				}
			}
			else
			{
				ID = id;
				ImageList = Images.ImagesList.Where(images => images.FolderName.ToLower().Equals(id.ToLower())).ToList<Image>();
				if (ImageList.Count != 0) return;
				var ims = Images.ReadNewDirectory(id);
				if (ims != null)
				{
					ImageList.AddRange(ims);
				}
			}
		}

		public ImageViewModel()
		{
			Folders = new List<string>();
			ImageList = new List<Image>();
		}
		public String ID { get; set; } 
		public List<String> Folders { get; set; }
		public List<Image> ImageList { get; set; }
	}

	public class ImageUploadViewModel
	{
		/// <summary>
		/// List of images uploaded
		/// </summary>
		[DisplayName("Pictures to upload")]
		public IEnumerable<HttpPostedFileBase> Images { get; set; }

		/// <summary>
		/// List of folders based on the type of folder selected
		/// </summary>
		[DisplayName("Pick the folder to place the picture(s)")]
		[Required(ErrorMessage = "Required")]
		public List<SelectListItem> FolderList { get; set; }

		/// <summary>
		/// Selected folder to upload the images to
		/// </summary>
		public String SelectedFolder { get; set; }

		/// <summary>
		/// Indicate if the folder is a new one
		/// </summary>
		[DisplayName("New Folder (name of the husky):")]
		[Required(ErrorMessage = "Please enter the name of the husky")]
		public String NewFolder { get; set; }

		[DisplayName("Optional description of the pictures")]
		public List<String> Description { get; set; }

		public ImageUploadViewModel()
		{
			FolderList = new List<SelectListItem>
			             {
				             new SelectListItem() {Selected = false, Text = "", Value = ""},
				             new SelectListItem() {Selected = false, Text = "New...", Value = "NEW"}
			             };
			foreach (var d in Directory.GetDirectories(HttpContext.Current.Server.MapPath(Path.Combine("\\Pictures\\", "Huskies"))))
			{
				FolderList.Add(new SelectListItem() { Selected = false, Text = d, Value = d });
			}
			Description = new List<string>();
		}

		public void Save()
		{
			var nextFileNumber = Directory.GetFiles(SelectedFolder).Length;
			var newImages = new List<Image>();
			var count = 0;
			foreach (var File in Images)
			{
				if (File != null)
				{
					var path = Path.Combine(SelectedFolder, File.FileName);

					var image = new Image() { FileName = File.FileName, FilePath = SelectedFolder };

					var fileInfo = new FileInfo(path);
					var sb = new StringBuilder();
					// Format file name like this: FolderName - ###.jpg
					var fileName = sb.Append(image.ParentFolder).Append(" - ").AppendFormat("{0:d3}", nextFileNumber).Append(fileInfo.Extension).ToString();
					path = Path.Combine(SelectedFolder, fileName);

					newImages.Add(image);
					File.SaveAs(path);
				}
				count++;
			}
			if (newImages.Count > 0)
			{
				Entity.Images.UpdateConfig(newImages);
			}
		}
	}


	public static class Images
	{
		[XmlArray("Images")]
		public static List<Image> ImagesList { get; set; }

		static Images()
		{
			if (ImagesList != null && ImagesList.Count != 0) return;
			ImagesList = new List<Image>();
			ReadConfig();
		}

		public static void ReadConfig()
		{
			// Construct an instance of the XmlSerializer with the type of object that is being deserialized.
			var mySerializer = new XmlSerializer(typeof(List<Image>));
			// To read the file, create a FileStream.
			using (var myFileStream = new FileStream(HttpContext.Current.Server.MapPath(@"\App_Data\data.xml"), FileMode.Open))
			{
				// Call the Deserialize method and cast to the object type.
				try
				{
					ImagesList = (List<Image>)mySerializer.Deserialize(myFileStream);
				}
				catch
				{
					//do nothing - move on to the next step
				}
			}
		}

		public static void WriteConfig()
		{
			// Insert code to set properties and fields of the object.
			var mySerializer = new XmlSerializer(typeof(List<Image>));
			// To write to a file, create a StreamWriter object.
			using (var myWriter = new StreamWriter(HttpContext.Current.Server.MapPath(@"\App_Data\data.xml")))
			{
				mySerializer.Serialize(myWriter, ImagesList);
			}
		}

		public static void UpdateConfig(List<Image> updatedImages)
		{
			if (ImagesList.Count > 0)
			{
				foreach (var i in updatedImages)
				{
					var ii = ImagesList.Where(x => x.FilePath == i.FilePath && i.FileName == x.FileName);
					Image iii = null;
					var enumerable = ii as Image[] ?? ii.ToArray();
					if (enumerable.Any())
					{
						iii = enumerable.Single();
					}

					if (iii != null)
					{
						var theImage =
						(
							from x in ImagesList
							where i.FilePath == x.FilePath && i.FileName == x.FileName
							select x
						).Single();
						theImage.Description = i.Description;
					}
					else
					{
						ImagesList.Add(i);
					}
				}
			}
			else
			{
				ImagesList.AddRange(updatedImages);
			}
			WriteConfig();
		}

		public static List<Image> ReadNewDirectory(String FolderName)
		{
			var dirPath = HttpContext.Current.Server.MapPath(Path.Combine("\\Pictures\\", "Huskies", FolderName));
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(Path.Combine("\\Pictures\\", "Huskies", FolderName))))
				return null;
			var newFiles = Directory.GetFiles(dirPath, "*.jpg");
			if (newFiles.Length <= 0) return null;
			var ims = new List<Image>(newFiles.Length);
			ims.AddRange(newFiles.Select(f => new FileInfo(f)).Select(file => new Image() {Description = String.Empty, FileName = file.Name, FilePath = @"Huskies\" + FolderName}));

			UpdateConfig(ims);
			return ims;
		}
	}


	public class Image
	{
		[XmlElement(ElementName = "FileName")]
		public String FileName { get; set; }

		/// <summary>
		/// This is the path under Pictures, i.e. Huskies/Aiden
		/// </summary>
		[XmlElement(ElementName = "FilePath")]
		public String FilePath { get; set; }
		public String Description { get; set; }
		public String ParentFolder
		{
			get
			{
				var parent = FilePath.Split('\\');
				return parent[parent.Length - 1];
			}
		}

		[XmlIgnore()]
		public String ParentPath
		{
			get
			{

				var parent = HttpContext.Current.Server.MapPath(Path.Combine("\\Pictures\\", FilePath)).Split('\\');
				return parent[parent.Length - 3] + "\\" + parent[parent.Length - 2];
			}
		}

		[XmlIgnore()]
		public String FileFullPath
		{
			get
			{
				const string prefix = "HostName";
				var port = int.Parse("HostPort");
				var ub = new UriBuilder("http", prefix, port, Path.Combine(@"Pictures\", FilePath, FileName));

				return ub.ToString();
			}
		}

		[XmlIgnore()]
		public String ThumbnailFullPath
		{
			get
			{
				if (FilePath != null)
				{
					const string prefix = "HostName";
					var port = int.Parse("HostPort");
					var ub = new UriBuilder("http", prefix, port, @"/Image/thumbnail/" + HttpUtility.HtmlEncode(FileName) + "/" + HttpUtility.HtmlEncode(FilePath.Replace('\\', '/')));
					
					//ub.Query = "root=" + FilePath;

					return ub.ToString();
				}
				else
					return "";
			}
		}

		[XmlIgnore()]
		public String FolderName
		{
			get {
				return FilePath != null ? FilePath.Split('\\')[1] : "";
			}
		}

		public Image()
		{
		}
	}
}