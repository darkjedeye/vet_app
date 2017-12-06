using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Accounts.Manage
{
	public class AddPhoneNumberViewModel
	{
		[Required]
		[Phone]
		[Display(Name = "Phone Number")]
		public string Number { get; set; }
	}
}
