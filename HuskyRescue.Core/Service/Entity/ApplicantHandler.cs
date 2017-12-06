using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using Fabrik.Common;
using HuskyRescue.Core.Pdf;
using HuskyRescue.Core.Properties;
using HuskyRescue.Core.ViewModel;
using HuskyRescue.Model;
using HuskyRescue.Core.Mappers.Extensions.Entity;
using NLog.Mvc;
using Applicant = HuskyRescue.Core.ViewModel.Entity.Applicant;

namespace HuskyRescue.Core.Service.Entity
{
	public class ApplicantHandler : BaseHandler<Applicant>
	{
		private readonly ILogger _logger;
		public ApplicantHandler()
		{
			_logger = new Logger();
			ServiceResult = ServiceResultEnum.Failure;
		}

		public ApplicantHandler(ILogger logger)
		{
			_logger = logger;
			ServiceResult = ServiceResultEnum.Failure;
		}

		/// <summary>
		/// Add new Applicant to the database
		/// </summary>
		/// <param name="obj">Applicant object to be saved to the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Create(ref Applicant obj)
		{
			// Number of changes as a result of the database change
			NumberChanges = 0;
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					#region Save Application to Database
					try
					{
						// Create ViewModel of adopter
						var appPersonVm = new ViewModel.Entity.Person
										  {
											  Base =
											  {
												  EmailAddresses = new List<ViewModel.Entity.EmailAddress>(),
												  PhoneNumbers = new List<ViewModel.Entity.PhoneNumber>()
											  }
										  };
						if (!string.IsNullOrEmpty(obj.AppEmail))
						{
							appPersonVm.Base.EmailAddresses.Add(new ViewModel.Entity.EmailAddress
																{
																	Address = obj.AppEmail,
																	Type = "0"
																});
						}
						if (!string.IsNullOrEmpty(obj.AppCellPhone))
						{
							appPersonVm.Base.PhoneNumbers.Add(
								new ViewModel.Entity.PhoneNumber
								{
									Number = obj.AppCellPhone,
									Type = "3"
								}
							);
						}
						if (!string.IsNullOrEmpty(obj.AppHomePhone))
						{
							appPersonVm.Base.PhoneNumbers.Add(
								new ViewModel.Entity.PhoneNumber
								{
									Number = obj.AppHomePhone,
									Type = "1"
								}
							);
						}

						appPersonVm.FirstName = obj.AppNameFirst;
						appPersonVm.LastName = obj.AppNameLast;
						if (obj.DateSubmitted == null) obj.DateSubmitted = DateTime.Now;
						appPersonVm.Base.Comments = "applied for: " + obj.FilterAppDogsInterestedIn + " on " + obj.DateSubmitted.Value.ToShortDateString() + ". ";

						// Save primary adopter to database
						var personHandler = new PersonHandler();
						personHandler.Create(ref appPersonVm);

						// Associate the application with the adopter in the database
						obj.PersonID = appPersonVm.ID;

						// Remove "owned animals" that are blank (no name)
						obj.ApplicantOwnedAnimal.RemoveAll(pet => pet.Name.IsNullOrEmpty());

						// Associate the adopter's "owned animals" in the database to the adopter
						foreach (var animalVm in obj.ApplicantOwnedAnimal)
						{
							animalVm.PersonID = obj.PersonID;
							if (string.IsNullOrEmpty(animalVm.Breed)) { animalVm.Breed = "n/a"; }
						}

						// convert to database object
						var dbObj = obj.ToModel();

						// StateId is only 2 char in database and will error if there is whitespace after that. 
						dbObj.AppAddressStateId = dbObj.AppAddressStateId.Trim();

						// add to the database and retrieve the updated object back (namely the GUID generated into the Id)
						dbObj = context.Applicants.Add(dbObj);

						// commit changes to the database
						NumberChanges = context.SaveChanges();

						// convert the database object back to a presentation object with included changes from the database (if any)
						obj = dbObj.ToViewModel();

					}
					catch (DbEntityValidationException dex)
					{
						_logger.Error("ApplicantError", dex);
						var validationErrors = "";
						foreach (var failure in dex.EntityValidationErrors)
						{
							validationErrors = failure.ValidationErrors.Aggregate(validationErrors, (current, error) => current + (error.PropertyName + "  " + error.ErrorMessage));
							validationErrors += Environment.NewLine + Environment.NewLine;
						}
						if (validationErrors != "")
						{
							_logger.Error("ApplicantError - Data Validation Errors " + Environment.NewLine + validationErrors, dex);
						}
						if (dex.InnerException != null)
						{
							_logger.Error("ApplicantError - Data Validation Inner", dex.InnerException);
						}
					}
					catch (Exception ex)
					{
						_logger.Error("ApplicantError", ex);
						if (ex.InnerException != null)
						{
							_logger.Error("ApplicantError Inner", ex.InnerException);
						}
					}
					finally
					{
						_logger.Information("Application App Submitted" + Environment.NewLine + obj);
					}
					#endregion

					#region generate application pdf
					var newPdfPath = string.Empty;
					try
					{
						// Generate the pdf of the application and email it
						var genPdf = new GenerateAppPdf(_logger);
						newPdfPath = genPdf.CreatePdf(obj, obj.ApplicantType);
					}
					catch (Exception ex)
					{
						_logger.Error(obj.ApplicantType + " App PDF Gen Ex", ex);
						if (ex.InnerException != null)
						{
							_logger.Error(obj.ApplicantType + " App PDF Gen Inner Ex", ex.InnerException);
						}
					}
					#endregion

					#region Email Application

					var appTypeDesc = (obj.ApplicantType.Equals("A")) ? "Adoption" : "Foster";

					var subject = "Online " + appTypeDesc + " Application for " + obj.AppNameFirst + " " + obj.AppNameLast;
					const string bodyAppHtml = @" Thank you for your application.
								See attachment for a copy of your application sent to Texas Husky Rescue, Inc.
								You can respond back to this email if you have any further questions or comments for us.
								We will get back to you within the next 5 days regarding your application.";
					var bodyGroup = @" Dogs interested in: " + obj.FilterAppDogsInterestedIn;

					var message = new EmailMessage
								  {
									  BodyTextExternal = bodyAppHtml,
									  BodyTextInternal = bodyGroup,
									  Subject = subject,
									  EmailAddressExternal = (string.IsNullOrEmpty(obj.AppEmail)) ? string.Empty : obj.AppEmail,
									  EmailAddressInternal = Settings.Default.ContactEmail,
									  NameInternal = "Texas Husky Rescue",
									  NameExternal = string.Empty
								  };

					var newPdfFile = new FileInfo(newPdfPath);
					if (newPdfFile.Exists)
					{
						var attachment = new Attachment(newPdfFile.FullName, MediaTypeNames.Application.Octet);
						var disposition = attachment.ContentDisposition;
						disposition.CreationDate = newPdfFile.CreationTime;
						disposition.ModificationDate = newPdfFile.CreationTime;
						disposition.ReadDate = newPdfFile.CreationTime;
						disposition.FileName = newPdfFile.Name;
						disposition.Size = newPdfFile.Length;
						disposition.DispositionType = DispositionTypeNames.Attachment;
						message.Attachments.Add(attachment);
					}
					message.SendMessage();
					#endregion
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
		/// Updated existing Applicant in the database
		/// </summary>
		/// <param name="obj">Applicant object to be Updated in the database</param>
		/// <returns>success or failure</returns>
		public override ServiceResultEnum Update(ref Applicant obj)
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
		/// Delete an Applicant from the database
		/// </summary>
		/// <param name="id">Applicant id the object to be deleted from the database</param>
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
					var dbObj = context.Applicants.Find(id);

					if (dbObj != null)
					{
						// TODO remove vets and owned animals first

						context.Applicants.Remove(dbObj);

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
		/// Retrieve on Applicant object for presentation
		/// </summary>
		/// <param name="id">id to look up the Applicant in the database</param>
		/// <param name="personId"></param>
		/// <param name="id3"></param>
		/// <param name="id4"></param>
		/// <param name="id5"></param>
		/// <param name="id6"></param>
		/// <returns>presentation Applicant object or null if not found</returns>
		public override Applicant ReadOne(Guid id, Guid personId, Guid id3, int id4, int id5, int id6)
		{
			var obj = new Applicant();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					obj = context.Applicants
						.Include(a => a.ApplicantOwnedAnimals)
						.Include(a => a.ApplicantVeterinarian)
						.Single(a => a.ID == id && a.PersonID == personId)
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

		public Applicant ReadOne(Guid id, Guid personId)
		{
			return ReadOne(id, personId, Guid.Empty, 0, 0, 0);
		}

		/// <summary>
		/// Retrieve all Applicantes from the database for presentation
		/// </summary>
		/// <returns>list of Applicant</returns>
		public override List<Applicant> ReadAll()
		{
			var objList = new List<Applicant>();
			try
			{
				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					// convert to presentation object
					objList = context.Applicants.ToList().ToViewModel();
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
		/// <returns>List of Applicant objects filtered and then sorted by name</returns>
		public override List<Applicant> ReadFiltered(Applicant obj)
		{
			var objList = new List<Applicant>();
			try
			{
				// Build dynamic query based on the provided presentation object's properties
				// http://stackoverflow.com/questions/13628748/linq-dynamic-query-for-entity-framework
				var conditions = new List<Func<Model.Applicant, bool>>();
				if (obj.ID != Guid.Empty) { conditions.Add(e => e.ID == obj.ID); }
				if (!string.IsNullOrEmpty(obj.ApplicantType)) { conditions.Add(e => e.ApplicantType.Equals(obj.ApplicantType)); }
				if (!string.IsNullOrEmpty(obj.AppNameLast)) { conditions.Add(e => e.AppNameLast.Contains(obj.AppNameLast)); }
				if (!string.IsNullOrEmpty(obj.AppNameFirst)) { conditions.Add(e => e.AppNameLast.Contains(obj.AppNameFirst)); }
				if (obj.DateSubmitted != null) { conditions.Add(e => e.DateSubmitted.Equals(obj.DateSubmitted)); }
				if (obj.DateSubmittedMax != null) { conditions.Add(e => e.DateSubmitted <= obj.DateSubmittedMax); }
				if (obj.DateSubmittedMin != null) { conditions.Add(e => e.DateSubmitted >= obj.DateSubmittedMin); }

				// Perform data access using the context
				using (var context = new HuskyRescueEntities())
				{
					var query = context.Applicants.AsQueryable();
					query = conditions.Aggregate(query, (current, condition) => current.Where(condition).AsQueryable());

					// convert to presentation object
					objList = query.OrderByDescending(a => a.DateSubmitted).ToList().ToViewModel();
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