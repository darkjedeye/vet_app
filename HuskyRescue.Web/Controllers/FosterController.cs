using System;
using System.Globalization;
using System.Web.Mvc;
using HuskyRescue.Core.Service.Enum;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Core.Service.Entity;
using HuskyRescue.Core.ViewModel.Extensions;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	public class FosterController : BaseController
	{
		private readonly ILogger _logger;
		private readonly ApplicantHandler _applicantHandler = new ApplicantHandler();
		public FosterController(ILogger logger)
		{
			_logger = logger;
		}

		//
		// GET: /Foster/
		[Authorize(Roles = "Administrator,Staff")]
		public ActionResult Index()
		{
			_logger.Trace("/Foster/Index (get) called");
			
			var apps = _applicantHandler.ReadFiltered(new Applicant { ApplicantType = "F" });

			return View(apps);
		}

		public ActionResult Apply()
		{
			_logger.Trace("/Foster/Apply (get) called");

			var app = new Applicant();
			SetupBase(ref app, true);

			return View(app);
		}

		[HttpPost]
		public ActionResult Apply(Applicant app)
		{
			_logger.Trace("/Foster/Apply (post) called");

			app.DateSubmitted = DateTime.Today;

			try
			{
				_applicantHandler.Create(ref app);
				return RedirectToAction("ThankYou");
			}
			catch (Exception ex)
			{
				_logger.Error("AdoptionAppCreate", ex);
				SetupBase(ref app);
			}
			return View(app);
		}

		public ActionResult ThankYou()
		{
			_logger.Trace("/Foster/ThankYou (get) called");

			return View();
		}

		//
		// GET: /Foster/Edit/5
		[Authorize(Roles = "Administrator,Staff")]
		public ActionResult Edit(Guid id, Guid personId)
		{
			_logger.Trace("/Foster/Edit (get) called");
			var app = _applicantHandler.ReadOne(id, personId);
			SetupBase(ref app);
			return View(app);
		}

		//
		// POST: /Foster/Edit/5
		[HttpPost]
		[Authorize(Roles = "Administrator,Staff")]
		public ActionResult Edit(Applicant app)
		{
			_logger.Trace("/Foster/Edit (post) called");
			try
			{
				_applicantHandler.Update(ref app);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.Error("AdoptionAppEdit", ex);
				SetupBase(ref app);
			}
			return View(app);

		}

		private void SetupBase(ref Applicant applicant, Boolean isNew = false)
		{
			var usaStatesHandler = new UsaStatesHandler();
			var residenceOwnershipTypeHandler = new ResidenceOwnershipTypeHandler();
			var petDepositCoverageTypeHandler = new PetDepositCoverageTypeHandler();
			var residenceTypeHandler = new ResidenceTypeHandler();
			var studentTypeHandler = new StudentTypeHandler();
			var genderHandler = new GenderHandler();

			var genders = genderHandler.ReadAll();
			if (isNew)
			{
				for (var i = 0; i < 4; i++)
				{
					applicant.ApplicantOwnedAnimal.Add(new ApplicantOwnedAnimal { GenderList = genders.ToSelectListItems(string.Empty) });
				}

				applicant.DateSubmitted = DateTime.Today;

				applicant.AppAddressStateList = usaStatesHandler.ReadAll().ToSelectListItems("TX");

				var ownershipList = residenceOwnershipTypeHandler.ReadAll();
				ownershipList.RemoveAll(x => x.ID == 0);
				applicant.ResidenceOwnershipList = ownershipList.ToSelectListItems();

				var coverageList = petDepositCoverageTypeHandler.ReadAll();
				coverageList.RemoveAll(x => x.ID == 0);
				applicant.ResidencePetDepositCoverageList = coverageList.ToSelectListItems();

				var residenceTypeList = residenceTypeHandler.ReadAll();
				residenceTypeList.RemoveAll(x => x.ID == 0);
				applicant.ResidenceTypeList = residenceTypeList.ToSelectListItems();

				var studentTypeList = studentTypeHandler.ReadAll();
				studentTypeList.RemoveAll(x => x.ID == 0);
				applicant.StudentTypeList = studentTypeList.ToSelectListItems();

				applicant.ApplicantType = "A";
			}
			else
			{
				foreach (var animal in applicant.ApplicantOwnedAnimal)
				{
					animal.GenderList = genders.ToSelectListItems(animal.Gender);
				}
				applicant.AppAddressStateList = usaStatesHandler.ReadAll().ToSelectListItems(applicant.AppAddressStateId);
				applicant.ResidenceOwnershipList = residenceOwnershipTypeHandler.ReadAll().ToSelectListItems(applicant.ResidenceOwnershipID.ToString(CultureInfo.InvariantCulture));
				applicant.ResidencePetDepositCoverageList = petDepositCoverageTypeHandler.ReadAll().ToSelectListItems(applicant.ResidencePetDepositCoverageID.ToString(CultureInfo.InvariantCulture));
				applicant.ResidenceTypeList = residenceTypeHandler.ReadAll().ToSelectListItems(applicant.ResidenceTypeID.ToString(CultureInfo.InvariantCulture));
				applicant.StudentTypeList = studentTypeHandler.ReadAll().ToSelectListItems(applicant.StudentTypeID.ToString(CultureInfo.InvariantCulture));
			}
		}
	}
}
