using System;
using System.Collections.Generic;
using NLog.Mvc;

namespace HuskyRescue.Core.ViewModel.Logging
{
	public class Log
	{
		public IEnumerable<LogEntry> LogEntries { get; set; }

		public Log()
		{
			LogEntries = new List<LogEntry>();
		}

		public int Id { get; set; }
		public bool? IsVisible { get; set; }
		public Guid? UpdatedByUserId { get; set; }
		public DateTime? UpdatedTimeStam { get; set; }
		public DateTime TimeStamp { get; set; }
		public string Level { get; set; }
		public string Logger { get; set; }
		public string Message { get; set; }
		public string ExceptionType { get; set; }
		public string Operation { get; set; }
		public string ExceptionMessage { get; set; }
		public string StackTrace { get; set; }
	}
}
