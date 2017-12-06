using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuskyRescue.Web.Core.Infrastructure.Binders;
using System.Web.Mvc;

namespace HuskyRescue.Web.Core.Infrastructure.Attributes
{
	// http://blog.duc.as/2011/06/07/making-mvc-3-a-little-more-dynamic/
	public class DynamicJsonAttribute : CustomModelBinderAttribute
	{
		public override IModelBinder GetBinder()
		{
			return new DynamicJsonBinder();
		}
	}  
}
