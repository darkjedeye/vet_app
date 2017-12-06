using System;
using Braintree;
using System.Configuration;

namespace HuskyRescue.Core.Service.Payments
{
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class Constants
	{
		public enum Environment
		{
			Development = 1,
			Sandbox = 2,
			Production = 3
		}

		/// <summary>
		/// Read environment setting from SETTINGS of project. If value isn't set or is invalid set to SANDBOX
		/// </summary>
		private static Braintree.Environment BraintreeEnvironment
		{
			get
			{
				Braintree.Environment env = null;
				try
				{
					switch (Properties.Settings.Default.BrainTreeEnvironment.ToUpper())
					{
						case "SANDBOX":
							env = Braintree.Environment.SANDBOX;
							break;
						case "PRODUCTION":
							env = Braintree.Environment.PRODUCTION;
							break;
						case "DEVELOPMENT":
							env = Braintree.Environment.DEVELOPMENT;
							break;
						default:
							env = Braintree.Environment.SANDBOX;
							break;
					}
				}
				catch (Exception ex)
				{
					env = Braintree.Environment.SANDBOX;
				}
				return env;
			}
		}

		/// <summary>
		/// BraintreeGateway used to send data to BrainTree
		/// </summary>
		public static BraintreeGateway BraintreeGateway = new BraintreeGateway
		{
			Environment = BraintreeEnvironment,
			PublicKey = Properties.Settings.Default.BrainTreePublicKey,
			PrivateKey = Properties.Settings.Default.BrainTreePrivateKey,
			MerchantId = Properties.Settings.Default.BrainTreeMerchantID
		};
	}
}
