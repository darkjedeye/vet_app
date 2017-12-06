﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Enum;
using EventDonationPurpose = HuskyRescue.Core.ViewModel.Enum.EventDonationPurpose;

namespace HuskyRescue.Core.Service.Enum
{
	public class EventDonationPurposeHandler : BaseHandler<EventDonationPurpose>
	{
		public EventDonationPurposeHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new EventDonationPurpose to the database
		/// </summary>
		/// <param name="obj">EventDonationPurpose object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref EventDonationPurpose obj)
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
					dbObj = context.Enum_EventDonationPurpose.Add(dbObj);

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
		/// Updated existing EventDonationPurpose in the database
		/// </summary>
		/// <param name="obj">EventDonationPurpose object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref EventDonationPurpose obj)
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

		[Obsolete]
		public override ServiceResultEnum Delete(Guid id)
		{
			throw new Exception("Do not use this method");
		}

		/// <summary>
		/// Delete an EventDonationPurpose from the database
		/// </summary>
		/// <param name="id">EventDonationPurpose id the object to be deleted from the database</param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Delete(int id)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = context.Enum_EventDonationPurpose.Find(id);

					if (dbObj != null)
					{
						context.Enum_EventDonationPurpose.Remove(dbObj);

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
		/// Retrieve on EventDonationPurpose object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation EventDonationPurpose object or null if not found</returns>
		[Obsolete]
		public override EventDonationPurpose ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new Exception("Do not use this method");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public EventDonationPurpose ReadOne(int id)
		{
			var obj = new EventDonationPurpose();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Enum_EventDonationPurpose.Find(id).ToViewModel();
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
		/// Retrieve all EventDonationPurposees from the database for presentation
		/// </summary>
		/// <returns>list of EventDonationPurpose</returns>
		public override List<EventDonationPurpose> ReadAll()
		{
			var objList = new List<EventDonationPurpose>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Enum_EventDonationPurpose.ToList().ToViewModel();
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
		/// <returns>List of EventDonationPurpose objects filtered and then sorted by name</returns>
		public override List<EventDonationPurpose> ReadFiltered(EventDonationPurpose obj)
		{
			var objList = new List<EventDonationPurpose>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Enum_EventDonationPurpose, bool>>();
				if (obj.ID >= 0) { conditions.Add(x => x.ID == obj.ID); }
				if (!string.IsNullOrEmpty(obj.Value)) { conditions.Add(x => x.Value.Contains(obj.Value)); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Enum_EventDonationPurpose.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.ID).ToList().ToViewModel();
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