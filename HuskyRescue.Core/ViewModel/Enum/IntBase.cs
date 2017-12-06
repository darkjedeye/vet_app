using System;

namespace HuskyRescue.Core.ViewModel.Enum
{
	[Serializable]
	public class IntBase
	{
		public int ID { get; set; }

		public string Value { get; set; }

		public IntBase()
		{

		}

		public IntBase(int id, string value)
		{
			ID = id;
			Value = value;
		}
	}
}