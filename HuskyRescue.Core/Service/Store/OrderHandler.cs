using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Store;
using Order = HuskyRescue.Core.ViewModel.Store.Order;

namespace HuskyRescue.Core.Service.Store
{
	public class OrderHandler : BaseHandler<Order>
	{
		public OrderHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Order to the database
		/// </summary>
		/// <param name="obj">Order object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Order obj)
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
					dbObj = context.Entity_StoreOrder.Add(dbObj);

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
		/// Updated existing Order in the database
		/// </summary>
		/// <param name="obj">Order object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Order obj)
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
		/// Delete an Order from the database
		/// </summary>
		/// <param name="id">Order id the object to be deleted from the database</param>
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
					var dbObj = context.Entity_StoreOrder.Find(id);

					if (dbObj != null)
					{
						// delete subitems first
						if (dbObj.Entity_StoreOrderDetail != null)
						{
							dbObj.Entity_StoreOrderDetail.ToList().ForEach(i => context.Entity_StoreOrderDetail.Remove(i));
						}

						context.Entity_StoreOrder.Remove(dbObj);

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
		/// Retrieve on Order object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation Order object or null if not found</returns>
		public override Order ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new Order();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Entity_StoreOrder
						.Include(i => i.Entity_StoreOrderDetail)
						.Include(i => i.Entity_Addresses)
						.Include(i => i.Entity_Addresses1)
						.Include(i => i.Entity_Base)
						.Include(i => i.Entity_StorePayment)
						.Include(i => i.Entity_StoreShipment)
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
		public override List<Order> ReadAll()
		{
			var objList = new List<Order>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Entity_StoreOrder
						.Include(i => i.Entity_StoreOrderDetail)
						.Include(i => i.Entity_Addresses)
						.Include(i => i.Entity_Addresses1)
						.Include(i => i.Entity_Base)
						.Include(i => i.Entity_StorePayment)
						.Include(i => i.Entity_StoreShipment)
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
		/// <returns>List of Order objects filtered and then sorted by name</returns>
		public override List<Order> ReadFiltered(Order obj)
		{
			var objList = new List<Order>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Entity_StoreOrder, bool>>();
				if (!string.IsNullOrEmpty(obj.UserName)) { conditions.Add(x => x.UserName.Equals(obj.UserName)); }
				if (obj.Id != Guid.Empty) { conditions.Add(x => x.Id.Equals(obj.Id)); }
				if (obj.CreatedOn != DateTime.MinValue) { conditions.Add(x => x.CreatedOn >= obj.CreatedOn); }
				if (obj.UpdatedOn != DateTime.MinValue) { conditions.Add(x => x.UpdatedOn >= obj.UpdatedOn); }

				if (!string.IsNullOrEmpty(obj.ShippingStatus)) { conditions.Add(c => c.ShippingStatus.Contains(obj.ShippingStatus)); }
				if (!string.IsNullOrEmpty(obj.SpecialInstructions)) { conditions.Add(c => c.SpecialInstructions.Contains(obj.SpecialInstructions)); }
				if (!string.IsNullOrEmpty(obj.Status)) { conditions.Add(c => c.Status.Contains(obj.Status)); }
				if (!string.IsNullOrEmpty(obj.UserName)) { conditions.Add(c => c.UserName.Equals(obj.UserName)); }
				if (obj.TotalDue > 0) { conditions.Add(c => c.TotalDue >= obj.TotalDue); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Entity_StoreOrder.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.CreatedOn)
						.Include(i => i.Entity_StoreOrderDetail)
						.Include(i => i.Entity_Addresses)
						.Include(i => i.Entity_Addresses1)
						.Include(i => i.Entity_Base)
						.Include(i => i.Entity_StorePayment)
						.Include(i => i.Entity_StoreShipment)
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