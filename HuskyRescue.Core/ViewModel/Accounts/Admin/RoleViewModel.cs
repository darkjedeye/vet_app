using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Accounts.Admin
{
	public class RoleViewModel
	{
		public string Id { get; set; }
		[Required(AllowEmptyStrings = false)]
		[Display(Name = "RoleName")]
		public string Name { get; set; }
	}
}
