using System.Collections.Generic;

namespace HuskyRescue.Core.Service
{
	public abstract class NewBaseHandler
	{
		/// <summary>
		/// Set the result of the command performed
		/// </summary>
		public ServiceResultEnum ServiceResult { get; set; }

		public List<string> Messages { get; set; }

		/// <summary>
		/// Contains the last number of changes from the last save to the database
		/// </summary>
		public int NumberChanges { get; set; }

		protected NewBaseHandler()
		{
			Messages = new List<string>();
		}
	}
}
