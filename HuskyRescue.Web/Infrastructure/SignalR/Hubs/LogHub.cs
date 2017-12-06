using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HuskyRescue.Web.Infrastructure.SignalR.Hubs
{
	[HubName("logHub")]
	public class LogHub : Hub
	{
		public void SendMessage(string clientName, string message)
		{
			Clients.All.SendMessage(clientName, message);
		}
	}
}