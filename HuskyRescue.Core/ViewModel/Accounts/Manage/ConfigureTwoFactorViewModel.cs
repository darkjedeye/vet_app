using System.Collections.Generic;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Accounts.Manage
{
	public class ConfigureTwoFactorViewModel
	{
		public string SelectedProvider { get; set; }
		public ICollection<SelectListItem> Providers { get; set; }
	}
}
