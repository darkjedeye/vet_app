using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Store;
using Product = HuskyRescue.Core.ViewModel.Store.Product;

namespace HuskyRescue.Core.Service.Store
{
	public class ProductHandler : BaseHandler<Product>
	{
		public ProductHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Product to the database
		/// </summary>
		/// <param name="obj">Product object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Product obj)
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
					dbObj = context.Entity_StoreProduct.Add(dbObj);

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
		/// Updated existing Product in the database
		/// </summary>
		/// <param name="obj">Product object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Product obj)
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
		/// Delete an Product from the database
		/// </summary>
		/// <param name="id">Product id the object to be deleted from the database</param>
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
					var dbObj = context.Entity_StoreProduct.Find(id);

					if (dbObj != null)
					{
						// DO NOT DELETE PRODUCTS - UPDATE THEM TO SHOW "DELETED" status
						dbObj.DeletedOn = DateTime.Now;
						// TODO Set deleted by user
						dbObj.IsActive = false;

						context.Entry(dbObj).State = EntityState.Modified;

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
		/// Retrieve on Product object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation Product object or null if not found</returns>
		public override Product ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new Product();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Entity_StoreProduct
						.Include(i => i.Entity_StoreCategory)
						.Include(i => i.Entity_StoreOptionType)
						.Include(i => i.Entity_StoreProductVariant)
						.Include(i => i.Entity_StoreProductImage)
						.Include(i => i.Entity_StoreProperty)
						.Single(item => item.Id.Equals(id))
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
		public override List<Product> ReadAll()
		{
			var objList = new List<Product>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Entity_StoreProduct
						.Include(i => i.Entity_StoreCategory)
						.Include(i => i.Entity_StoreOptionType)
						.Include(i => i.Entity_StoreProductVariant)
						.Include(i => i.Entity_StoreProductImage)
						.Include(i => i.Entity_StoreProperty)
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
		/// <returns>List of Product objects filtered and then sorted by name</returns>
		public override List<Product> ReadFiltered(Product obj)
		{
			var objList = new List<Product>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Entity_StoreProduct, bool>>();
				if (obj.Id != Guid.Empty) { conditions.Add(x => x.Id.Equals(obj.Id)); }
				if (obj.CategoryId != Guid.Empty) { conditions.Add(x => x.CategoryId.Equals(obj.CategoryId)); }
				conditions.Add(x => x.IsActive == obj.IsActive);
				if (!string.IsNullOrEmpty(obj.CreatedByUser)) { conditions.Add(x => x.CreatedByUser.Equals(obj.CreatedByUser)); }
				if (!string.IsNullOrEmpty(obj.DeletedByUser)) { conditions.Add(x => x.DeletedByUser.Equals(obj.DeletedByUser)); }
				if (!string.IsNullOrEmpty(obj.UpdatedByUser)) { conditions.Add(x => x.UpdatedByUser.Equals(obj.UpdatedByUser)); }
				if (obj.CreatedOn != DateTime.MinValue) { conditions.Add(x => x.CreatedOn >= obj.CreatedOn); }
				if (obj.UpdatedOn != DateTime.MinValue) { conditions.Add(x => x.UpdatedOn >= obj.UpdatedOn); }
				if (obj.DeletedOn != DateTime.MinValue) { conditions.Add(x => x.DeletedOn >= obj.DeletedOn); }
				if (!string.IsNullOrEmpty(obj.Description)) { conditions.Add(x => x.Description.Contains(obj.Description)); }
				if (!string.IsNullOrEmpty(obj.Name)) { conditions.Add(x => x.Name.Contains(obj.Name)); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Entity_StoreProduct.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.CreatedOn)
						.Include(i => i.Entity_StoreCategory)
						.Include(i => i.Entity_StoreOptionType)
						.Include(i => i.Entity_StoreProductVariant)
						.Include(i => i.Entity_StoreProductImage)
						.Include(i => i.Entity_StoreProperty)
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