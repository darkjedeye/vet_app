using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using Address = HuskyRescue.Core.ViewModel.Entity.Address;

namespace HuskyRescue.Core.Service.Entity
{
	public class AddressHandler : BaseHandler<Address>
	{
		public AddressHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Address to the database
		/// </summary>
		/// <param name="obj">Address object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Address obj)
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

					//trim off extra white space
					dbObj.StateID = dbObj.StateID.Trim();

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					dbObj = context.Entity_Addresses.Add(dbObj);

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
		/// Updated existing Address in the database
		/// </summary>
		/// <param name="obj">Address object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Address obj)
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

					//trim off extra white space
					dbObj.StateID = dbObj.StateID.Trim();

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
		/// Delete an Address from the database
		/// </summary>
		/// <param name="id">Address id the object to be deleted from the database</param>
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
					var dbObj = context.Entity_Addresses.Find(id);

					if (dbObj != null)
					{
						context.Entity_Addresses.Remove(dbObj);

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
		/// Retrieve on Address object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation Address object or null if not found</returns>
		public override Address ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new Address();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Entity_Addresses.Find(id).ToViewModel();
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
		/// Retrieve all Addresses from the database for presentation
		/// </summary>
		/// <returns>list of Address</returns>
		public override List<Address> ReadAll()
		{
			var objList = new List<Address>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Entity_Addresses.ToList().ToViewModel();
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
		/// <returns>List of Address objects filtered and then sorted by name</returns>
		public override List<Address> ReadFiltered(Address obj)
		{
			var objList = new List<Address>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Entity_Addresses, bool>>();
				if (!string.IsNullOrEmpty(obj.City)) { conditions.Add(x => x.City.Contains(obj.City)); }
				if (!string.IsNullOrEmpty(obj.StateID)) { conditions.Add(x => x.StateID.Contains(obj.StateID)); }
				if (!string.IsNullOrEmpty(obj.Street)) { conditions.Add(x => x.Street.Contains(obj.Street)); }
				if (!string.IsNullOrEmpty(obj.Street2)) { conditions.Add(x => x.Street2.Contains(obj.Street2)); }
				if (!string.IsNullOrEmpty(obj.Type)) { conditions.Add(x => x.Type.Contains(obj.Type)); }
				if (!string.IsNullOrEmpty(obj.ZIP)) { conditions.Add(x => x.ZIP.Contains(obj.ZIP)); }
				if (Guid.Empty != obj.EntityID) conditions.Add(x => x.EntityID == obj.EntityID);

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Entity_Addresses.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.Street).ToList().ToViewModel();
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