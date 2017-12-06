using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuskyRescue.Core;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace HuskyRescue.Core.Logging
{
	public static class Log
	{
		public static Logger Instance { get; private set; }
		static Log()
		{
			Instance = LogManager.GetCurrentClassLogger();
		}
	}
}
            