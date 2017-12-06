using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Store;
using OrderDetail = HuskyRescue.Core.ViewModel.Store.OrderDetail;

namespace HuskyRescue.Core.Service.Store
{
	public class OrderDetailHandler : BaseHandler<OrderDetail>
	{
		public OrderDetailHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new OrderDetail to the database
		/// </summary>
		/// <param name="obj">OrderDetail object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref OrderDetail obj)
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
					dbObj = context.Entity_StoreOrderDetail.Add(dbObj);

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
		/// Updated existing OrderDetail in the database
		/// </summary>
		/// <param name="obj">OrderDetail object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref OrderDetail obj)
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
		/// Delete an OrderDetail from the database
		/// </summary>
		/// <param name="id">OrderDetail id the object to be deleted from the database</param>
		/// <returns>success or failure</returns>
		[Obsolete]
		public override ServiceResultEnum Delete(Guid id)
		{
			throw new Exception("method must not be used");
		}

		public ServiceResultEnum Delete(int id, Guid orderId)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to database object
					var dbObj = context.Entity_StoreOrderDetail.Find(id, orderId);

					if (dbObj != null)
					{
						context.Entity_StoreOrderDetail.Remove(dbObj);

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
		/// Retrieve on OrderDetail object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation OrderDetail object or null if not found</returns>
		[Obsolete]
		public override OrderDetail ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			throw new Exception("method must not be used");
		}

		public OrderDetail ReadOne(int id, Guid orderId)
		{
			var obj = new OrderDetail();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Entity_StoreOrderDetail
						.Include(i => i.Entity_StoreProductVariant)
						.Single(i => i.Id == id && i.OrderId == orderId)
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
		public override List<OrderDetail> ReadAll()
		{
			var objList = new List<OrderDetail>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Entity_StoreOrderDetail
						.Include(i => i.Entity_StoreProductVariant)
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
		/// <returns>List of OrderDetail objects filtered and then sorted by name</returns>
		public override List<OrderDetail> ReadFiltered(OrderDetail obj)
		{
			var objList = new List<OrderDetail>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Entity_StoreOrderDetail, bool>>();
				if (obj.ProductVariantId != Guid.Empty) { conditions.Add(x => x.ProductVariantId.Equals(obj.ProductVariantId)); }
				if (obj.OrderId != Guid.Empty) { conditions.Add(x => x.OrderId.Equals(obj.OrderId)); }
				if (obj.Id > 0) { conditions.Add(x => x.Id.Equals(obj.Id)); }
				if (obj.Quantity > 0) { conditions.Add(x => x.Quantity >= obj.Quantity); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Entity_StoreOrderDetail.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.Id)
						.Include(i => i.Entity_StoreProductVariant)
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