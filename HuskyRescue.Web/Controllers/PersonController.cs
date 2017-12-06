using System;
using System.Linq;
using System.Web.Mvc;
using HuskyRescue.Core.Service;
using HuskyRescue.Core.Service.Enum;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Core.Service.Entity;
using HuskyRescue.Core.ViewModel.Extensions;
using HuskyRescue.Web.Infrastructure;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	[Authorize]
	public class PersonController : BaseController
	{
		private readonly ILogger _logger;
		private readonly PersonHandler _personHandler = new PersonHandler();
		public PersonController(ILogger logger)
		{
			_logger = logger;
		}

		public ActionResult GetPeoples()
		{
			var dbResult = _personHandler.ReadAll();
			var people = (from person in dbResult
						  select new
						  {
							  person.ID,
							  person.BaseID,
							  person.FullName,
							  person.Base.PrimaryAddressText,
							  person.Base.PhoneNumberFormatted,
							  person.Base.EmailAddressText
						  });
			var jsonNetResult = new JsonNetResult {Data = people};
			return jsonNetResult;
		}

		//
		// GET: /Person/
		public ActionResult Index()
		{
			_logger.Trace("/Person/Index (get) called");

			return View(_personHandler.ReadAll());
		}

		public ActionResult Adopters()
		{
			return View();
		}

		public ActionResult Fosters()
		{
			return View();
		}

		public ActionResult GetPeople()
		{
			_logger.Trace("/Person/GetPeople (get) called");

			var persons = _personHandler.ReadAll();

			var jsonNetResult = new JsonNetResult {Data = persons};

			return jsonNetResult;
		}

		//
		// GET: /Person/Create
		public ActionResult Create()
		{
			_logger.Trace("/Person/Create (get) called");
			var person = new Person();
			person.Base.BuildAddresses();
			person.Base.BuildEmailAddresses();
			person.Base.BuildPhoneNumbers(2);

			SetupBase(ref person, true);

			return View(person);
		}

		//
		// POST: /Person/Create
		[HttpPost]
		public ActionResult Create(Person person)
		{
			_logger.Trace("/Person/Create (post) called");
			try
			{
				_personHandler.Create(ref person);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Person/Edit/5
		public ActionResult Edit(Guid id)
		{
			_logger.Trace("/Person/Edit (get) called");

			var person = _personHandler.ReadOne(id);

			SetupBase(ref person);

			return View(person);
		}

		//
		// POST: /Person/Edit/5
		[HttpPost]
		public ActionResult Edit(Person person)
		{
			_logger.Trace("/Person/Edit (post) called");
			try
			{
				_personHandler.Update(ref person);

				SetupBase(ref person);
			}
			catch (Exception ex)
			{
				return Content(ex.ToString());
			}

			return View(person);
		}

		//
		// POST: /Person/Delete/5
		[HttpPost]
		public ActionResult Delete(Guid id)
		{
			_logger.Trace("/Person/Delete (post) called");
			try
			{
				if (_personHandler.Delete(id) == ServiceResultEnum.Failure)
				{
					throw new Exception("Failed to delete person - " + id.ToByteArray());
				}
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return RedirectToAction("Index");
			}
		}

		private void SetupBase(ref Person person, Boolean isNew = false)
		{
			var usaStatesHandler = new UsaStatesHandler();
			var streetAddressTypeHandler = new StreetAddressTypeHandler();
			var emailTypeHandler = new EmailTypeHandler();
			var phoneNumberTypeHandler = new PhoneNumberTypeHandler();

			var emailTypes = emailTypeHandler.ReadAll();
			var phoneNumberTypes = phoneNumberTypeHandler.ReadAll();
			if (isNew)
			{
				person.Base.BuildPhoneNumbers(2);
				person.Base.BuildEmailAddresses();
				person.Base.BuildAddresses();

				foreach (var address in person.Base.Addresses)
				{
					address.AddressStateList = usaStatesHandler.ReadAll().ToSelectListItems("TX");
					//primary
					address.AddressTypeList = streetAddressTypeHandler.ReadAll().ToSelectListItems("1");
				}

				//personal
				person.Base.EmailAddresses[0].EmailTypeList = emailTypes.ToSelectListItems("1");

				//home
				person.Base.PhoneNumbers[0].PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems("1");
				//mobile
				person.Base.PhoneNumbers[1].PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems("3");
			}
			else
			{
				foreach (var address in person.Base.Addresses)
				{
					address.AddressStateList = usaStatesHandler.ReadAll().ToSelectListItems(address.StateID);
					address.AddressTypeList = streetAddressTypeHandler.ReadAll().ToSelectListItems(address.Type);
				}

				foreach (var email in person.Base.EmailAddresses)
				{
					email.EmailTypeList = emailTypes.ToSelectListItems(email.Type);
				}

				foreach (var phone in person.Base.PhoneNumbers)
				{
					phone.PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems(phone.Type);
				}
			}
		}
	}
}
