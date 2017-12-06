using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuskyRescue.Core.ViewModel.RescueGroups;
using Newtonsoft.Json;

namespace HuskyRescue.Core.ViewModel.Controllers.Adoption
{
	public class Huskies
	{
		public Huskies()
		{
			Animals = new List<Animal>();
		}

		public List<Animal> Animals { get; set; }

		public string AnimalsJson
		{
			get
			{
				if (Animals == null) return string.Empty;
				var jsonSerializer = new Newtonsoft.Json.JsonSerializer();
				return JsonConvert.SerializeObject(Animals, Formatting.None);
			}
		}

		public int AnimalsCountPadded
		{
			get
			{
				var count = Animals.Count;
				var mod = count%8;
				if (mod == 0) return count;

				return (8 - mod) + count;
			}
		}
	}
}
