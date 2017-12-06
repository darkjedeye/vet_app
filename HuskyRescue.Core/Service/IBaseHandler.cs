using System;
using System.Collections.Generic;

namespace HuskyRescue.Core.Service
{
	public interface IBaseDabaseHandler<T> where T : class
	{
		ServiceResultEnum Create(ref T obj);

		ServiceResultEnum Update(ref T obj);

		ServiceResultEnum Delete(Guid id);

		T ReadOne(Guid id1, Guid id2, Guid id3, int id4, int id5, int id6);

		List<T> ReadAll();

		List<T> ReadFiltered(T obj);

	}
}
