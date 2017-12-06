using System.Data.Entity;
using System.Web;
using HuskyRescue.Core.Service.Accounts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace HuskyRescue.Core.ViewModel.Accounts.Identity
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("ApplicationServices", throwIfV1Schema: false)
		{
		}

		static ApplicationDbContext()
		{
			// Set the database intializer which is run once during application start
			// This seeds the database with admin user credentials and admin role
			//Database.SetInitializer(new ApplicationDbInitializer());
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public static bool SetupFirstUserAndRole()
		{
			var isSetup = false;
			var userManager = HttpContext.Current.GetOwinContext().GetUserManager<Service.Accounts.ApplicationUserManager>();
			var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
			const string name = "admin@admin.com";
			const string password = "Admin@123456";
			const string roleName = "Administrator";

			//Create Role Admin if it does not exist
			var role = roleManager.FindByName(roleName);
			if (role == null)
			{
				role = new IdentityRole(roleName);
				var roleresult = roleManager.Create(role);
			}

			var user = userManager.FindByName(name);
			if (user == null)
			{
				user = new ApplicationUser { UserName = name, Email = name };
				var result = userManager.Create(user, password);
				result = userManager.SetLockoutEnabled(user.Id, false);
			}

			// Add user admin to Role Admin if not already added
			var rolesForUser = userManager.GetRoles(user.Id);
			if (!rolesForUser.Contains(role.Name))
			{
				var result = userManager.AddToRole(user.Id, role.Name);
				if (result != null) isSetup = true;
			}
		
			return isSetup;
		}
	}
}