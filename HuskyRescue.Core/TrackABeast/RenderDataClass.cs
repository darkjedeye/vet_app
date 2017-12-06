using System.Collections.Generic;


namespace HuskyRescue.Core.TrackABeast
{
	public class RenderDataClass
	{
		/// <summary>
		/// Number of columns to use when generating HTML page that lists animals
		/// </summary>
		public int ColumnCount { get; set; }

		/// <summary>
		/// Number of animals to be listed (th count in the IEnumerable Animals property
		/// </summary>
		public int AnimalCount { get; set; }

		/// <summary>
		/// Enumerated list of Animals that will be used to generate HTML
		/// </summary>
		public IEnumerable<Animal> Animals = null;
	}
}
