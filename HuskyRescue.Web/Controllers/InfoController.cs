using HuskyRescue.Core.Service;
using HuskyRescue.Core.ViewModel.Entity;
using NLog.Mvc;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
	public class InfoController : BaseController
	{
		private readonly ILogger _logger;
		public InfoController(ILogger logger)
		{
			_logger = logger;
		}

		public ActionResult Fostering()
		{
			_logger.Trace("/Info/Fostering (get) called");
			return View();
		}

		public ActionResult Sponsors()
		{
			_logger.Trace("/Info/Sponsors (get) called");
			return View();
		}

		public ActionResult Resources()
		{
			_logger.Trace("/Info/Resources (get) called");
			return View();
		}

		public ActionResult AboutUs()
		{
			_logger.Trace("/Info/AboutUs (get) called");
			return View();
		}

		public ActionResult Contact()
		{
			_logger.Trace("/Info/Contact (get) called");
			var contactForm = new Contact();
			return View(contactForm);
		}

		[HttpPost]
		public ActionResult Contact(Contact contact)
		{
			_logger.Trace("/Info/Contact (post) called");

			//*************Recaptcha Stuff************
			var recaptchaHelper = this.GetRecaptchaVerificationHelper();

			if (string.IsNullOrEmpty(recaptchaHelper.Response))
			{
				ModelState.AddModelError("", "Please enter a captcha answer.");
				return RedirectToAction("Contact");
			}

			var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

			if (recaptchaResult != RecaptchaVerificationResult.Success)
			{
				ModelState.AddModelError("", "Incorrect captcha answer.");
				return RedirectToAction("Contact");
			}
			//****************************************

			var onlineContactHandler = new OnlineContactHandler();
			onlineContactHandler.SendEmail(contact);

			return RedirectToAction("ContactThankYou");
		}

		public ActionResult ContactThankYou()
		{
			_logger.Trace("/Info/ContactThankYou (get) called");
			return View();
		}

		public ActionResult Volunteer()
		{
			_logger.Trace("/Info/Volunteer (get) called");
			return View();
		}

		public ActionResult ResourcesHuskyRescues()
		{
			_logger.Trace("/Info/ResourcesHuskyRescues (get) called");
			return View();
		}

		public ActionResult ResourcesAboutHuskies()
		{
			_logger.Trace("/Info/ResourcesAboutHuskies (get) called");
			return View();
		}

		public ActionResult ResourcesLocalShelters()
		{
			_logger.Trace("/Info/ResourcesLocalShelters (get) called");
			return View();
		}

		public ActionResult Store()
		{
			_logger.Trace("/Info/Store (get) called");
			return View();
		}

		public ActionResult Member()
		{
			_logger.Trace("/Info/Member (get) called");
			return View();
		}

		public ActionResult Policies()
		{
			_logger.Trace("/Info/Policies (get) called");
			return View();
		}
	}
}
