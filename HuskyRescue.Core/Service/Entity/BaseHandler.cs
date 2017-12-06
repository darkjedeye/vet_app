using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using Base = HuskyRescue.Core.ViewModel.Entity.Base;

namespace HuskyRescue.Core.Service.Entity
{
	public class BaseHandler : BaseHandler<Base>
	{
		public BaseHandler()
		{
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Base to the database
		/// </summary>
		/// <param name="obj">Base object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Base obj)
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
					dbObj = context.Entity_Base.Add(dbObj);

					for (var index = 0; index < obj.Addresses.Count; index++)
					{
						var address = obj.Addresses[index];
						if (!address.ID.Equals(Guid.Empty)) continue;
						if (!obj.ID.Equals(Guid.Empty) && address.ID.Equals(Guid.Empty))
						{
							address.EntityID = obj.ID;
						}
						var addressHandler = new AddressHandler();
						addressHandler.Create(ref address);
					}
					for (var index = 0; index < obj.EmailAddresses.Count; index++)
					{
						var address = obj.EmailAddresses[index];
						if (address.ID != 0) continue;
						if (!obj.ID.Equals(Guid.Empty) && address.ID == 0)
						{
							address.EntityID = obj.ID;
						}
						var addressHandler = new EmailAddressHandler();
						addressHandler.Create(ref address);
					}
					for (var index = 0; index < obj.PhoneNumbers.Count; index++)
					{
						var phone = obj.PhoneNumbers[index];
						if (phone.ID != 0) continue;
						if (!obj.ID.Equals(Guid.Empty) && phone.ID == 0)
						{
							phone.EntityID = obj.ID;
						}
						var phoneHandler = new PhoneNumberHandler();
						phoneHandler.Create(ref phone);
					}

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

		public ServiceResultEnum Create(Base obj, bool onlyCreateRelatedObjects)
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

					if (!onlyCreateRelatedObjects)
					{
						// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
						dbObj = context.Entity_Base.Add(dbObj);
					}
					
					for (var index = 0; index < obj.Addresses.Count; index++)
					{
						var address = obj.Addresses[index];
						if (!address.ID.Equals(Guid.Empty)) continue;
						if (!obj.ID.Equals(Guid.Empty) && address.ID.Equals(Guid.Empty))
						{
							address.EntityID = obj.ID;
						}
						var addressHandler = new AddressHandler();
						addressHandler.Create(ref address);
					}
					for (var index = 0; index < obj.EmailAddresses.Count; index++)
					{
						var address = obj.EmailAddresses[index];
						if (address.ID != 0) continue;
						if (!obj.ID.Equals(Guid.Empty) && address.ID == 0)
						{
							address.EntityID = obj.ID;
						}
						var addressHandler = new EmailAddressHandler();
						addressHandler.Create(ref address);
					}
					for (var index = 0; index < obj.PhoneNumbers.Count; index++)
					{
						var phone = obj.PhoneNumbers[index];
						if (phone.ID != 0) continue;
						if (!obj.ID.Equals(Guid.Empty) && phone.ID == 0)
						{
							phone.EntityID = obj.ID;
						}
						var phoneHandler = new PhoneNumberHandler();
						phoneHandler.Create(ref phone);
					}

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
		/// Updated existing Base in the database
		/// </summary>
		/// <param name="obj">Base object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Base obj)
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

					for (var index = 0; index < obj.Addresses.Count; index++)
					{
						var address = obj.Addresses[index];
						var addressHandler = new AddressHandler();
						addressHandler.Update(ref address);
					}
					for (var index = 0; index < obj.EmailAddresses.Count; index++)
					{
						var address = obj.EmailAddresses[index];
						var addressHandler = new EmailAddressHandler();
						addressHandler.Update(ref address);
					}
					for (var index = 0; index < obj.PhoneNumbers.Count; index++)
					{
						var phone = obj.PhoneNumbers[index];
						var phoneHandler = new PhoneNumberHandler();
						phoneHandler.Update(ref phone);
					}

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

		public ServiceResultEnum Update(Base obj)
		{
			return Update(ref obj);
		}

		/// <summary>
		/// Delete an Base from the database
		/// </summary>
		/// <param name="id">Base id the object to be deleted from the database</param>
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
					var dbObj = context.Entity_Base.Find(id);

					if (dbObj != null)
					{
						dbObj.IsActive = false;
						dbObj.IsDeleted = true;

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

		public override Base ReadOne(Guid id, Guid personId, Guid id3, int id4, int id5, int id6)
		{
			throw new NotImplementedException();
		}

		public override List<Base> ReadAll()
		{
			throw new NotImplementedException();
		}

		public override List<Base> ReadFiltered(Base obj)
		{
			throw new NotImplementedException();
		}

	}
}