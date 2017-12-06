using System;
using System.Web.Mvc;
using Fabrik.Common.Web;
using HuskyRescue.Core.Service.Store;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Store;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	[Authorize]
	public class StoreProductPropertyController : BaseController
	{
		private readonly ProductPropertyHandler _productPropertyHandler = new ProductPropertyHandler();
		private readonly ILogger _logger;
		public StoreProductPropertyController(ILogger logger)
		{
			_logger = logger;
		}
		
		//
		// GET: /StoreProductProperty/
		public ActionResult Index()
		{
			return View(_productPropertyHandler.ReadAll());
		}

		//
		// GET: /StoreProductProperty/Create
		[ImportModelStateFromTempData]
		public ActionResult Create()
		{
			return View(new ProductProperty());
		}

		//
		// POST: /StoreProductProperty/Create
		[HttpPost, ValidateModelState, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Create(ProductProperty productProperty)
		{
			try
			{
				_productPropertyHandler.Create(ref productProperty);
			}
			catch (Exception ex)
			{
				_logger.Error("Create Store Product Property Error", ex);
				return RedirectToAction("Create");
			}
			return RedirectToAction("Index");
		}

		//
		// GET: /StoreProductProperty/Edit/5
		public ActionResult Edit(Guid id)
		{
			var property = _productPropertyHandler.ReadOne(id);
			return View(property);
		}

		//
		// POST: /StoreProductProperty/Edit/5
		[HttpPost, ValidateModelState, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Edit(ProductProperty productProperty)
		{
			try
			{
				_productPropertyHandler.Create(ref productProperty);
			}
			catch (Exception ex)
			{
				_logger.Error("Update Store Product Property Error", ex);
				return RedirectToAction("Edit");
			}
			return RedirectToAction("Index");
		}

		//
		// POST: /StoreProductProperty/Delete/5
		[HttpPost, ValidateModelState, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Delete(Guid id)
		{
			try
			{
				_productPropertyHandler.Delete(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
