using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fabrik.Common.Web;
using HuskyRescue.Core.Service;
using HuskyRescue.Core.Service.Enum;
using HuskyRescue.Core.Service.Payments;
using HuskyRescue.Core.ViewModel.Attributes;
using HuskyRescue.Core.ViewModel.Controllers.Events;
using HuskyRescue.Core.ViewModel.Extensions;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Core.Service.Entity;
using HuskyRescue.Web.Infrastructure;
using HuskyRescue.Web.Infrastructure.Extensions;
using NLog.Mvc;
using Braintree;
using Environment = System.Environment;
using Eventhandler = HuskyRescue.Core.Service.Entity.EventHandler;

namespace HuskyRescue.Web.Controllers
{
	public class EventsController : BaseController
	{
		private readonly ILogger _logger;
		private readonly BusinessHandler _businessHandler = new BusinessHandler();
		private readonly Eventhandler _eventHandler = new Eventhandler();
		private readonly MiscHandler _miscHandler = new MiscHandler();
		private readonly EventRegistrationHandler _eventRegistrationHandler = new EventRegistrationHandler();
		private readonly GolfRegistrationHandler _golfRegistrationHandler = new GolfRegistrationHandler();
		private readonly RoughRiderRegistrationHandler _roughRiderRegistrationHandler = new RoughRiderRegistrationHandler();

		public EventsController(ILogger logger)
		{
			_logger = logger;
		}

		public ActionResult Calendar()
		{
			_logger.Trace("/Events/Calendar (get) called");

			return View();
		}

		#region Events
		/// <summary>
		/// Show list of all events in the system (active and not)
		/// </summary>
		/// <returns></returns>
		[Authorize]
		public ActionResult Index()
		{
			_logger.Trace("/Events/Index (get) called");
			var events = _eventHandler.ReadAll();
			return View(events);
		}

		/// <summary>
		/// Create view to create a new event
		/// </summary>
		/// <returns></returns>
		[Authorize, ImportModelStateFromTempData]
		public ActionResult Create()
		{
			_logger.Trace("/Events/Create (get) called");
			var eventVm = new Event { Locations = _businessHandler.ReadAll().ToSelectListItems(Guid.Empty) };

			return View(eventVm);
		}

		/// <summary>
		/// Save posted HTML Form or JSON serialized Event object to database
		/// <seealso cref="HuskyRescue.Core.ViewModel.Entity.Event"/>
		/// </summary>
		/// <param name="eventVm"></param>
		/// <returns></returns>
		[Authorize, HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Create(Event eventVm)
		{
			_logger.Trace("/Events/Create (post) called");

			try
			{
				var result = _eventHandler.Create(ref eventVm);
				if (result == ServiceResultEnum.Failure)
				{
					return RedirectToAction("Create").Error(_eventHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Create Event Error", ex);
				return RedirectToAction("Create").Error(ex.Message);
			}
			return RedirectToAction("Index").Success("Event created");
		}

		/// <summary>
		/// Edit view to update an event
		/// </summary>
		/// <returns></returns>
		[Authorize, ImportModelStateFromTempData]
		public ActionResult Edit(Guid id)
		{
			_logger.Trace("/Events/Edit (get) called");
			var eventVm = _eventHandler.ReadOne(id);
			eventVm.Locations = _businessHandler.ReadAll().ToSelectListItems(Guid.Empty);

			var misc = _miscHandler.ReadOne(string.Empty, eventVm.Id.ToString());
			if (misc != null)
			{
				switch (misc.ID)
				{
					case "golfevent":
						eventVm.IsActiveGolfEvent = true;
						break;
					case "raffle":
						eventVm.IsActiveRaffle = true;
						break;
					case "roughriderevent":
						eventVm.IsActiveRoughRidersEvent = true;
						break;
				}
			}

			return View(eventVm);
		}

		/// <summary>
		/// Save posted HTML Form or JSON serialized Event object to database
		/// <seealso cref="HuskyRescue.Core.ViewModel.Entity.Event"/>
		/// </summary>
		/// <param name="eventVm"></param>
		/// <returns></returns>
		[Authorize, HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult Edit(Event eventVm)
		{
			_logger.Trace("/Events/Edit (post) called");

			try
			{
				var result = _eventHandler.Update(ref eventVm);
				if (result == ServiceResultEnum.Failure)
				{
					return RedirectToAction("Edit").Error(_eventHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Create Event Error", ex);
				return RedirectToAction("Edit").Error(ex.Message);
			}
			return RedirectToAction("Index").Success("Event updated");
		}

		/// <summary>
		/// Delete Event object using it's id; can be called from JSON or HTML Form
		/// <seealso cref="HuskyRescue.Core.ViewModel.Entity.Event"/>
		/// </summary>
		/// <param name="eventVm"></param>
		/// <returns></returns>
		[Authorize, HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken]
		public ActionResult Delete(Event eventVm)
		{
			_logger.Trace("/Events/Delete (post) called");

			try
			{
				var result = _eventHandler.Delete(eventVm.Id);
				if (result == ServiceResultEnum.Failure)
				{
					return RedirectToAction("Index").Error(_eventHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Delete Event Error", ex);
				return RedirectToAction("Index").Error(ex.Message);
			}
			return RedirectToAction("Index").Success("Event deleted");
		}
		#endregion Events

		#region Event Registration
		public ActionResult RegistrationIndex(ContentType type = ContentType.Html)
		{
			_logger.Trace("/Events/RegistrationIndex (get) called");

			var result = _eventRegistrationHandler.ReadAll();

			if (type == ContentType.Json)
			{
				var items = (from item in result
							 select new
							 {
								 item.Id,
								 item.EventId,
								 EventName = item.Event.Name,
								 item.Event.IsActive,
								 IsActiveGolf = item.Event.IsActiveGolfEvent,
								 item.Event.IsActiveRaffle,
								 IsActiveRoughRiders = item.Event.IsActiveRoughRidersEvent,
								 DateRegistrationSubmitted = item.DateSubmitted,
								 PaymentMethod = item.PaymentMethodText,
								 NumberTicketsPurchased = item.TicketsBought,
								 NumberOfAttendees = item.Attendees.Count
							 });

				return new JsonNetResult { Data = items };
			}
			return View(result);
		}

		// GET: /Events/RegistrationCreate
		public ActionResult RegistrationCreate()
		{
			_logger.Trace("/Events/RegistrationCreate (get) called");

			return View(new EventRegistration());
		}

		// POST: /Events/RegistrationCreate
		[HttpPost]
		public ActionResult RegistrationCreate(EventRegistration eventRegVm)
		{
			_logger.Trace("/Events/RegistrationCreate (post) called");

			try
			{
				_eventRegistrationHandler.Create(ref eventRegVm);
				return RedirectToAction("Index");
			}
			catch
			{
				return View(eventRegVm);
			}
		}

		// GET: /Events/RegistrationEdit
		public ActionResult RegistrationEdit(Guid id)
		{
			_logger.Trace("/Events/RegistrationEdit (get) called");

			var eventReg = _eventRegistrationHandler.ReadOne(id);

			SetupReg(ref eventReg);

			return View(eventReg);
		}

		// POST: /Events/RegistrationEdit
		[HttpPost]
		public ActionResult RegistrationEdit(EventRegistration eventReg)
		{
			_logger.Trace("/Events/RegistrationEdit (post) called");

			try
			{
				_eventRegistrationHandler.Update(ref eventReg);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.Error("EventRegistrationEdit", ex);
				SetupReg(ref eventReg);
				return View(eventReg);
			}
		}

		// GET: /Events/RegistrationDelete
		public ActionResult RegistrationDelete(Guid id)
		{
			_logger.Trace("/Events/RegistrationDelete (get) called");

			try
			{
				_eventRegistrationHandler.Delete(id);
			}
			catch (Exception ex)
			{
				_logger.Error("EventRegistrationEdit", ex);
			}
			return RedirectToAction("RegistrationIndex");
		}

		private void SetupReg(ref EventRegistration eventReg)
		{
			var count = (eventReg.Event.IsActiveGolfEvent) ? 4 : 1;
			if (eventReg.Id != Guid.Empty)
			{
				count = eventReg.Attendees.Count;
				eventReg.intListPlayerCount = count;
			}
			else
			{
				for (var i = 1; i < count; i++)
				{
					eventReg.Attendees.Add(new EventAttendee());
					eventReg.Attendees[i].PlayerNumber = i + 1;
				}
			}

			for (var i = 0; i < eventReg.Attendees.Count; i++)
			{
				var person = eventReg.Attendees[i].Person;
				SetupBase(ref person);
				eventReg.Attendees[i].Person = person;
			}
		}
		#endregion

		#region predefined events

		#region Rough Riders Event
		
		[ImportModelStateFromTempData]
		public ActionResult RoughRiders()
		{
			_logger.Trace("/Events/RoughRiders (get) called");

			var roughRidersReg = new RoughRiderRegistration();

			try
			{
				var roughRiderEventId = new Guid(_miscHandler.ReadOne("roughriderevent").Value);
				var roughRiderEvent = _eventHandler.ReadOne(roughRiderEventId);

				roughRidersReg.EventRegistration =
					new EventRegistration
					{
						EventId = roughRiderEventId,
						Event = roughRiderEvent,
						PaymentMethod = 6
					};
				roughRidersReg.SetupAttendees(true);

				// Pass the client key for encrypting credit card information
				ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;
			}
			catch (Exception ex)
			{
				_logger.Trace("Error loading RoughRiders (get)", ex);
				return View(roughRidersReg).Error(ex.Message);
			}

			return View(roughRidersReg);
		}

		// POST: /Events/RegistrationCreate
		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult RoughRiders(RoughRiderRegistration eventRegVm, FormCollection collection)
		{
			_logger.Trace("/Events/RoughRiders (post) called");

			// get encrypted card information
			eventRegVm.BillingInformation.CreditCardNumber = collection["number"];
			eventRegVm.BillingInformation.CreditCardExpireMonth = collection["month"];
			eventRegVm.BillingInformation.CreditCardExpireYear = collection["year"];
			eventRegVm.BillingInformation.CreditCardCvv = collection["cvv"];

			try
			{
				var result = _roughRiderRegistrationHandler.Create(ref eventRegVm);
				if (result == ServiceResultEnum.Failure)
				{
					_logger.Warning("Rough Rider Tournament Failure: " + string.Join<string>(Environment.NewLine, _roughRiderRegistrationHandler.Messages));
					return RedirectToAction("RoughRiders").Error(_roughRiderRegistrationHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Rough Rider Registration Error", ex);
				_roughRiderRegistrationHandler.Messages.Add(ex.Message);
				return RedirectToAction("RoughRiders").Error(_roughRiderRegistrationHandler.Messages);
			}

			return RedirectToAction("RoughRidersThankYou").Success("Registration and payment submitted successfully");
		}

		public ActionResult RoughRidersThankYou()
		{
			_logger.Trace("/Events/RoughRidersThankYou (get) called");

			return View();
		}
		#endregion

		#region Golf Tournament Event
		[Authorize]
		public ActionResult GolfTournamentRegistrationIndex()
		{
			_logger.Trace("/Events/GolfTournamentRegistrationIndex (get) called");

			var currentGolfTournamentId = new Guid(_miscHandler.ReadOne("golfevent").Value);

			var result = _eventRegistrationHandler.ReadFiltered(new EventRegistration { EventId = currentGolfTournamentId });

			return View(result);
		}

		[Authorize, ImportModelStateFromTempData]
		public ActionResult GolfTournamentRegistrationCreate()
		{
			_logger.Trace("/Events/GolfTournamentRegistrationCreate (get) called");

			var golfEventReg = new GolfRegistration { IsAdminView = true };
			try
			{
				var golfEventId = new Guid(_miscHandler.ReadOne("golfevent").Value);
				var golfEvent = _eventHandler.ReadOne(golfEventId);

				golfEventReg.EventRegistration =
					new EventRegistration
					{
						EventId = golfEventId,
						Event = golfEvent,
						PaymentMethod = 6
					};
				golfEventReg.SetupAttendees(true);

				// Pass the client key for encrypting credit card information
				ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;
			}
			catch (Exception ex)
			{
				_logger.Trace("Error loading GolfTournamentRegistrationCreate (get)", ex);
				return View(golfEventReg).Error(ex.Message);
			}

			return View(golfEventReg);
		}

		[Authorize, HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult GolfTournamentRegistrationCreate(GolfRegistration golfReg, FormCollection collection)
		{
			_logger.Trace("/Events/GolfTournamentRegistrationCreate (post) called");

			// get encrypted card information
			golfReg.BillingInformation.CreditCardNumber = collection["number"];
			golfReg.BillingInformation.CreditCardExpireMonth = collection["month"];
			golfReg.BillingInformation.CreditCardExpireYear = collection["year"];
			golfReg.BillingInformation.CreditCardCvv = collection["cvv"];

			try
			{
				var result = _golfRegistrationHandler.Create(ref golfReg);
				if (result == ServiceResultEnum.Failure)
				{
					_logger.Warning("Golf Tournament Failure: " + string.Join<string>(Environment.NewLine, _golfRegistrationHandler.Messages));
					return RedirectToAction("GolfTournamentRegistrationCreate").Error(_golfRegistrationHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Golf Registration Error", ex);
				_golfRegistrationHandler.Messages.Add(ex.Message);
				return RedirectToAction("GolfTournamentRegistrationCreate").Error(_golfRegistrationHandler.Messages);
			}

			return RedirectToAction("GolfTournamentRegistrationIndex", new { @amount = golfReg.EventRegistration.AmountDue }).Success("Registration and payment submitted successfully");
		}

		[Authorize, ImportModelStateFromTempData]
		public ActionResult GolfTournamentRegistrationEdit(Guid id)
		{
			_logger.Trace("/Events/GolfTournamentRegistrationEdit (get) called");

			var golfEventReg = new GolfRegistration { IsAdminView = true, ShowPaymentSection = false };

			try
			{
				var golfEventId = new Guid(_miscHandler.ReadOne("golfevent").Value);
				var golfEvent = _eventHandler.ReadOne(golfEventId);

				golfEventReg.EventRegistration = _eventRegistrationHandler.ReadOne(id);
				golfEventReg.SetupAttendees(false);

				// Pass the client key for encrypting credit card information
				ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;
			}
			catch (Exception ex)
			{
				_logger.Trace("Error loading GolfTournamentRegistrationEdit (get)", ex);
				return View(golfEventReg).Error(ex.Message);
			}

			return View(golfEventReg);
		}

		[Authorize, HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult GolfTournamentRegistrationEdit(GolfRegistration golfReg, FormCollection collection)
		{
			_logger.Trace("/Events/GolfTournamentRegistrationEdit (post) called");

			try
			{
				var result = _golfRegistrationHandler.Update(ref golfReg);
				if (result == ServiceResultEnum.Failure)
				{
					_logger.Warning("Golf Tournament Failure: " + string.Join<string>(Environment.NewLine, _golfRegistrationHandler.Messages));
					return RedirectToAction("GolfTournamentRegistrationEdit").Error(_golfRegistrationHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Golf Registration Error", ex);
				_golfRegistrationHandler.Messages.Add(ex.Message);
				return RedirectToAction("GolfTournamentRegistrationEdit").Error(_golfRegistrationHandler.Messages);
			}

			return RedirectToAction("GolfTournamentRegistrationIndex", new { @amount = golfReg.EventRegistration.AmountDue }).Success("Registration and payment submitted successfully");
		}

		[Authorize, HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken]
		public ActionResult GolfTournamentRegistrationDelete(GolfRegistration golfReg)
		{
			_logger.Trace("/Events/GolfTournamentRegistrationDelete (post) called");

			try
			{
				var result = _golfRegistrationHandler.Delete(golfReg.EventRegistration.Id);
				if (result == ServiceResultEnum.Failure)
				{
					return RedirectToAction("GolfTournamentRegistrationIndex").Error(_golfRegistrationHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Delete Event Error", ex);
				return RedirectToAction("GolfTournamentRegistrationIndex").Error(ex.Message);
			}
			return RedirectToAction("GolfTournamentRegistrationIndex").Success("Event Registration deleted");
		}

		/// <summary>
		/// Primary golf tournament page
		/// </summary>
		/// <returns></returns>
		public ActionResult GolfTournament()
		{
			_logger.Trace("/Events/GolfTournament (get) called");

			return View();
		}

		/// <summary>
		/// Sponsors page of the golf tournament - really this lists the sponsorships available, their costs, and what a sponsor gets
		/// </summary>
		/// <returns></returns>
		public ActionResult GolfTournamentSponsors()
		{
			_logger.Trace("/Events/GolfTournamentSponsors (get) called");

			return View();
		}

		/// <summary>
		/// Silent auction items that will be available at the dinner after the golf tournament
		/// </summary>
		/// <returns></returns>
		public ActionResult GolfTournamentAuction()
		{
			_logger.Trace("/Events/GolfTournamentSponsors (get) called");

			return View();
		}

		/// <summary>
		/// Registration page
		/// </summary>
		/// <returns></returns>
		[ImportModelStateFromTempData]
		public ActionResult GolfTournamentRegister()
		{
			_logger.Trace("/Events/GolfTournamentRegister (get) called");

			var golfEventReg = new GolfRegistration();

			try
			{
				var golfEventId = new Guid(_miscHandler.ReadOne("golfevent").Value);
				var golfEvent = _eventHandler.ReadOne(golfEventId);

				golfEventReg.EventRegistration =
					new EventRegistration
					{
						EventId = golfEventId,
						Event = golfEvent,
						PaymentMethod = 6
					};
				golfEventReg.SetupAttendees(true);

				// Pass the client key for encrypting credit card information
				ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;
			}
			catch (Exception ex)
			{
				_logger.Trace("Error loading GolfTournamentRegister (get)", ex);
				return View(golfEventReg).Error(ex.Message);
			}

			return View(golfEventReg);
		}

		[HttpPost, ValidateJsonAntiForgeryToken, ValidateAntiForgeryToken, AutoFormatResult]
		public ActionResult GolfTournamentRegister(GolfRegistration golfReg, FormCollection collection)
		{
			_logger.Trace("/Events/GolfTournamentRegister (post) called");

			// get encrypted card information
			golfReg.BillingInformation.CreditCardNumber = collection["number"];
			golfReg.BillingInformation.CreditCardExpireMonth = collection["month"];
			golfReg.BillingInformation.CreditCardExpireYear = collection["year"];
			golfReg.BillingInformation.CreditCardCvv = collection["cvv"];

			try
			{
				var result = _golfRegistrationHandler.Create(ref golfReg);
				if (result == ServiceResultEnum.Failure)
				{
					_logger.Warning("Golf Tournament Failure: " + string.Join<string>(Environment.NewLine, _golfRegistrationHandler.Messages));
					return RedirectToAction("GolfTournamentRegister").Error(_golfRegistrationHandler.Messages);
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Golf Registration Error", ex);
				_golfRegistrationHandler.Messages.Add(ex.Message);
				return RedirectToAction("GolfTournamentRegister").Error(_golfRegistrationHandler.Messages);
			}

			return RedirectToAction("GolfTournamentThankYou", new { @amount = golfReg.EventRegistration.AmountDue }).Success("Registration and payment submitted successfully");
		}

		public ActionResult GolfTournamentThankYou(Decimal amount)
		{
			_logger.Trace("/Events/GolfTournamentThankYou (get) called");

			ViewData.Add(new KeyValuePair<string, object>("amount", amount));

			return View();
		}
		#endregion

		#region Raffle
		public ActionResult Raffle()
		{
			_logger.Trace("/Events/Raffle (get) called");

			return View();
		}

		public ActionResult RaffleThankYou()
		{
			_logger.Trace("/Events/RaffleThankYou (get) called");

			return View();
		}

		public ActionResult RaffleTickets()
		{
			_logger.Trace("/Events/RaffleRegister (get) called");

			var eventRegVm = new EventRegistration { EventId = new Guid(_miscHandler.ReadOne("raffle").Value) };
			eventRegVm.Event = _eventHandler.ReadOne(eventRegVm.EventId);
			eventRegVm.BuildAttendees(1);
			var person = eventRegVm.Attendees[0].Person;
			SetupBase(ref person);
			eventRegVm.Attendees[0].Person = person;

			// Remove Google, Square, Cash, Check.
			eventRegVm.PaymentMethod = 6;

			// Pass the client key for encrypting credit card information
			ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;

			return View(eventRegVm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult RaffleTickets(EventRegistration eventRegVm, FormCollection collection)
		{
			_logger.Trace("/Events/RaffleRegister (post) called");

			if (eventRegVm.TicketsBought != null)
			{
				var numberTickets = eventRegVm.TicketsBought.Value;
				eventRegVm.AmountPaid = (numberTickets / 3) * 2 * 50 + (numberTickets % 3) * 50;
				var responseErrorMessage = string.Empty;

				try
				{
					var request = new TransactionRequest
												 {
													 Amount = eventRegVm.AmountPaid,
													 //OrderId = "order id",
													 //MerchantAccountId = "a_merchant_account_id",
													 CreditCard = new TransactionCreditCardRequest
																  {
																	  Number = collection["number"],
																	  CVV = collection["cvv"],
																	  ExpirationMonth = collection["month"],
																	  ExpirationYear = collection["year"]
																  },
													 Customer = new CustomerRequest
																{
																	FirstName = eventRegVm.Attendees[0].Person.FirstName,
																	LastName = eventRegVm.Attendees[0].Person.LastName,
																	Phone = eventRegVm.Attendees[0].Person.Base.PhoneNumbers[0].Number,
																	Email = eventRegVm.Attendees[0].Person.Base.EmailAddresses[0].Address
																},
													 BillingAddress = new AddressRequest
																	  {
																		  FirstName = eventRegVm.Attendees[0].Person.FirstName,
																		  LastName = eventRegVm.Attendees[0].Person.LastName,
																		  StreetAddress = eventRegVm.Attendees[0].Person.Base.Addresses[0].Street,
																		  Locality = eventRegVm.Attendees[0].Person.Base.Addresses[0].City,
																		  Region = eventRegVm.Attendees[0].Person.Base.Addresses[0].StateID,
																		  PostalCode = eventRegVm.Attendees[0].Person.Base.Addresses[0].ZIP,
																		  CountryCodeAlpha2 = "US"
																	  },
													 Options = new TransactionOptionsRequest
															   {
																   StoreInVaultOnSuccess = true,
																   AddBillingAddressToPaymentMethod = true,
																   SubmitForSettlement = true
															   },
													 CustomFields = new Dictionary<string, string>
						                                            {
							                                            {"transaction_desc", "# of Tickets Purchased: " + numberTickets}
						                                            }
												 };

					var result = Constants.BraintreeGateway.Transaction.Sale(request);

					// Check if the credit card processed without error
					if (result.IsSuccess())
					{
						_logger.Information("Raffle Credit Card Charge Success");

						_eventRegistrationHandler.Create(ref eventRegVm);

						_logger.Information("Raffle register success - person id: " + eventRegVm.Attendees[0].Person.ID.ToString());

						return RedirectToAction("RaffleThankYou");
					}
					// Populate error information to be used in the View
					var errorString = string.Empty;

					// An error occurred while processing the credit card information
					Transaction transaction = null;
					if (result.Transaction != null)
					{
						transaction = result.Transaction;

						if (transaction.Status == TransactionStatus.AUTHORIZATION_EXPIRED)
						{
							responseErrorMessage = "Authorization Expired";
						}
						else if (transaction.Status == TransactionStatus.FAILED)
						{
							responseErrorMessage = "Failed";
						}
						else if (transaction.Status == TransactionStatus.GATEWAY_REJECTED)
						{
							var reason = (transaction.GatewayRejectionReason.ToString() == "avs") ? "Address Verification Failed" : "Unknown";
							responseErrorMessage = "Gateway Rejected: " + reason;
						}
						else if (transaction.Status == TransactionStatus.PROCESSOR_DECLINED)
						{
							responseErrorMessage = "Processor Declined: " + transaction.ProcessorResponseCode + " - " + transaction.ProcessorResponseText;
						}
						else if (transaction.Status == TransactionStatus.UNRECOGNIZED)
						{
							responseErrorMessage = "Unrecognized";
						}
					}

					var errorList = result.Errors.DeepAll().Select(error => "Validation Error on " + error.Attribute + ". Error: " + error.Code + " - " + error.Message).ToList();

					errorString = errorList.Aggregate(errorString, (current, error) => current + (error + System.Environment.NewLine));

					var errorLog = "Credit Card Error:" + System.Environment.NewLine + responseErrorMessage;
					if (transaction != null)
					{
						errorLog = System.Environment.NewLine + "transaction Id: " + transaction.Id
								   + System.Environment.NewLine + "ProcessorAuthorizationCode: " + transaction.ProcessorAuthorizationCode
								   + System.Environment.NewLine + "CvvResponseCode: " + transaction.CvvResponseCode;
					}
					errorLog = System.Environment.NewLine + errorString;

					_logger.Error(errorLog);

					ViewData["ErrorMessage"] = "There was a problem processing your credit card, please double check your address, re-enter your card data, and try again.";

					// Pass the client key for encrypting credit card information
					ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;

					// Populate Drop Down inputs 
					var person = eventRegVm.Attendees[0].Person;
					SetupBase(ref person);
					eventRegVm.Attendees[0].Person = person;

					eventRegVm.PaymentMethod = 6;

					return View(eventRegVm);
				}
				catch (Exception ex)
				{
					_logger.Error("Raffle Ticket Exception: " + ex.Message);

					// Pass the client key for encrypting credit card information
					ViewBag.ClientKey = Properties.Settings.Default.BrainTreeClientKey;

					// Populate Drop Down inputs 
					var person = eventRegVm.Attendees[0].Person;
					SetupBase(ref person);
					eventRegVm.Attendees[0].Person = person;

					eventRegVm.PaymentMethod = 6;

					ViewData["ErrorMessage"] = "There was a problem processing your credit card, please double check your address, re-enter your card data, and try again.";

					return View(eventRegVm);
				}
			}
			return View(eventRegVm);
		}

		public ActionResult RaffleGallery()
		{
			return View();
		}

		public ActionResult RafflePrizes()
		{
			_logger.Trace("/Events/RafflePrizes (get) called");

			return View();
		}

		public ActionResult RaffleFinePrint()
		{
			_logger.Trace("/Events/RaffleFinePrint (get) called");

			return View();
		}
		#endregion

		#endregion

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

				//mobile
				person.Base.PhoneNumbers[0].PhoneNumberTypeList = phoneNumberTypes.ToSelectListItems("3");
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
