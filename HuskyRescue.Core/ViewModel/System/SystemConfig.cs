using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.System
{
	public class SystemConfig
	{
		[DisplayName("Category Name")]
		[DataType(DataType.Text)]
		[StringLength(50)]
		public string CategoryName { get; set; }

		[DisplayName("Setting Name")]
		[DataType(DataType.Text)]
		[StringLength(100)]
		public string SettingName { get; set; }

		[DisplayName("Setting Value")]
		[DataType(DataType.Text)]
		[StringLength(100)]
		public string SettingValue { get; set; }

		[DisplayName("Setting Description")]
		[DataType(DataType.MultilineText)]
		[StringLength(500)]
		public string SettingDescription { get; set; }

		public SystemConfigCategory Category { get; set; }
		public List<SystemConfigCategory> Categories { get; set; }
	}
}
