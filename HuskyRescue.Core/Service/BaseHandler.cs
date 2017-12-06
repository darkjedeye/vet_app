using System;
using System.Collections.Generic;

namespace HuskyRescue.Core.Service
{
	public abstract class BaseHandler<T> where T : class
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

		public abstract ServiceResultEnum Create(ref T obj);

		public abstract ServiceResultEnum Update(ref T obj);

		public abstract ServiceResultEnum Delete(Guid id);

		public abstract T ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6);

		public abstract List<T> ReadAll();

		public abstract List<T> ReadFiltered(T obj);

		protected BaseHandler()
		{
			Messages = new List<string>();
		}
	}
}