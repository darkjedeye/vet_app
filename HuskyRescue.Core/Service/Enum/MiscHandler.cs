using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using Fabrik.Common;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Enum;
using Event = HuskyRescue.Core.ViewModel.Entity.Event;
using Misc = HuskyRescue.Core.ViewModel.Enum.Misc;

namespace HuskyRescue.Core.Service.Enum
{
	public class MiscHandler : BaseHandler<Misc>
	{
		public MiscHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Misc to the database
		/// </summary>
		/// <param name="obj">Misc object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Misc obj)
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
					dbObj = context.Enum_Misc.Add(dbObj);

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
		/// Updated existing Misc in the database
		/// </summary>
		/// <param name="obj">Misc object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Misc obj)
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
		/// Delete an Misc from the database
		/// </summary>
		/// <param name="id">Misc id the object to be deleted from the database</param>
		/// <param name="value"></param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Delete(string id, string value)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = context.Enum_Misc.Find(id);

					if (dbObj != null)
					{
						context.Enum_Misc.Remove(dbObj);

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
		/// Retrieve on Misc object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation Misc object or null if not found</returns>
		[Obsolete]
		public override Misc ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new Exception("Do not use this method");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public Misc ReadOne(string id, string value = "")
		{
			var obj = new Misc();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					if (!string.IsNullOrEmpty(value))
						value = value.ToLower();

					// convert to database object
					if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(value))
						obj = context.Enum_Misc.Single(i => i.ID == id && i.Value == value).ToViewModel();
					if (!string.IsNullOrEmpty(id) && string.IsNullOrEmpty(value))
						obj = context.Enum_Misc.Single(i => i.ID == id).ToViewModel();
					if (string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(value))
						obj = context.Enum_Misc.Single(i => i.Value == value).ToViewModel();
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
		/// Retrieve all Misces from the database for presentation
		/// </summary>
		/// <returns>list of Misc</returns>
		public override List<Misc> ReadAll()
		{
			var objList = new List<Misc>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Enum_Misc.ToList().ToViewModel();
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
		/// <returns>List of Misc objects filtered and then sorted by name</returns>
		public override List<Misc> ReadFiltered(Misc obj)
		{
			var objList = new List<Misc>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Enum_Misc, bool>>();
				if (!string.IsNullOrEmpty(obj.ID)) { conditions.Add(x => x.ID == obj.ID); }
				if (!string.IsNullOrEmpty(obj.Value)) { conditions.Add(x => x.Value.Contains(obj.Value)); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Enum_Misc.AsQueryable();
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

		/// <summary>
		/// Update preset event handlers for the active event's ID
		/// </summary>
		/// <param name="obj">Event to update</param>
		internal static void UpdateActiveEvent(Event obj)
		{
			var miscHandler = new MiscHandler();
			var eventType = string.Empty;
			if (obj.IsActiveGolfEvent)
				eventType = "golfevent";
			if (obj.IsActiveRoughRidersEvent)
				eventType = "roughriderevent";
			if (obj.IsActiveRaffle)
				eventType = "raffle";
			if (!eventType.IsNotNullOrEmpty()) return;

			var miscVm = new Misc { ID = eventType, Value = obj.Id.ToString() };
			miscHandler.Update(ref miscVm);
		}

	}
}