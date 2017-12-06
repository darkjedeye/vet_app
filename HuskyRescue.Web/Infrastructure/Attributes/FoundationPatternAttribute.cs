using System;
using System.Web.ModelBinding;

namespace HuskyRescue.Web.Infrastructure.Attributes
{
	public class FoundationPatternAttribute : Attribute, IMetadataAware
	{
		public FoundationPatternAttribute(string pattern)
		{
			Pattern = pattern;
		}
		public string Pattern { get; private set; }

		public void OnMetadataCreated(ModelMetadata metadata)
		{
			metadata.AdditionalValues["pattern"] = Pattern;
		}
	}
}