using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using Business = HuskyRescue.Core.ViewModel.Entity.Business;

namespace HuskyRescue.Core.Service.Entity
{
	public class BusinessHandler : BaseHandler<Business>
	{
		public BusinessHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Business to the database
		/// </summary>
		/// <param name="obj">Business object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Business obj)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				obj.Base.PhoneNumbers.RemoveAll(p => string.IsNullOrEmpty(p.Number));
				obj.Base.EmailAddresses.RemoveAll(p => string.IsNullOrEmpty(p.Address));
				obj.Base.Addresses.RemoveAll(p => string.IsNullOrEmpty(p.Street));
				
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = obj.ToModel();

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					dbObj = context.Entity_Organisation.Add(dbObj);

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
		/// Updated existing Business in the database
		/// </summary>
		/// <param name="obj">Business object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Business obj)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				obj.Base.PhoneNumbers.RemoveAll(p => string.IsNullOrEmpty(p.Number));
				obj.Base.EmailAddresses.RemoveAll(p => string.IsNullOrEmpty(p.Address));
				obj.Base.Addresses.RemoveAll(p => string.IsNullOrEmpty(p.Street));
				
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = obj.ToModel();

					var baseHandler = new BaseHandler();
					// Add new related base objects
					baseHandler.Create(obj.Base, true);

					// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
					context.Entry(dbObj).State = EntityState.Modified;

					baseHandler.Update(obj.Base);

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
		/// Delete an Business from the database
		/// </summary>
		/// <param name="id">Business id the object to be deleted from the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Delete(Guid id)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			var result = ServiceResultEnum.Failure;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = context.Entity_Organisation.Find(id);

					if (dbObj != null)
					{
						var baseHandler = new BaseHandler();
						result = baseHandler.Delete(id);
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

			return result;
		}

		/// <summary>
		/// Retrieve on Business object for presentation
		/// </summary>
		/// <param name="id">id to look up the Business in the database</param>
		/// <param name="personId"></param>
		/// <param name="id3"></param>
		/// <param name="id4"></param>
		/// <param name="id5"></param>
		/// <param name="id6"></param>
		/// <returns>presentation Business object or null if not found</returns>
		public override Business ReadOne(Guid id, Guid personId, Guid id3, int id4, int id5, int id6)
		{
			var obj = new Business();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Entity_Organisation
						.Include(p => p.Entity_Base)
						.Include(p => p.Entity_Base.Entity_Addresses)
						.Include(p => p.Entity_Base.Entity_EmailAddress)
						.Include(p => p.Entity_Base.Entity_PhoneNumber)
						.Single(p => p.ID == id)
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

		public Business ReadOne(Guid id)
		{
			return ReadOne(id, Guid.Empty, Guid.Empty, 0, 0, 0);
		}

		/// <summary>
		/// Retrieve all Businesses from the database for presentation
		/// </summary>
		/// <returns>list of Business</returns>
		public override List<Business> ReadAll()
		{
			var objList = new List<Business>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Entity_Organisation
						.Include(p => p.Entity_Base)
						.Include(p => p.Entity_Base.Entity_Addresses)
						.Include(p => p.Entity_Base.Entity_EmailAddress)
						.Include(p => p.Entity_Base.Entity_PhoneNumber)
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
		/// <returns>List of Business objects filtered and then sorted by name</returns>
		public override List<Business> ReadFiltered(Business obj)
		{
			var objList = new List<Business>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Entity_Organisation, bool>>();
				if (obj.ID != Guid.Empty) { conditions.Add(e => e.ID == obj.ID); }
				if (!string.IsNullOrEmpty(obj.BusinessName)) { conditions.Add(e => e.BusinessName.Contains(obj.BusinessName)); }
				if (!string.IsNullOrEmpty(obj.ContactName)) { conditions.Add(e => e.ContactName.Contains(obj.ContactName)); }
				if (!string.IsNullOrEmpty(obj.Description)) { conditions.Add(e => e.Description.Contains(obj.Description)); }
				if (!string.IsNullOrEmpty(obj.Base.Comments)) { conditions.Add(e => e.Entity_Base.Comments.Contains(obj.Base.Comments)); }
				if (!string.IsNullOrEmpty(obj.TypeBusiness)) { conditions.Add(e => e.Type.Contains(obj.TypeBusiness)); }
				conditions.Add(e => e.Entity_Base.IsActive.Equals(obj.Base.IsActive));
				conditions.Add(e => e.Entity_Base.IsDeleted.Equals(obj.Base.IsDeleted));

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Entity_Organisation.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.BusinessName)
						.Include(p => p.Entity_Base)
						.Include(p => p.Entity_Base.Entity_Addresses)
						.Include(p => p.Entity_Base.Entity_EmailAddress)
						.Include(p => p.Entity_Base.Entity_PhoneNumber)
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
	}
}