using HuskyRescue.Core.Service.System;
using HuskyRescue.Core.ViewModel.Accounts.Identity;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.System;
using HuskyRescue.Web.Infrastructure;
using Newtonsoft.Json;
using NLog.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HuskyRescue.Web.Controllers
{
	[Authorize]
	public class SystemController : BaseController
	{
		private readonly ILogger _logger;
		private readonly SystemConfigCategoryHandler _systemConfigCategoryHandler = new SystemConfigCategoryHandler();
		private readonly SystemConfigHandler _systemConfigHandler = new SystemConfigHandler();
		public SystemController(ILogger logger)
		{
			_logger = logger;
		}

		// GET: /System/
		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Get a list of System Setting Categories
		/// </summary>
		/// <returns>JSON string of System Setting Categories</returns>
		public ActionResult GetCategorySettings()
		{
			var dbResult = _systemConfigCategoryHandler.ReadAll();

			var jsonNetResult = new JsonNetResult {Data = dbResult};

			return jsonNetResult;
		}

		/// <summary>
		/// Get a list of System Settings
		/// </summary>
		/// <returns>JSON string of System Settings</returns>
		public ActionResult GetSettings()
		{
			var dbResult = _systemConfigHandler.ReadAll();

			var jsonNetResult = new JsonNetResult {Data = dbResult};

			return jsonNetResult;
		}

		// GET: /System/Details/5
		public ActionResult GetSettingDetails(string categoryName, string settingName)
		{
			var dbResult = _systemConfigHandler.ReadOne(categoryName, settingName);
			if (dbResult == null)
			{
				return HttpNotFound();
			}

			var jsonNetResult = new JsonNetResult {Data = dbResult};

			return jsonNetResult;
		}

		[HttpPost, ValidateJsonAntiForgeryToken]
		public ActionResult CreateSetting(SystemConfig config)
		{
			var response = new JsonResponseObject();
			try
			{
				response.Data = _systemConfigHandler.Create(ref config);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Exception = ex;
				response.Message = ex.Message;
			}

			var jsonNetResult = new JsonNetResult {Data = response};
			return jsonNetResult;
		}

		[HttpPost, ValidateJsonAntiForgeryToken]
		public ActionResult CreateSettingCategory(SystemConfigCategory configCategory)
		{
			var response = new JsonResponseObject();
			try
			{
				response.Data = _systemConfigCategoryHandler.Create(ref configCategory);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Exception = ex;
				response.Message = ex.Message;
			}

			return new JsonNetResult {Data = response};
		}

		[HttpPost, ValidateJsonAntiForgeryToken]
		public ActionResult UpdateSetting(SystemConfig config)
		{
			var response = new JsonResponseObject();
			try
			{
				response.Data = _systemConfigHandler.Update(ref config);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Exception = ex;
				response.Message = ex.Message;
			}

			return new JsonNetResult {Data = response};
		}

		[HttpPost, ValidateJsonAntiForgeryToken]
		public ActionResult UpdateSettingCategory(SystemConfigCategory configCategory)
		{
			var response = new JsonResponseObject();
			try
			{
				response.Data = _systemConfigCategoryHandler.Update(ref configCategory);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Exception = ex;
				response.Message = ex.Message;
			}

			return new JsonNetResult { Data = response };
		}

		// GET: /System/Create
		public ActionResult Create(SystemConfig config)
		{
			return View();
		}

		//
		// POST: /System/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /System/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /System/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /System/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /System/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		[AllowAnonymous]
		public ActionResult Setup()
		{
			var isSetup = ApplicationDbContext.SetupFirstUserAndRole();

			if (isSetup)
			{
				return Content("Setup Completed");
			}
			else
			{
				return Content("Setup NOT Completed");
			}
		}
	}
}
