using HuskyRescue.Core.ViewModel.Logging;
using Microsoft.AspNet.SignalR;

namespace HuskyRescue.Web.Infrastructure.SignalR.Hubs
{
	public class ActivityLogHub : Hub
	{
		public void SendMessage(string userName, string message, int type)
		{
			// Call send on everyone except the caller
			Clients.Others.sendMessage(userName, message, type);
		}

		public void SendActivityLog(LogUserActivity log)
		{
			Clients.All.addNewActivityToPage(log);
		}
	}
}


/*

// Call send on everyone
Clients.All.send(message);

// Call send on everyone except the caller
Clients.Others.send(message);

// Call send on everyone except the specified connection ids
Clients.AllExcept(Context.ConnectionId).send(message);

// Call send on the caller
Clients.Caller.send(message);

// Call send on everyone in group "foo"
Clients.Group("foo").send(message);

// Call send on everyone else but the caller in group "foo"
Clients.OthersInGroup("foo").send(message);

// Call send on everyone in "foo" excluding the specified connection ids
Clients.Group("foo", Context.ConnectionId).send(message);

// Call send on to a specific connection
Clients.Client(Context.ConnectionId).send(message);

*/