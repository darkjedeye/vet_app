using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Core.Properties;
using HuskyRescue.Core.ViewModel;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using EventRegistration = HuskyRescue.Core.ViewModel.Entity.EventRegistration;

namespace HuskyRescue.Core.Service.Entity
{
	public class EventRegistrationHandler : BaseHandler<EventRegistration>
	{
		public EventRegistrationHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new EventRegistration to the database
		/// </summary>
		/// <param name="obj">EventRegistration object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref EventRegistration obj)
		{
			var eventInfo = obj.Event;

			// Number of changes as a result of the database change
			NumberChanges = 0;

			try
			{
				obj.Attendees.RemoveAll(a => string.IsNullOrEmpty(a.Person.FirstName));
				obj.Attendees.ForEach(a => a.Person.Base.EmailAddresses.RemoveAll(b => string.IsNullOrEmpty(b.Address)));
				obj.Attendees.ForEach(a => a.Person.Base.PhoneNumbers.RemoveAll(b => string.IsNullOrEmpty(b.Number)));
				obj.Event = null;
						
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{

					// convert to database object
					var dbObj = obj.ToModel();

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					dbObj = context.Event_Registration.Add(dbObj);

					// commit changes to the database
					NumberChanges = context.SaveChanges();

					// convert the database object back to a presentation object with included changes from the database (if any)
					obj = dbObj.ToViewModel();
				}

				var miscHandler = new Enum.MiscHandler();

				if (obj.EventId.Equals(new Guid(miscHandler.ReadOne("roughriderevent").Value)))
				{
					var subject = "TXHR Night out with the RoughRiders " + obj.Attendees[0].Person.FullName;
					const string bodyAppHtml = @"<h3>Thank You for supporting Texas Husky Rescue.\r\nWe'll see you at the game!</h3>";

					var bodyGroup = obj.Attendees[0].Person.FullName + " bought " + obj.TicketsBought.ToString() + ".";
					if (obj.PaymentMethod != 0)
						bodyGroup += "Payment method was " + obj.PaymentMethodText;
					else
						bodyGroup = "Did not pick a payment method.";

					var message = new EmailMessage
					{
						BodyTextExternal = bodyAppHtml,
						BodyTextInternal = bodyGroup,
						Subject = subject,
						EmailAddressExternal = obj.Attendees[0].Person.Base.EmailAddresses[0].Address,
						EmailAddressInternal = Settings.Default.FundraisingEmail,
						NameInternal = "Texas Husky Rescue",
						NameExternal = string.Empty
					};
					message.SendMessage();
				}
				if (obj.EventId.Equals(new Guid(miscHandler.ReadOne("golfevent").Value)))
				{
					const string subject = "2013 TXHR Golf Tournament Attendee";
					const string bodyAppHtml = @" 
Thank you for registering for Texas Husky Rescue's 3rd Annual Golf Tournament at Coyote Ridge Golf Club!  We have no doubt you will have a fabulous time all while helping to support huskies in need throughout Texas.

You will be sent an email closer to the tournament with detailed information however if you have any questions prior to then, please feel free to email us at Golf@texashuskyrescue.org.

Thank you,
Texas Husky Rescue Golf Committee
1-877-TX-HUSKY (894-8759) (phone/fax)
PO Box 118891, Carrollton, TX 75011
";
					var bodyGroup = string.Empty;
					foreach (var a in obj.Attendees)
					{
						bodyGroup += a.Person.FullName;
						bodyGroup += "\r\n";
						bodyGroup += a.Person.Base.Addresses[0].AddressFull;
						bodyGroup += "\r\n";
						if (a.Person.Base.EmailAddresses.Count > 0)
						{
							if (!string.IsNullOrEmpty(a.Person.Base.EmailAddresses[0].Address))
							{
								bodyGroup += a.Person.Base.EmailAddresses[0].Address;
								bodyGroup += "\r\n";
							}
						}
						if (a.Person.Base.PhoneNumbers.Count > 0)
						{
							if (!string.IsNullOrEmpty(a.Person.Base.PhoneNumbers[0].Number))
							{
								bodyGroup += a.Person.Base.PhoneNumbers[0].Number;
								bodyGroup += "\r\n";
							}
						}
						bodyGroup += "\r\n";
					}
					if (obj.PaymentMethod != 0)
					{
						bodyGroup += "Payment method is " + obj.PaymentMethodText + ". ";
					}
					else
					{
						bodyGroup = "Did not pick a payment method.";
					}

					var message = new EmailMessage
					{
						BodyTextExternal = bodyAppHtml,
						BodyTextInternal = bodyGroup,
						Subject = subject,
						EmailAddressExternal = obj.Attendees[0].Person.Base.EmailAddresses[0].Address,
						EmailAddressInternal = Settings.Default.ContactEmail,
						NameInternal = "Texas Husky Rescue",
						NameExternal = string.Empty
					};
					message.SendMessage();
				}
				if (obj.EventId.Equals(new Guid(miscHandler.ReadOne("raffle").Value)))
				{
					const string subject = "Texas Husky Rescue Rolls Royce Raffle";
					var bodyAppHtml = @"Thank you for purchasing a raffle ticket through Texas Husky Rescue, Inc.  By doing so, you are helping to support abused, neglected and unwanted huskies in and around Texas.  You will receive a certificate via email in the next 24-48 hours, which will include your official ticket number.  If you do not receive this certificate or if you have any questions, please feel free to contact us directly at raffle@texashuskyrescue.org.";
					bodyAppHtml += "\r\n\r\n";
					bodyAppHtml += @"
Thank you,
Texas Husky Rescue Raffle Committee
1-877-TX-HUSKY (894-8759) (phone/fax)
PO Box 118891, Carrollton, TX 75011
raffle@texashuskyrescue.org
";
					var bodyGroup = obj.Attendees[0].Person.FullName + " bought " + obj.TicketsBought + " tickets and paid $" + obj.AmountPaid + ".";
					bodyGroup += "\r\n\r\n";
					bodyGroup += "Address: " + obj.Attendees[0].Person.Base.Addresses[0].AddressFull;
					bodyGroup += "\r\nPhone: " + obj.Attendees[0].Person.Base.PhoneNumbers[0].Number;
					bodyGroup += "\r\nEmail: " + obj.Attendees[0].Person.Base.EmailAddresses[0].Address;

					var message = new EmailMessage
					{
						BodyTextExternal = bodyAppHtml,
						BodyTextInternal = bodyGroup,
						Subject = subject,
						EmailAddressExternal = obj.Attendees[0].Person.Base.EmailAddresses[0].Address,
						EmailAddressInternal = Settings.Default.RaffleEmail,
						NameInternal = "Texas Husky Rescue",
						NameExternal = string.Empty
					};
					message.SendMessage();
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
		/// Updated existing EventRegistration in the database
		/// </summary>
		/// <param name="obj">EventRegistration object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref EventRegistration obj)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = obj.ToModel();

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					context.Entry(dbObj).State = EntityState.Modified;

					// commit changes to the database
					NumberChanges = context.SaveChanges();

					// convert the database object back to a presentation object with included changes from the database (if any)
					obj = dbObj.ToViewModel();
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
		/// Delete an EventRegistration from the database
		/// </summary>
		/// <param name="id">EventRegistration id the object to be deleted from the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Delete(Guid id)
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
					dbObj.Event = null;
					if (dbObj != null)
					{
						// delete event attendees and associated objects
						var isAnyErrorDeletingAttendees = false;
						var eventAttendeeHandler = new EventAttendeeHandler();
						foreach (var attendee in dbObj.Event_Attendee)
						{
							var resultAttendeeDelete = eventAttendeeHandler.Delete(attendee.ID);
							if (resultAttendeeDelete == ServiceResultEnum.Failure)
							{
								isAnyErrorDeletingAttendees = true;
								Messages.AddRange(eventAttendeeHandler.Messages);
								Messages.Add("Error while deleting attendee with ID: " + attendee.ID);
								break;
							}
						}

						if (!isAnyErrorDeletingAttendees)
						{
							context.Event_Registration.Remove(dbObj);
							// commit changes to the database
							NumberChanges = context.SaveChanges();
						}
						else
						{
							ServiceResult = ServiceResultEnum.Failure;
							Messages.Add("Event Registration not deleted. ID: " + dbObj.ID);
						}
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
		public override EventRegistration ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new EventRegistration();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Event_Registration
						.Include(p => p.Event)
						.Include(p => p.Event_Attendee)
						.Single(x => x.ID == id)
						.ToViewModel();

					var miscHandler = new Enum.MiscHandler();
					var eventType = miscHandler.ReadOne("", obj.EventId.ToString()).ID;

					switch (eventType)
					{
						case "golfevent":
							obj.Event.IsActiveGolfEvent = true;
							break;
						case "roughriderevent":
							obj.Event.IsActiveRoughRidersEvent = true;
							break;
						case "raffle":
							obj.Event.IsActiveRaffle = true;
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

		public EventRegistration ReadOne(Guid id)
		{
			return ReadOne(id, Guid.Empty, Guid.Empty, 0, 0, 0);
		}

		/// <summary>
		/// Retrieve all EventRegistrationes from the database for presentation
		/// </summary>
		/// <returns>list of EventRegistration</returns>
		public override List<EventRegistration> ReadAll()
		{
			var objList = new List<EventRegistration>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Event_Registration
						.Include(p => p.Event)
						.Include(p => p.Event_Attendee)
						.ToList()
						.ToViewModel();
					var miscHandler = new Enum.MiscHandler();
					var miscGolfEvent = miscHandler.ReadOne("golfevent");
					var miscRaffleEvent = miscHandler.ReadOne("roughriderevent");
					var miscRoughRiders = miscHandler.ReadOne("raffle");

					foreach (var item in objList)
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
		public override List<EventRegistration> ReadFiltered(EventRegistration obj)
		{
			var objList = new List<EventRegistration>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Event_Registration, bool>>();
				if (Guid.Empty != obj.Id) conditions.Add(x => x.ID == obj.Id);
				if (Guid.Empty != obj.EventId) conditions.Add(x => x.EventID == obj.EventId);
				if (obj.AmountPaid >= 0) conditions.Add(x => x.AmountPaid >= obj.AmountPaid);
				if (obj.TicketsBought >= 0) conditions.Add(x => x.TicketsBought >= obj.TicketsBought);
				conditions.Add(x => x.HasPaid == obj.HasPaid);

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Event_Registration.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.EventID)
						.Include(p => p.Event)
						.Include(p => p.Event_Attendee)
						.ToList().ToViewModel();

					var miscHandler = new Enum.MiscHandler();
					var miscItems = miscHandler.ReadAll();
					var miscGolfEvent = miscItems.Find(m => m.ID == "golfevent");
					var miscRaffleEvent = miscItems.Find(m => m.ID == "roughriderevent");
					var miscRoughRiders = miscItems.Find(m => m.ID == "raffle");

					foreach (var item in objList)
					{
						if (String.Equals(item.Event.Id.ToString(), miscGolfEvent.Value, StringComparison.CurrentCultureIgnoreCase))
						{
							item.Event.IsActiveGolfEvent = true;
						}
						if (String.Equals(item.Event.Id.ToString(), miscRoughRiders.Value, StringComparison.CurrentCultureIgnoreCase))
						{
							item.Event.IsActiveRoughRidersEvent = true;
						}
						if (String.Equals(item.Event.Id.ToString(), miscRaffleEvent.Value, StringComparison.CurrentCultureIgnoreCase))
						{
							item.Event.IsActiveRaffle = true;
						}
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