using System;
using System.Web.Mvc;
using Fabrik.Common.Web;
using HuskyRescue.Core.Service;
using HuskyRescue.Core.Service.Entity;
using HuskyRescue.Core.Service.Enum;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Core.ViewModel.Extensions;
using HuskyRescue.Web.Infrastructure.Extensions;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	[Authorize]
	public class BusinessController : Controller
	{
		private readonly ILogger _logger;
		private readonly BusinessHandler _businessHandler = new BusinessHandler();
		public BusinessController(ILogger logger)
		{
			_logger = logger;
		}

		//
		// GET: /Business/
		public ActionResult Index()
		{
			_logger.Trace("/Business/Index (get) called");
			return View(_businessHandler.ReadAll());
		}

		[ImportModelStateFromTempData]
		public ActionResult Create()
		{
			_logger.Trace("/Business/Create (get) called");

			var business = new Business();

			business.Setup(true);

			return View(business);
		}

		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Create(Business business)
		{
			_logger.Trace("/Business/Create (post) called");

			try
			{
				var result = _businessHandler.Create(ref business);
				if (result == ServiceResultEnum.Failure)
				{
					return RedirectToAction("Create").Error(_businessHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Create Business Error", ex);
				return RedirectToAction("Create").Error(ex.Message);
			}
			return RedirectToAction("Index").Success("Business created");
		}

		[ImportModelStateFromTempData]
		public ActionResult Edit(Guid id)
		{
			_logger.Trace("/Business/Edit (get) called");
			var business = _businessHandler.ReadOne(id);

			business.Setup(false);

			return View(business);
		}

		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Edit(Business business)
		{
			_logger.Trace("/Business/Edit (post) called");

			try
			{
				var result = _businessHandler.Update(ref business);
				if (result == ServiceResultEnum.Failure)
				{
					return RedirectToAction("Edit").Error(_businessHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Create Business Error", ex);
				return RedirectToAction("Edit").Error(ex.Message);
			}
			return RedirectToAction("Index").Success("Business created");


		}

		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken]
		public ActionResult Delete(Business business)
		{
			_logger.Trace("/Business/Delete (post) called");

			try
			{
				if (_businessHandler.Delete(business.ID) == ServiceResultEnum.Failure)
				{
					return RedirectToAction("Index").Error(_businessHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Delete Business Error", ex);
				return RedirectToAction("Index").Error(ex.Message);
			}
			return RedirectToAction("Index").Success("Business deleted");
		}
	}
}
