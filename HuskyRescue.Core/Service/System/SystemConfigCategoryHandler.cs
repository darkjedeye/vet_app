using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.System;
using SystemConfigCategory = HuskyRescue.Core.ViewModel.System.SystemConfigCategory;

namespace HuskyRescue.Core.Service.System
{
	public class SystemConfigCategoryHandler : BaseHandler<SystemConfigCategory>
	{
		public SystemConfigCategoryHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new SystemConfigCategory to the database
		/// </summary>
		/// <param name="obj">SystemConfigCategory object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref SystemConfigCategory obj)
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
					dbObj = context.System_ConfigCategory.Add(dbObj);

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
		/// Updated existing SystemConfigCategory in the database
		/// </summary>
		/// <param name="obj">SystemConfigCategory object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref SystemConfigCategory obj)
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
		/// Delete an SystemConfigCategory from the database
		/// </summary>
		/// <param name="id">SystemConfigCategory id the object to be deleted from the database</param>
		/// <returns>success or failure</returns>
		[Obsolete]
		public override ServiceResultEnum Delete(Guid id)
		{
			throw new Exception("method must not be used");
		}

		/// <summary>
		/// Delete an SystemConfigCategory from the database
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="settingName"></param>
		/// <returns>success or failure</returns>
		public ServiceResultEnum Delete(string categoryId)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = context.System_ConfigCategory.Find(categoryId);

					if (dbObj != null)
					{
						context.System_ConfigCategory.Remove(dbObj);

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
		/// Retrieve on SystemConfigCategory object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation SystemConfigCategory object or null if not found</returns>
		[Obsolete]
		public override SystemConfigCategory ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new Exception("method must not be used");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="settingName"></param>
		/// <returns></returns>
		public SystemConfigCategory ReadOne(string categoryId)
		{
			var obj = new SystemConfigCategory();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.System_ConfigCategory
						.Single(i => i.Name.Equals(categoryId))
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
		/// Retrieve all Loges from the database for presentation
		/// </summary>
		/// <returns>list of Log</returns>
		public override List<SystemConfigCategory> ReadAll()
		{
			var objList = new List<SystemConfigCategory>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.System_ConfigCategory
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
		/// <returns>List of SystemConfigCategory objects filtered and then sorted by name</returns>
		public override List<SystemConfigCategory> ReadFiltered(SystemConfigCategory obj)
		{
			var objList = new List<SystemConfigCategory>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.System_ConfigCategory, bool>>();
				if (!string.IsNullOrEmpty(obj.Name)) { conditions.Add(x => x.Name.Contains(obj.Name)); }
				if (!string.IsNullOrEmpty(obj.Description)) { conditions.Add(x => x.Description.Contains(obj.Description)); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.System_ConfigCategory.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.Name)
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