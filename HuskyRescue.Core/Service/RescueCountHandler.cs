namespace HuskyRescue.Core.Service
{
	public class RescueCountHandler
	{
		public string Count
		{
			get
			{
				return GetCount();
			}
			set
			{
				SetCount(value);
			}
		}

		private static string GetCount()
		{
			var miscHandler = new Enum.MiscHandler();
			var misc = miscHandler.ReadOne("rescuecount");
			return misc.Value;
		}

		public static void SetCount(string count)
		{
			var miscHandler = new Enum.MiscHandler();
			var misc = miscHandler.ReadOne("rescuecount");
			misc.Value = count;
			miscHandler.Update(ref misc);
		}
	}
}
