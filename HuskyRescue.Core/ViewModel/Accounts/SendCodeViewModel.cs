using System.Collections.Generic;
using System.Web.Mvc;


namespace HuskyRescue.Core.ViewModel.Accounts
{
	public class SendCodeViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<SelectListItem> Providers { get; set; }
		public string ReturnUrl { get; set; }
	}
}
