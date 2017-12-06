using System;

namespace HuskyRescue.Core.ViewModel.Enum
{
	[Serializable]
	public class StringBase
	{
		public string ID { get; set; }

		public string Value { get; set; }

		public StringBase()
		{

		}

		public StringBase(string id, string value)
		{
			ID = id;
			Value = value;
		}
	}
}