using System.ComponentModel.DataAnnotations;

namespace HuskyRescue.Core.ViewModel.Accounts
{
    public class ExternalLoginConfirmationViewModel
    {
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
    }
}
