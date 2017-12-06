using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using EventAttendee = HuskyRescue.Core.ViewModel.Entity.EventAttendee;

namespace HuskyRescue.Core.Service.Entity
{
	public class EventAttendeeHandler : BaseHandler<EventAttendee>
	{
		public EventAttendeeHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new EventAttendee to the database
		/// </summary>
		/// <param name="obj">EventAttendee object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref EventAttendee obj)
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
					dbObj = context.Event_Attendee.Add(dbObj);

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
		/// Updated existing EventAttendee in the database
		/// </summary>
		/// <param name="obj">EventAttendee object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref EventAttendee obj)
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
		/// Delete an EventAttendee from the database
		/// </summary>
		/// <param name="id">EventAttendee id the object to be deleted from the database</param>
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
					var dbObj = context.Event_Attendee.Find(id);

					if (dbObj != null)
					{
						// remove associated person first
						if (dbObj.PersonID != null)
						{
							var personHandler = new PersonHandler();
							personHandler.Delete(dbObj.PersonID.Value);
						}

						context.Event_Attendee.Remove(dbObj);

						// commit changes to the database
						NumberChanges = context.SaveChanges();
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(ex.Message);
				Messages.Add("Error deleting person - " + ex.Message);
			}
			catch (ValidationException ex)
			{
				Trace.WriteLine(ex.Message);
				Messages.Add("Error deleting person - " + ex.Message);
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Messages.Add("Error deleting person - " + ex.Message);
			}

			return NumberChanges > 0 ? ServiceResultEnum.Success : ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Retrieve on EventAttendee object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation EventAttendee object or null if not found</returns>
		public override EventAttendee ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new EventAttendee();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Event_Attendee
						.Include(p => p.Entity_Person)
						.Include(p => p.Enum_EventAttendeeType)
						.Include(p => p.Event_Registration)
						.Single(x => x.ID == id)
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

		/// <summary>
		/// Retrieve all EventAttendeees from the database for presentation
		/// </summary>
		/// <returns>list of EventAttendee</returns>
		public override List<EventAttendee> ReadAll()
		{
			var objList = new List<EventAttendee>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Event_Attendee
						.Include(p => p.Entity_Person)
						.Include(p => p.Enum_EventAttendeeType)
						.Include(p => p.Event_Registration)
						.ToList()
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

			return objList;
		}

		/// <summary>
		/// Retrieve list of presentation objects filtered by provided object's properties
		/// </summary>
		/// <param name="obj">Presentation object with properties used to filter database query</param>
		/// <returns>List of EventAttendee objects filtered and then sorted by name</returns>
		public override List<EventAttendee> ReadFiltered(EventAttendee obj)
		{
			var objList = new List<EventAttendee>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Event_Attendee, bool>>();
				if (Guid.Empty != obj.Id) conditions.Add(x => x.ID == obj.Id);
				if (Guid.Empty != obj.PersonId) conditions.Add(x => x.PersonID == obj.PersonId);

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Event_Attendee.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.EventRegistrationID)
						.Include(p => p.Entity_Person)
						.Include(p => p.Enum_EventAttendeeType)
						.Include(p => p.Event_Registration)
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