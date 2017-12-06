using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Core.ViewModel.Entity;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using HuskyRescue.Core.Service.Enum;
using Event = HuskyRescue.Core.ViewModel.Entity.Event;
using EventRegistration = HuskyRescue.Core.ViewModel.Entity.EventRegistration;

namespace HuskyRescue.Core.Service.Entity
{
	public class EventHandler : NewBaseHandler, IBaseDabaseHandler<Event>
	{
		public EventHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Event to the database
		/// </summary>
		/// <param name="obj">Event object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Create(ref Event obj)
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
					dbObj = context.Events.Add(dbObj);

					// commit changes to the database
					NumberChanges = context.SaveChanges();

					MiscHandler.UpdateActiveEvent(obj);

					// convert the database object back to a presentation object with included changes from the database (if any)
					obj = dbObj.ToViewModel();
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
		/// Updated existing Event in the database
		/// </summary>
		/// <param name="obj">Event object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Update(ref Event obj)
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

					MiscHandler.UpdateActiveEvent(obj);

					// convert the database object back to a presentation object with included changes from the database (if any)
					obj = dbObj.ToViewModel();
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
		/// Delete an Event from the database
		/// </summary>
		/// <param name="id">Event id the object to be deleted from the database</param>
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
					var dbObj = context.Events.Find(id);

					if (dbObj != null)
					{
						// check if any event registrations exist
						var eventRegHandler = new EventRegistrationHandler();
						var eventRegs = eventRegHandler.ReadFiltered(new EventRegistration
													 {
														 EventId = id
													 });

						var isAnyErrorDeletingRegs = false;
						if (eventRegs != null)
						{
							foreach (var eventReg in eventRegs)
							{
								var resultDeleteEventReg = eventRegHandler.Delete(eventReg.Id);
								if (resultDeleteEventReg == ServiceResultEnum.Failure)
								{
									Messages.AddRange(eventRegHandler.Messages);
									isAnyErrorDeletingRegs = true;
									break;
								}
							}
						}

						if (!isAnyErrorDeletingRegs)
						{
							context.Events.Remove(dbObj);
							// commit changes to the database
							NumberChanges = context.SaveChanges();
						}
						else
						{
							ServiceResult = ServiceResultEnum.Failure;
							Messages.Add("Event not deleted. ID: " + dbObj.ID);
						}
					}
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
		/// Retrieve on Event object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation Event object or null if not found</returns>
		public Event ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new Event();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Events
						.Include(p => p.Entity_DonationItems)
						.Include(p => p.Entity_Organisation)
						.Include(p => p.Event_Registration)
						.Include(p => p.Event_Sponsor)
						.Single(item => item.ID.Equals(id))
						.ToViewModel();
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

		public Event ReadOne(Guid id)
		{
			return ReadOne(id, Guid.Empty, Guid.Empty, 0, 0, 0);
		}

		/// <summary>
		/// Retrieve all Loges from the database for presentation
		/// </summary>
		/// <returns>list of Log</returns>
		public List<Event> ReadAll()
		{
			var objList = new List<Event>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Events
						.Include(p => p.Entity_Organisation)
						.ToList().ToViewModel();
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
		/// <returns>List of Event objects filtered and then sorted by name</returns>
		public List<Event> ReadFiltered(Event obj)
		{
			var objList = new List<Event>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Event, bool>>();
				if (!string.IsNullOrEmpty(obj.Type)) { conditions.Add(x => x.Type.Equals(obj.Type)); }
				if (!string.IsNullOrEmpty(obj.Name)) { conditions.Add(x => x.Name.Contains(obj.Name)); }
				if (obj.Id != Guid.Empty) { conditions.Add(x => x.ID.Equals(obj.Id)); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Events.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.Name)
						.Include(p => p.Entity_Organisation)
						.ToList().ToViewModel();
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