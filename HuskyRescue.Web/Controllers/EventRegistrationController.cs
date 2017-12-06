using System;
using System.Data.Services.Client;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using AnimalRescue.Model;
using AnimalRescue.Services;
using AnimalRescue.Utilities;
using AnimalRescue.Web.Helpers;
using AnimalRescue.Web.Infrastructure;
using AnimalRescue.Web.Properties;
using AnimalRescue.Web.ViewModel;
using AutoMapper;

namespace AnimalRescue.Web.Controllers
{
	public class EventRegistrationController : Controller
	{
		public EventRegistrationController()
		{

		}

		//
		// GET: /EventRegistration/
		[Authorize]
		public ActionResult Index(Guid? EventID)
		{
			AnimalRescueEntities svc = new AnimalRescueEntities();
			if (EventID.HasValue)
			{
				// if an event is selected then show the registrations for that event.
				var attendees = svc.Event_Attendee.Where(a => a.ID.Equals(EventID)).ToList<Event_Attendee>();
				//foreach (var attendee in attendees)
				//{
				//    svc.Event_Registration.Where(reg => reg.)
				//}

				//if (Request.IsAjaxRequest())
				//{
				//    //return PartialView("AttendeesList", attendees.AsEnumerable<AdoptionApplicationViewModel>());
				//}
				//List<Event_AttendeeViewModel> attendeesVM = new List<Event_AttendeeViewModel>();
				//attendeesVM = Mapper.Map<List<Event_Attendee>, List<Event_AttendeeViewModel>>(attendees.ToList<Event_Attendee>());
				return View(attendees);
			}
			else
			{
				// if no event selected then send a list of events to the client to be selected
				var events = svc.Events;
				//events.Expand(e => e.Event_Registration);//get registartions
				//events.Expand(e => e.Entity_Base); //get owner of event

				if (Request.IsAjaxRequest())
				{
					//return PartialView("AdoptionApplicationList", events.AsEnumerable<AdoptionApplicationViewModel>());
				}
				return View(events);
			}

			//var eventRegs = svc.Event_Registration;
			//eventRegs.Expand(reg => reg.Event_Attendee); // get attendees
			//eventRegs.Expand(reg => reg.Event); // get event info for the registrations
		}

		//
		// GET: /EventRegistration/Details/5
		[Authorize]
		public ActionResult Details(Guid ID)
		{
			var eventRegDB = new Event_Registration();
			var eventRegVM = new Event_RegistrationViewModel();

			using (Model.AnimalRescueEntities svc = new Model.AnimalRescueEntities())
			{
				svc.Connection.Open();

				eventRegDB = (from e in svc.Event_Registration
							  where e.ID.Equals(ID)
							  select e).Single();
				eventRegVM = Mapper.Map<Event_Registration, Event_RegistrationViewModel>(eventRegDB);

				svc.Connection.Close();
			}
			return View(eventRegVM);
		}

		//
		// GET: /EventRegistration/Create
		public ActionResult Create()
		{
			var eventRegVM = new Event_RegistrationViewModel();

			return View(eventRegVM);
		}

		//
		// POST: /EventRegistration/Create
		[HttpPost]
		public ActionResult Create(Event_RegistrationViewModel eventRegVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var eventRegDB = new Event_Registration();
					eventRegDB = Mapper.Map<Event_RegistrationViewModel, Event_Registration>(eventRegVM);

					AnimalRescueEntities svc = new AnimalRescueEntities();
					svc.AddToEvent_Registration(eventRegDB);

					// Send the insert to the data service.
					svc.SaveChanges();
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /EventRegistration/Create
		public ActionResult CreateGolfReg()
		{
            PopulateEnumCache pCache = new PopulateEnumCache();

			var eventRegVM = new Event_RegistrationViewModel();

			eventRegVM.BuildAttendees();

			foreach (var attendee in eventRegVM.Event_Attendee)
			{
				// by default Address, Entity_EmailAddress, and Entity_PhoneNumber have a length of 1 when a new entity is created
				foreach (var address in attendee.Entity_Person.Entity_Base.Entity_Addresses)
				{
                    address.AddressStateList = pCache.Enum_UsaStates.ToSelectListItems("TX");
                    address.AddressTypeList = pCache.Enum_AddressType.ToSelectListItems("1");
				}

				foreach (var email in attendee.Entity_Person.Entity_Base.Entity_EmailAddress)
				{
                    email.EmailTypeList = pCache.Enum_EmailType.ToSelectListItems("1");
				}

				foreach (var phone in attendee.Entity_Person.Entity_Base.Entity_PhoneNumber)
				{
                    phone.PhoneNumberTypeList = pCache.Enum_PhoneType.ToSelectListItems("1");
				}
			}
			eventRegVM.EventID = Settings.Default.GolfTournament;

			return View(eventRegVM);
		}

		//
		// POST: /EventRegistration/Create
		[HttpPost]
		public ActionResult CreateGolfReg(Event_RegistrationViewModel eventRegVM)
		{
			try
			{
				eventRegVM.Event_Attendee.RemoveAll(x => string.IsNullOrWhiteSpace(x.Entity_Person.FullName));
				eventRegVM.PlayerCount = eventRegVM.Event_Attendee.Count;
				eventRegVM.EventID = Settings.Default.GolfTournament;

				using (Model.AnimalRescueEntities context = new Model.AnimalRescueEntities())
				{
					using (TransactionScope transaction = new TransactionScope())
					{
						context.Connection.Open();

						//Retrieve the event
						var eventDB = context.Events.Single(e => e.ID.Equals(Settings.Default.GolfTournament));

						var eventRegDB = new Event_Registration();
						eventRegDB = Mapper.Map<Event_RegistrationViewModel, Event_Registration>(eventRegVM);
						eventRegDB.EventID = eventDB.ID;

						//Add the link between EVENT and REGISTRATION
						context.AddToEvent_Registration(eventRegDB);

						int i = 1;
						Guid EventRegID = Guid.Empty;
						foreach (var attendee in eventRegDB.Event_Attendee)
						{
							attendee.AttendeeType = 2; //Participant

							if (i > 1)
							{
								attendee.EventRegistrationID = EventRegID;
							}

							context.AddToEvent_Attendee(attendee);
							context.AddToEntity_Base(attendee.Entity_Person.Entity_Base);
							context.AddToEntity_Person(attendee.Entity_Person);
							foreach (var address in attendee.Entity_Person.Entity_Base.Entity_Addresses)
							{
								context.AddToEntity_Addresses(address);
							}
							foreach (var phone in attendee.Entity_Person.Entity_Base.Entity_PhoneNumber)
							{
								context.AddToEntity_PhoneNumber(phone);
							}
							foreach (var email in attendee.Entity_Person.Entity_Base.Entity_EmailAddress)
							{
								if (!string.IsNullOrWhiteSpace(email.Address) && !string.IsNullOrWhiteSpace(email.Type))
								{
									context.AddToEntity_EmailAddress(email);
								}
							}

							i++;
						}
						// Send the insert to the data service.
						context.SaveChanges();
						context.AcceptAllChanges();
						transaction.Complete();
					}

				}

				string body =
@"

Thank you for registering for the 1st Annual Texas Husky Rescue Golf Tournament Presented by 'Living Breathing Being - Life Coaching' (http://www.livingbreathingbeing.com/).

You can expect to receive an email closer to the tournament with further details.  If you have any questions prior to then, please feel free to contact us at this email address.	

Read more about the event and visit our other sponsors http://www.texashuskyrescue.org/mp/golf.aspx.

http://www.TexasHuskyRescue.org/ | http://www.facebook.com/texashuskyrescue | http://twitter.com/#!/txhuskyrescue 
1-877-TX-HUSKY (894-8759) (phone/fax)
PO Box 118891, Carrollton, TX 75011

";
				string contactEmail = Settings.Default.ContactEmail;
				foreach (var app in eventRegVM.Event_Attendee)
				{
					if (!string.IsNullOrWhiteSpace(app.Entity_Person.Entity_Base.Entity_EmailAddress.Single().Address))
					{
						string subject = "Online Golf Registration for " + app.Entity_Person.FullName;
						string email = app.Entity_Person.Entity_Base.Entity_EmailAddress.Single().Address;
						SendMailASES.SendEmail(contactEmail, email, subject, body, body, contactEmail);
					}
				}

				string subjectGroup = "Online Golf Registration for ";
				string bodyGroup = eventRegVM.DateSubmitted.ToShortDateString() + "\n\n";
				foreach (var app in eventRegVM.Event_Attendee)
				{
					subjectGroup += app.Entity_Person.FullName;
					if (eventRegVM.Event_Attendee.Count > 1)
						subjectGroup += ", ";

					bodyGroup += @"Name: " + app.Entity_Person.FullName + "\n";
					bodyGroup += @"Email: " + app.Entity_Person.Entity_Base.Entity_EmailAddress.Single().Address + "\n";
					bodyGroup += @"Address: " + app.Entity_Person.Entity_Base.Entity_Addresses.Single().AddressFull + "\n";
					bodyGroup += @"Phone: " + app.Entity_Person.Entity_Base.Entity_PhoneNumber.Single().Number + "\n\n";
				}
				char[] charsToTrim = { ',', ' ' };
				subjectGroup = subjectGroup.TrimEnd(charsToTrim);
				SendMailASES.SendEmail(contactEmail, contactEmail, subjectGroup, bodyGroup, bodyGroup);

				return RedirectToAction("ThankYou");
			}
			catch (Exception ex)
			{
				return Content(ex.ToString());
			}
		}

		public ActionResult ThankYou()
		{
			return View();
		}


		//
		// GET: /EventRegistration/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /EventRegistration/Edit/5
		[Authorize]
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
		// GET: /EventRegistration/Delete/5
		[Authorize]
		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /EventRegistration/Delete/5
		[Authorize]
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
	}
}
