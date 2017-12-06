using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Braintree;
using HuskyRescue.Web.Properties;

namespace HuskyRescue.Web.Controllers
{
    public class SubscriptionsController : BaseController
    {
		public class Constants
		{
			public static BraintreeGateway Gateway = new BraintreeGateway
			{
				Environment = Braintree.Environment.SANDBOX,
				PublicKey = Settings.Default.BraintreePublicKey,
				PrivateKey = Settings.Default.BraintreeKeyPrivate,
				MerchantId = Settings.Default.BraintreeMerchantId
			};
		}

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Create(string id)
		{
			try
			{
				Customer customer = Constants.Gateway.Customer.Find(id);
				string paymentMethodToken = customer.CreditCards[0].Token;

				SubscriptionRequest request = new SubscriptionRequest
				{
					PaymentMethodToken = paymentMethodToken,
					PlanId = "Basic001"
				};
				Result<Subscription> result = Constants.Gateway.Subscription.Create(request);

				return Content("Subscription Status" + result.Target.Status);
			}
			catch (Braintree.Exceptions.NotFoundException e)
			{
				return Content("No customer found for id: " + id);
			}
		}
    }
}
