using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class DogImage
	{
		public DogImage()
		{

		}

		public int DogID { get; set; }

		public int PictureID { get; set; }

		[DisplayName("File Name")]
		[DataType(DataType.Text)]
		[Required(ErrorMessage = "Required")]
		public string FileName { get; set; }
	}
}
