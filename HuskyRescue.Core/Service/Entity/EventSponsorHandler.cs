using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using EventSponsor = HuskyRescue.Core.ViewModel.Entity.EventSponsor;

namespace HuskyRescue.Core.Service.Entity
{
	public class EventSponsorHandler : BaseHandler<EventSponsor>
	{
		public EventSponsorHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new EventSponsor to the database
		/// </summary>
		/// <param name="obj">EventSponsor object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref EventSponsor obj)
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

					if (dbObj.SponsorshipLevel != 0)
					{
						if (dbObj.SponsorshipLevel != null)
							dbObj.Event_SponsorshipLevel.Add(new Event_SponsorshipLevel { SponsorshipLevelType = (int)dbObj.SponsorshipLevel });
					}

					if (dbObj.OrganisationID.Equals(Guid.Empty))
						dbObj.OrganisationID = null;
					if (dbObj.PersonID.Equals(Guid.Empty))
						dbObj.PersonID = null;

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					dbObj = context.Event_Sponsor.Add(dbObj);

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
		/// Updated existing EventSponsor in the database
		/// </summary>
		/// <param name="obj">EventSponsor object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref EventSponsor obj)
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

					var sponsorToDetach = context.Event_Sponsor.Single(s => s.ID.Equals(dbObj.ID));
					if (sponsorToDetach == null)
						return ServiceResultEnum.Failure;

					if (dbObj.OrganisationID.Equals(Guid.Empty))
						dbObj.OrganisationID = null;
					if (dbObj.PersonID.Equals(Guid.Empty))
						dbObj.PersonID = null;

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
		/// Delete an EventSponsor from the database
		/// </summary>
		/// <param name="id">EventSponsor id the object to be deleted from the database</param>
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
					var dbObj = context.Event_Sponsor.Find(id);

					if (dbObj != null)
					{
						var levelDb = context.Event_SponsorshipLevel.Single(l => l.ID == dbObj.SponsorshipLevel);

						if (levelDb != null)
							context.Event_SponsorshipLevel.Remove(levelDb);

						context.Event_Sponsor.Remove(dbObj);

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
		/// Retrieve on EventSponsor object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation EventSponsor object or null if not found</returns>
		public override EventSponsor ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new EventSponsor();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Event_Sponsor
						.Single(x => x.ID == id).ToViewModel();
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
		/// Retrieve all EventSponsores from the database for presentation
		/// </summary>
		/// <returns>list of EventSponsor</returns>
		public override List<EventSponsor> ReadAll()
		{
			var objList = new List<EventSponsor>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Event_Sponsor.ToList().ToViewModel();
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
		/// <returns>List of EventSponsor objects filtered and then sorted by name</returns>
		public override List<EventSponsor> ReadFiltered(EventSponsor obj)
		{
			var objList = new List<EventSponsor>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Event_Sponsor, bool>>();
				if (!string.IsNullOrEmpty(obj.Comments)) { conditions.Add(x => x.Comments.Contains(obj.Comments)); }
				if (obj.DonationAmount >= 0) { conditions.Add(x => x.DonationAmount >= obj.DonationAmount); }
				conditions.Add(x => x.IsDonating == obj.IsDonating);
				conditions.Add(x => x.IsDonationRecieved == obj.IsDonationReceived);
				conditions.Add(x => x.IsSingageComplete == obj.IsSingageComplete);
				conditions.Add(x => x.IsSponsoring == obj.IsSponsoring);
				if (Guid.Empty != obj.Id) conditions.Add(x => x.ID == obj.Id);
				if (Guid.Empty != obj.EventId) conditions.Add(x => x.EventID == obj.EventId);
				if (Guid.Empty != obj.PersonId) conditions.Add(x => x.PersonID == obj.PersonId);
				if (Guid.Empty != obj.BusinessId) conditions.Add(x => x.OrganisationID == obj.BusinessId);

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Event_Sponsor.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.DateAdded).ToList().ToViewModel();
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