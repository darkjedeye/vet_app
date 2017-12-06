using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.System
{
	public class SystemConfiguration
	{
		[DisplayName("Category Name")]
		[DataType(DataType.Text)]
		[StringLength(50)]
		public string CategoryName { get; set; }

		[DisplayName("Category SettingDescription")]
		[DataType(DataType.Text)]
		[StringLength(500)]
		public string CategoryDescription { get; set; }

		[DisplayName("Setting Name")]
		[DataType(DataType.Text)]
		[StringLength(100)]
		public string SettingName { get; set; }

		[DisplayName("Setting Value")]
		[DataType(DataType.Text)]
		[StringLength(100)]
		public string SettingValue { get; set; }

		[DisplayName("Setting SettingDescription")]
		[DataType(DataType.MultilineText)]
		[StringLength(500)]
		public string SettingDescription { get; set; }
	}
}
