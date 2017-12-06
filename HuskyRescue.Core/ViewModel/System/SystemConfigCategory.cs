using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.System
{
	public class SystemConfigCategory
	{
		[DisplayName("Category Name")]
		[DataType(DataType.Text)]
		[StringLength(50)]
		public string Name { get; set; }

		[DisplayName("Category SettingDescription")]
		[DataType(DataType.Text)]
		[StringLength(500)]
		public string Description { get; set; }
	}
}
