using BrockAllen.IdentityReboot;
using HuskyRescue.Core.ViewModel.Accounts.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HuskyRescue.Core.ViewModel.Accounts
{
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager()
			: base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
		{
			PasswordHasher = new AdaptivePasswordHasher(50000);
		}
	}
}