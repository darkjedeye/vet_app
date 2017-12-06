using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyRescue.Web.Infrastructure
{
	/// <summary>
	/// Common class to create a common response framework to AJAX requests using JSON
	/// </summary>
	public class JsonResponseObject
	{
		public JsonResponseObject()
		{
			Success = true;
		}

		public bool Success { get; set; }
		public Exception Exception { get; set; }
		public string Message { get; set; }
		public Object Data { get; set; }
	}
}
