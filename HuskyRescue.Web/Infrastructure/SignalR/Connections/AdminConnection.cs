using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HuskyRescue.Web.SignalR.Connections
{
	public class AdminConnection : PersistentConnection
	{
		protected override Task OnConnected(IRequest request, string connectionId)
		{
			return Connection.Send(connectionId, "Welcome!");
		}

		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			return Connection.Broadcast(data);
		}

		protected override bool AuthorizeRequest(IRequest request)
		{
			return base.AuthorizeRequest(request);
		}
	}
}