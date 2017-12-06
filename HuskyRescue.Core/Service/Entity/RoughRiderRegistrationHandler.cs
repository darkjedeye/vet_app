using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using Fabrik.Common;
using HuskyRescue.Core.Properties;
using HuskyRescue.Core.Service.Payments;
using HuskyRescue.Core.ViewModel;
using HuskyRescue.Core.ViewModel.Controllers.Events;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;

namespace HuskyRescue.Core.Service.Entity
{
	public class RoughRiderRegistrationHandler : NewBaseHandler, IBaseDabaseHandler<RoughRiderRegistration>
	{
		public RoughRiderRegistrationHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new EventRegistration to the database
		/// </summary>
		/// <param name="obj">EventRegistration object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Create(ref RoughRiderRegistration obj)
		{
			var eventReg = obj.EventRegistration;

			// Number of changes as a result of the database change
			NumberChanges = 0;

			// remove blank attendees
			eventReg.Attendees.RemoveAll(a => string.IsNullOrEmpty(a.Person.FirstName));
			eventReg.Attendees.ForEach(a => a.Person.Base.EmailAddresses.RemoveAll(b => string.IsNullOrEmpty(b.Address)));
			eventReg.Attendees.ForEach(a => a.Person.Base.PhoneNumbers.RemoveAll(b => string.IsNullOrEmpty(b.Number)));
			eventReg.Event = null;

			// only perform if payment section was shown to the user
			if (obj.ShowPaymentSection)
			{
				// send information to payment service
				var paymentResult = ServiceResultEnum.Failure;
				var payment = obj.GetPaymentInformation();
				try
				{
					var brainTreeHandler = new BrainTreeHandler();
					paymentResult = brainTreeHandler.SendTransactionRequest(ref payment);
					if (paymentResult == ServiceResultEnum.Success)
					{
						ServiceResult = paymentResult;
						eventReg.PaymentTransactionId = payment.TransactionResult.Target.Id;
						eventReg.HasPaid = true;
						Messages.Add("Payment processed successfully");
					}
				}
				catch (Exception ex)
				{
					Messages.Add(ex.Message);
				}

				// check if the payment was not processed
				if (paymentResult == ServiceResultEnum.Failure)
				{
					Messages.Add(payment.TransactionResult.Message);
					var errorMessage = payment.ErrorMessage();
					if (errorMessage.IsNotNullOrEmpty())
					{
						Messages.Add(errorMessage);
					}
					ServiceResult = paymentResult;
					return ServiceResult;
				}
			}

			// payment is a success, save information to the database
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = eventReg.ToModel();

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					dbObj = context.Event_Registration.Add(dbObj);

					// commit changes to the database
					NumberChanges = context.SaveChanges();

					// convert the database object back to a presentation object with included changes from the database (if any)
					eventReg = dbObj.ToViewModel();
				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
				Messages.Add(ex.Message);
			}
			catch (DbEntityValidationException ex)
			{
				Messages.AddRange(Common.FormatEntityValidationError(ex));
			}

			// check if database changes were a success
			ServiceResult = NumberChanges > 0 ? ServiceResultEnum.Success : ServiceResultEnum.Failure;
			if (ServiceResult == ServiceResultEnum.Success)
			{
				Messages.Add("Registration saved to database successfully");
			}
			// if the save to database didn't work then keep going as the payment already processed.
			// TODO: log registration information to database for manual entry

			// send emails
			var emailSendResult = ServiceResultEnum.Failure;
			try
			{
				const string subject = "2014 TXHR Night out with the Frisco RoughRiders";
				const string bodyAppHtml = @" 
Thank You for supporting Texas Husky Rescue. Your tickets will be available at Will Call the night of the game. As a reminder, the game is Friday May 23 at 7:05 PM at the DrPepper Ballpark. For seating and directions see this site http://goo.gl/BujLRR. 

Advance parking passes can also be purchased from Jessica (972-334-1936 or jenglish@ridersbaseball.com) with the RoughRiders for $5. Parking passes purchased the day of the game are $10. 

We'll see you at the game!

Thank you,
Texas Husky Rescue
1-877-TX-HUSKY (894-8759) (phone/fax)
PO Box 118891, Carrollton, TX 75011
";
				var message = new EmailMessage
				{
					BodyTextExternal = bodyAppHtml,
					BodyTextInternal = eventReg.RegistrationDescription,
					Subject = subject,
					EmailAddressExternal = eventReg.Attendees[0].Person.Base.EmailAddresses[0].Address,
					EmailAddressInternal = Settings.Default.RoughRiderEmail,
					NameInternal = "Texas Husky Rescue",
					NameExternal = string.Empty
				};

				var emailMessageHandler = new EmailMessageHandler();
				emailSendResult = emailMessageHandler.SendMessage(ref message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			if (emailSendResult == ServiceResultEnum.Success)
			{
				Messages.Add("Email confirmation sent");
			}

			return ServiceResultEnum.Success;
		}

		/// <summary>
		/// Updated existing EventRegistration in the database
		/// </summary>
		/// <param name="obj">EventRegistration object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Update(ref RoughRiderRegistration obj)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = obj.EventRegistration.ToModel();

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					context.Entry(dbObj).State = EntityState.Modified;

					// commit changes to the database
					NumberChanges = context.SaveChanges();

					// convert the database object back to a presentation object with included changes from the database (if any)
					obj.EventRegistration = dbObj.ToViewModel();
				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
				Messages.Add(ex.Message);
			}
			catch (DbEntityValidationException ex)
			{
				Messages.AddRange(Common.FormatEntityValidationError(ex));
			}

			return NumberChanges > 0 ? ServiceResultEnum.Success : ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Delete an EventRegistration from the database
		/// </summary>
		/// <param name="id">EventRegistration id the object to be deleted from the database</param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Delete(Guid id)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = context.Event_Registration.Find(id);

					if (dbObj != null)
					{
						context.Event_Registration.Remove(dbObj);

						// commit changes to the database
						NumberChanges = context.SaveChanges();
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (ValidationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			return NumberChanges > 0 ? ServiceResultEnum.Success : ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Retrieve on EventRegistration object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation EventRegistration object or null if not found</returns>
		public RoughRiderRegistration ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new RoughRiderRegistration();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj.EventRegistration = context.Event_Registration
						.Include(p => p.Event)
						.Include(p => p.Event_Attendee)
						.Single(x => x.ID == id)
						.ToViewModel();

					var miscHandler = new Enum.MiscHandler();
					var eventType = miscHandler.ReadOne("", obj.EventRegistration.EventId.ToString()).ID;

					switch (eventType)
					{
						case "roughriderevent":
							obj.EventRegistration.Event.IsActiveRoughRidersEvent = true;
							break;
					}

				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			return obj;
		}

		public RoughRiderRegistration ReadOne(Guid id)
		{
			return ReadOne(id, Guid.Empty, Guid.Empty, 0, 0, 0);
		}

		/// <summary>
		/// Retrieve all EventRegistrationes from the database for presentation
		/// </summary>
		/// <returns>list of EventRegistration</returns>
		public List<RoughRiderRegistration> ReadAll()
		{
			var objList = new List<RoughRiderRegistration>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					var objEventRegList = context.Event_Registration
						.Include(p => p.Event)
						.Include(p => p.Event_Attendee)
						.ToList()
						.ToViewModel();
					var miscHandler = new Enum.MiscHandler();
					var miscGolfEvent = miscHandler.ReadOne("golfevent");
					var miscRaffleEvent = miscHandler.ReadOne("roughriderevent");
					var miscRoughRiders = miscHandler.ReadOne("raffle");

					foreach (var item in objEventRegList)
					{
						if (item.Event.Id.ToString().ToLower() == miscGolfEvent.Value.ToLower())
						{
							item.Event.IsActiveGolfEvent = true;
						}
						if (item.Event.Id.ToString().ToLower() == miscRoughRiders.Value.ToLower())
						{
							item.Event.IsActiveRoughRidersEvent = true;
						}
						if (item.Event.Id.ToString().ToLower() == miscRaffleEvent.Value.ToLower())
						{
							item.Event.IsActiveRaffle = true;
						}
						objList.Add(new RoughRiderRegistration { EventRegistration = item });
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			return objList;
		}

		/// <summary>
		/// Retrieve list of presentation objects filtered by provided object's properties
		/// </summary>
		/// <param name="obj">Presentation object with properties used to filter database query</param>
		/// <returns>List of EventRegistration objects filtered and then sorted by name</returns>
		public List<RoughRiderRegistration> ReadFiltered(RoughRiderRegistration obj)
		{
			var objList = new List<RoughRiderRegistration>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Event_Registration, bool>>();
				if (Guid.Empty != obj.EventRegistration.Id) conditions.Add(x => x.ID == obj.EventRegistration.Id);
				if (Guid.Empty != obj.EventRegistration.EventId) conditions.Add(x => x.EventID == obj.EventRegistration.EventId);
				if (obj.EventRegistration.AmountPaid >= 0) conditions.Add(x => x.AmountPaid >= obj.EventRegistration.AmountPaid);
				if (obj.EventRegistration.TicketsBought >= 0) conditions.Add(x => x.TicketsBought >= obj.EventRegistration.TicketsBought);
				conditions.Add(x => x.HasPaid == obj.EventRegistration.HasPaid);

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Event_Registration.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					var objEventRegList = query.OrderByDescending(a => a.EventID)
						.Include(p => p.Event)
						.Include(p => p.Event_Attendee)
						.ToList().ToViewModel();

					var miscHandler = new Enum.MiscHandler();
					var miscGolfEvent = miscHandler.ReadOne("golfevent");
					var miscRaffleEvent = miscHandler.ReadOne("roughriderevent");
					var miscRoughRiders = miscHandler.ReadOne("raffle");

					foreach (var item in objEventRegList)
					{
						if (item.Event.Id.ToString().ToLower() == miscGolfEvent.Value.ToLower())
						{
							item.Event.IsActiveGolfEvent = true;
						}
						if (item.Event.Id.ToString().ToLower() == miscRoughRiders.Value.ToLower())
						{
							item.Event.IsActiveRoughRidersEvent = true;
						}
						if (item.Event.Id.ToString().ToLower() == miscRaffleEvent.Value.ToLower())
						{
							item.Event.IsActiveRaffle = true;
						}
						objList.Add(new RoughRiderRegistration { EventRegistration = item });
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}

			return objList;
		}
	}
}