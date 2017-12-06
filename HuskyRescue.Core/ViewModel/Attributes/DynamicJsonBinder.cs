using System;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace HuskyRescue.Web.Core.Infrastructure.Binders
{
	// http://blog.duc.as/2011/06/07/making-mvc-3-a-little-more-dynamic/
	public class DynamicJsonBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (!controllerContext.HttpContext.Request.ContentType.StartsWith
				("application/json", StringComparison.OrdinalIgnoreCase))
			{
				// not JSON request  
				return null;
			}

			var inpStream = controllerContext.HttpContext.Request.InputStream;
			inpStream.Seek(0, SeekOrigin.Begin);

			var reader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
			var bodyText = reader.ReadToEnd();
			reader.Close();

			return String.IsNullOrEmpty(bodyText) ? null : JsonConvert.DeserializeObject(bodyText);
		}

	}  
}
