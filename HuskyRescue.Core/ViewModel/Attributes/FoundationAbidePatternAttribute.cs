using System;
using System.Web.ModelBinding;

namespace HuskyRescue.Core.ViewModel.Attributes
{
	public class FoundationAbidePatternAttribute : Attribute, IMetadataAware
	{
		public FoundationAbidePatternAttribute(string pattern)
		{
			AbidePattern = pattern;
		}
		public FoundationAbidePatternAttribute(string pattern, string validationMessage)
		{
			AbidePattern = pattern;
			ValidationMessage = validationMessage;
		}
		public string AbidePattern { get; private set; }
		public string ValidationMessage { get; private set; }

		public void OnMetadataCreated(ModelMetadata metadata)
		{
			metadata.AdditionalValues["abidepattern"] = AbidePattern;
			metadata.AdditionalValues["validationmessage"] = ValidationMessage;
		}
	}
}
