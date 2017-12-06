namespace HuskyRescue.Core.Service.Accounts
{
	public enum SignInStatus
	{
		Success,
		LockedOut,
		RequiresTwoFactorAuthentication,
		Failure
	}
}