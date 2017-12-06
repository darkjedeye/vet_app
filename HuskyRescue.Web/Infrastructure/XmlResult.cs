using System.Web.Mvc;
using System.Xml.Serialization;

namespace HuskyRescue.Web.Infrastructure
{
	/// <summary>
	/// http://www.prideparrot.com/blog/archive/2012/3/returning_data_view_from_controller_action
	/// </summary>
	public class XmlResult : ActionResult
	{
		private readonly object _data;

		public XmlResult(object data)
		{
			_data = data;
		}

		public override void ExecuteResult(ControllerContext context)
		{
			var serializer = new XmlSerializer(_data.GetType());
			context.HttpContext.Response.ContentType = "application/xml";
			serializer.Serialize(context.HttpContext.Response.OutputStream, _data);
		}
	}
}