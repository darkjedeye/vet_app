using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Enum;
using PhoneNumberType = HuskyRescue.Core.ViewModel.Enum.PhoneNumberType;

namespace HuskyRescue.Core.Service.Enum
{
	public class PhoneNumberTypeHandler : BaseHandler<PhoneNumberType>
	{
		public PhoneNumberTypeHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new PhoneNumberType to the database
		/// </summary>
		/// <param name="obj">PhoneNumberType object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref PhoneNumberType obj)
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
					dbObj = context.Enum_PhoneType.Add(dbObj);

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
		/// Updated existing PhoneNumberType in the database
		/// </summary>
		/// <param name="obj">PhoneNumberType object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref PhoneNumberType obj)
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
		/// Delete an PhoneNumberType from the database
		/// </summary>
		/// <param name="id">PhoneNumberType id the object to be deleted from the database</param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Delete(string id)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = context.Enum_PhoneType.Find(id);

					if (dbObj != null)
					{
						context.Enum_PhoneType.Remove(dbObj);

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
		/// Retrieve on PhoneNumberType object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation PhoneNumberType object or null if not found</returns>
		[Obsolete]
		public override PhoneNumberType ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new Exception("Do not use this method");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public PhoneNumberType ReadOne(string id)
		{
			var obj = new PhoneNumberType();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Enum_PhoneType.Find(id).ToViewModel();
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
		/// Retrieve all PhoneNumberTypees from the database for presentation
		/// </summary>
		/// <returns>list of PhoneNumberType</returns>
		public override List<PhoneNumberType> ReadAll()
		{
			var objList = new List<PhoneNumberType>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Enum_PhoneType.ToList().ToViewModel();
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
		/// <returns>List of PhoneNumberType objects filtered and then sorted by name</returns>
		public override List<PhoneNumberType> ReadFiltered(PhoneNumberType obj)
		{
			var objList = new List<PhoneNumberType>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Enum_PhoneType, bool>>();
				if (!string.IsNullOrEmpty(obj.ID)) { conditions.Add(x => x.ID == obj.ID); }
				if (!string.IsNullOrEmpty(obj.Value)) { conditions.Add(x => x.Value.Contains(obj.Value)); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Enum_PhoneType.AsQueryable();
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