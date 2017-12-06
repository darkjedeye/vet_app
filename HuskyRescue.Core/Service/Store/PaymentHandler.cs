using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Store;
using Payment = HuskyRescue.Core.ViewModel.Store.Payment;

namespace HuskyRescue.Core.Service.Store
{
	public class PaymentHandler : BaseHandler<Payment>
	{
		public PaymentHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Payment to the database
		/// </summary>
		/// <param name="obj">Payment object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Payment obj)
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
					dbObj = context.Entity_StorePayment.Add(dbObj);

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
		/// Updated existing Payment in the database
		/// </summary>
		/// <param name="obj">Payment object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Payment obj)
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
		/// Delete an Payment from the database
		/// </summary>
		/// <param name="id">Payment id the object to be deleted from the database</param>
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
					var dbObj = context.Entity_StorePayment.Find(id);

					if (dbObj != null)
					{
						context.Entity_StorePayment.Remove(dbObj);

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
		/// Retrieve on Payment object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="id2">not used</param>
		/// <param name="id3">not used</param>
		/// <param name="id4">not used</param>
		/// <param name="id5">not used</param>
		/// <param name="id6">not used</param>
		/// <returns>presentation Payment object or null if not found</returns>
		public override Payment ReadOne(Guid id, Guid id2, Guid id3, int id4, int id5, int id6)
		{
			var obj = new Payment();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Entity_StorePayment
						.Include(i => i.Entity_StoreOrder)
						.Include(i => i.Entity_StorePaymentMethod)
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
		public override List<Payment> ReadAll()
		{
			var objList = new List<Payment>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Entity_StorePayment
						.Include(i => i.Entity_StoreOrder)
						.Include(i => i.Entity_StorePaymentMethod)
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
		/// <returns>List of Payment objects filtered and then sorted by name</returns>
		public override List<Payment> ReadFiltered(Payment obj)
		{
			var objList = new List<Payment>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Entity_StorePayment, bool>>();
				if (obj.Id != Guid.Empty) { conditions.Add(x => x.Id.Equals(obj.Id)); }
				if (obj.OrderId != Guid.Empty) { conditions.Add(x => x.OrderId.Equals(obj.OrderId)); }
				if (obj.PaymentMethodId != Guid.Empty) { conditions.Add(x => x.PaymentMethodId.Equals(obj.PaymentMethodId)); }
				if (!string.IsNullOrEmpty(obj.ResponseCode)) { conditions.Add(x => x.ResponseCode.Equals(obj.ResponseCode)); }
				if (!string.IsNullOrEmpty(obj.Status)) { conditions.Add(x => x.Status.Equals(obj.Status)); }
				if (!string.IsNullOrEmpty(obj.GatewayTransactionId)) { conditions.Add(x => x.GatewayTransactionId.Equals(obj.GatewayTransactionId)); }
				if (!string.IsNullOrEmpty(obj.ResponseText)) { conditions.Add(x => x.ResponseText.Contains(obj.ResponseText)); }
				if (obj.CreatedOn != DateTime.MinValue) { conditions.Add(x => x.CreatedOn >= obj.CreatedOn); }
				if (obj.UpdatedOn != DateTime.MinValue) { conditions.Add(x => x.UpdatedOn >= obj.UpdatedOn); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Entity_StorePayment.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.OrderId)
						.Include(i => i.Entity_StoreOrder)
						.Include(i => i.Entity_StorePaymentMethod)
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