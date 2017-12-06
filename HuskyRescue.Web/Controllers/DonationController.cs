using System;
using System.Web.Mvc;
using Fabrik.Common.Web;
using HuskyRescue.Core.Service;
using HuskyRescue.Core.Service.Entity;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Web.Infrastructure.Extensions;
using NLog.Mvc;
using Donation = HuskyRescue.Core.ViewModel.Controllers.Donation.Donation;

namespace HuskyRescue.Web.Controllers
{
	public class DonationController : BaseController
	{
		private readonly ILogger _logger;
		private readonly DonationHandler _donationHandler = new DonationHandler();

		public DonationController(ILogger logger)
		{
			_logger = logger;
		}

		public ActionResult Index()
		{
			_logger.Trace("/Donation/Index (get) called");
			return View();
		}

		[ImportModelStateFromTempData]
		public ActionResult Donate()
		{
			_logger.Trace("/Donation/Donate (get) called");

			var donation = new Donation();

			try
			{
				// Pass the client key for encrypting credit card information
				ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;
			}
			catch (Exception ex)
			{
				_logger.Trace("Error loading Donation/Donate (get)", ex);
				return View(donation).Error(ex.Message);
			}

			return View(donation);
		}

		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Donate(Donation donation, FormCollection collection)
		{
			_logger.Trace("/Donation/Donate (post) called");

			// get encrypted card information
			donation.BillingInformation.CreditCardNumber = collection["number"];
			donation.BillingInformation.CreditCardExpireMonth = collection["month"];
			donation.BillingInformation.CreditCardExpireYear = collection["year"];
			donation.BillingInformation.CreditCardCvv = collection["cvv"];

			try
			{
				var result = _donationHandler.Create(ref donation);
				if (result == ServiceResultEnum.Failure)
				{
					_logger.Warning("Donation Failure: " + string.Join<string>(Environment.NewLine, _donationHandler.Messages));
					return RedirectToAction("Donate").Error(_donationHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Donation Error", ex);
				_donationHandler.Messages.Add(ex.Message);
				return RedirectToAction("Donate").Error(_donationHandler.Messages);
			}

			return RedirectToAction("ThankYou", new { @amount = donation.DonationInformation.Amount }).Success("Donation submitted successfully");
		}

		public ActionResult ThankYou()
		{
			_logger.Trace("/Donation/ThankYou (get) called");

			return View();
		}

	}
}
