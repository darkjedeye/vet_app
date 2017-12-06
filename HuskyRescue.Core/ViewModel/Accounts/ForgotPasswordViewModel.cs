using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Accounts
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}
