using System;
using System.Web;
using HuskyRescue.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using HuskyRescue.Core.Properties;
using NLog.Mvc;
using Applicant = HuskyRescue.Core.ViewModel.Entity.Applicant;


namespace HuskyRescue.Core.Pdf
{
	public class GenerateAppPdf
	{
		private readonly ILogger _logger;

		public GenerateAppPdf()
		{
			_logger = new Logger();
		}

		public GenerateAppPdf(ILogger logger)
		{
			_logger = logger;
		}


		/// <summary>
		/// Method to create and email Adoption/Foster Application PDF
		/// </summary>
		/// <param name="app">Adoption application from Web or DB</param>
		/// <param name="logger"></param>
		/// <param name="appType"></param>
		public string CreatePdf(Applicant app, string appType)
		{
			// Path to newly created file based on PDF template
			var pdfNewFilePath = string.Empty;
			try
			{
				string genPath;
				string pdfTempFilePath;

				if (appType.Equals("A"))
				{
					genPath = Settings.Default.PathToGeneratedAdoptionApplications;
					// get location of template
					pdfTempFilePath = HttpContext.Current.Server.MapPath(Settings.Default.AdoptionApplicationLocation);
				}
				else
				{
					genPath = Settings.Default.PathToGeneratedFosterApplications;
					// get location of template
					pdfTempFilePath = HttpContext.Current.Server.MapPath(Settings.Default.FosterApplicationLocation);
				}

				if (!Directory.Exists(HttpContext.Current.Server.MapPath(genPath)))
				{
					Directory.CreateDirectory(genPath);
				}
				// create path to new file that will be generated
				var fileName = app.AppNameLast + " - " + app.ID + ".pdf";
				pdfNewFilePath = Path.Combine(HttpContext.Current.Server.MapPath(genPath), fileName);

				using (var tempPdfFileStream = new FileStream(pdfTempFilePath, FileMode.Open))
				using (var newPdfFileStream = new FileStream(pdfNewFilePath, FileMode.Create))
				{
					// Open template PDF
					var pdfReader = new PdfReader(tempPdfFileStream);

					// PdfStamper is used to read the field keys and flatten the PDF after generating
					using (var pdfStamper = new PdfStamper(pdfReader, newPdfFileStream))
					{
						try
						{
							// get list of all field names (keys) in the template
							var pdfFormFields = pdfStamper.AcroFields;

							using (var context = new HuskyRescueEntities())
							{
								pdfFormFields.SetField("AppName", app.AppNameFirst + " " + app.AppNameLast);
								pdfFormFields.SetField("AppSpouseName", app.AppSpouseNameFirst + " " + app.AppSpouseNameLast);
								pdfFormFields.SetField("AppAddressStreet", app.AppAddressStreet1);
								pdfFormFields.SetField("AppAddressCityStateZip", app.AppAddressCity + ", " + app.AppAddressStateId + " " + app.AppAddressZIP);
								pdfFormFields.SetField("AppHomePhone", app.AppHomePhone);
								pdfFormFields.SetField("AppCellPhone", app.AppCellPhone);
								pdfFormFields.SetField("AppEmail", app.AppEmail);
								pdfFormFields.SetField("AppEmployer", app.AppEmployer);
								if (app.AppDateBirth != null)
									pdfFormFields.SetField("AppDateBirth", app.AppDateBirth.Value.ToShortDateString());
								if (app.DateSubmitted != null)
									pdfFormFields.SetField("DateSubmitted", app.DateSubmitted.Value.ToShortDateString());
								if (appType.Equals("A"))
								{
									pdfFormFields.SetField("IsAllAdultsAgreedOnAdoption", IsTrueFalse(app.IsAllAdultsAgreedOnAdoption));
									pdfFormFields.SetField("IsAllAdultsAgreedOnAdoptionReason", app.IsAllAdultsAgreedOnAdoptionReason);
								}

								pdfFormFields.SetField("ResidenceOwnership", context.Enum_ResidenceOwnershipType.Find(app.ResidenceOwnershipID).ID.ToString());
								pdfFormFields.SetField("ResidenceType", context.Enum_ResidenceType.Find(app.ResidenceTypeID).ID.ToString());
								if (app.ResidenceTypeID.Equals(2))
								{ //Rent
									pdfFormFields.SetField("ResidenceIsPetAllowed", IsTrueFalse(app.ResidenceIsPetAllowed));
									pdfFormFields.SetField("ResidenceIsPetDepositRequired", IsTrueFalse(app.ResidenceIsPetDepositRequired));
									pdfFormFields.SetField("ResidencePetDepositAmount", app.ResidencePetDepositAmount.ToString());
									pdfFormFields.SetField("ResidenceIsPetSizeWeightLimit", IsTrueFalse(app.ResidenceIsPetSizeWeightLimit));
									pdfFormFields.SetField("ResidencePetDepositCoverage", context.Enum_PetDepositCoverage.Find(app.ResidencePetDepositCoverageID).ID.ToString());
									pdfFormFields.SetField("ResidenceLandlordName", app.ResidenceLandlordName);
									pdfFormFields.SetField("ResidenceLandlordNumber", app.ResidenceLandlordNumber);
									pdfFormFields.SetField("ResidenceIsPetDepositPaid", IsTrueFalse(app.ResidenceIsPetDepositPaid));
								}
								pdfFormFields.SetField("ResidenceLengthOfResidence", app.ResidenceLengthOfResidence);
								pdfFormFields.SetField("WhatIfMovingPetPlacement", app.WhatIfMovingPetPlacement);
								pdfFormFields.SetField("IsAppOrSpouseStudent", IsTrueFalse(app.IsAppOrSpouseStudent));
								pdfFormFields.SetField("StudentType", context.Enum_StudentType.Find(app.StudentTypeID).ID.ToString());
								pdfFormFields.SetField("IsAppTravelFrequent", IsTrueFalse(app.IsAppTravelFrequent));
								pdfFormFields.SetField("AppTravelFrequency", app.AppTravelFrequency);
								pdfFormFields.SetField("WhatIfTravelPetPlacement", app.WhatIfTravelPetPlacement);
								pdfFormFields.SetField("ResidenceNumberOccupants", app.ResidenceNumberOccupants);
								pdfFormFields.SetField("ResidenceAgesOfChildren", app.ResidenceAgesOfChildren);
								pdfFormFields.SetField("ResidenceIsYardFenced", IsTrueFalse(app.ResidenceIsYardFenced));
								pdfFormFields.SetField("ResidenceFenceType", app.ResidenceFenceType);
								pdfFormFields.SetField("ResidenceFenceHeight", app.ResidenceFenceHeight);

								pdfFormFields.SetField("IsPetKeptLocationInOutDoorsTotallyInside", IsYesNo(app.IsPetKeptLocationInOutDoorsTotallyInside));
								pdfFormFields.SetField("IsPetKeptLocationInOutDoorsMostlyInside", IsYesNo(app.IsPetKeptLocationInOutDoorsMostlyInside));
								pdfFormFields.SetField("IsPetKeptLocationInOutDoorsTotallyOutside", IsYesNo(app.IsPetKeptLocationInOutDoorsTotallyOutside));
								pdfFormFields.SetField("IsPetKeptLocationInOutDoorMostlyOutsides", IsYesNo(app.IsPetKeptLocationInOutDoorMostlyOutsides));
								pdfFormFields.SetField("PetKeptLocationInOutDoorsExplain", app.PetKeptLocationInOutDoorsExplain);

								pdfFormFields.SetField("PetKeptAloneHoursPerDay", app.PetLeftAloneHours);
								pdfFormFields.SetField("PetKeptAloneNumberDays", app.PetLeftAloneDays);

								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionLooseIndoors", IsYesNo(app.IsPetKeptLocationAloneRestrictionLooseIndoors));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionGarage", IsYesNo(app.IsPetKeptLocationAloneRestrictionGarage));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionOutsideKennel", IsYesNo(app.IsPetKeptLocationAloneRestrictionOutsideKennel));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionCratedIndoors", IsYesNo(app.IsPetKeptLocationAloneRestrictionCratedIndoors));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionLooseInBackyard", IsYesNo(app.IsPetKeptLocationAloneRestrictionLooseInBackyard));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionTiedUpOutdoors", IsYesNo(app.IsPetKeptLocationAloneRestrictionTiedUpOutdoors));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionBasement", IsYesNo(app.IsPetKeptLocationAloneRestrictionBasement));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionCratedOutdoors", IsYesNo(app.IsPetKeptLocationAloneRestrictionCratedOutdoors));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionInBedOwner", IsYesNo(app.IsPetKeptLocationSleepingRestrictionInBedOwner));
								pdfFormFields.SetField("IsPetKeptLocationAloneRestrictionOther", IsYesNo(app.IsPetKeptLocationAloneRestrictionOther));
								pdfFormFields.SetField("PetKeptLocationAloneRestrictionExplain", app.PetKeptLocationAloneRestrictionExplain);

								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionLooseIndoors", IsYesNo(app.IsPetKeptLocationSleepingRestrictionLooseIndoors));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionGarage", IsYesNo(app.IsPetKeptLocationSleepingRestrictionGarage));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionOutsideKennel", IsYesNo(app.IsPetKeptLocationSleepingRestrictionOutsideKennel));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionCratedIndoors", IsYesNo(app.IsPetKeptLocationSleepingRestrictionCratedIndoors));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionLooseInBackyard", IsYesNo(app.IsPetKeptLocationSleepingRestrictionLooseInBackyard));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionTiedUpOutdoors", IsYesNo(app.IsPetKeptLocationSleepingRestrictionTiedUpOutdoors));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionBasement", IsYesNo(app.IsPetKeptLocationSleepingRestrictionBasement));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionCratedOutdoors", IsYesNo(app.IsPetKeptLocationSleepingRestrictionCratedOutdoors));
								pdfFormFields.SetField("IsPetKeptLocationSleepingRestrictionOther", IsYesNo(app.IsPetKeptLocationSleepingRestrictionOther));
								pdfFormFields.SetField("PetKeptLocationSleepingRestrictionExplain", app.PetKeptLocationSleepingRestrictionExplain);

								if (appType.Equals("A"))
								{
									pdfFormFields.SetField("IsPetAdoptionReasonHousePet", IsYesNo(app.IsPetAdoptionReasonHousePet));
									pdfFormFields.SetField("IsPetAdoptionReasonGuardDog", IsYesNo(app.IsPetAdoptionReasonGuardDog));
									pdfFormFields.SetField("IsPetAdoptionReasonWatchDog", IsYesNo(app.IsPetAdoptionReasonWatchDog));
									pdfFormFields.SetField("IsPetAdoptionReasonGift", IsYesNo(app.IsPetAdoptionReasonGift));
									pdfFormFields.SetField("IsPetAdoptionReasonCompanionChild", IsYesNo(app.IsPetAdoptionReasonCompanionChild));
									pdfFormFields.SetField("IsPetAdoptionReasonCompanionPet", IsYesNo(app.IsPetAdoptionReasonCompanionPet));
									pdfFormFields.SetField("IsPetAdoptionReasonJoggingPartner", IsYesNo(app.IsPetAdoptionReasonJoggingPartner));
									pdfFormFields.SetField("IsPetAdoptionReasonOther", IsYesNo(app.IsPetAdoptionReasonOther));
									pdfFormFields.SetField("PetAdoptionReasonExplain", app.PetAdoptionReasonExplain);
								}

								pdfFormFields.SetField("FilterAppHasOwnedHuskyBefore", IsTrueFalse(app.FilterAppHasOwnedHuskyBefore));
								pdfFormFields.SetField("FilterAppIsAwareHuskyAttributes", IsTrueFalse(app.FilterAppIsAwareHuskyAttributes));

								pdfFormFields.SetField("FilterAppTraitsDesired", app.FilterAppTraitsDesired);

								pdfFormFields.SetField("FilterAppIsCatOwner", IsTrueFalse(app.FilterAppIsCatOwner));
								pdfFormFields.SetField("FilterAppCatsOwnedCount", app.FilterAppCatsOwnedCount);

								pdfFormFields.SetField("FilterAppDogsInterestedIn", app.FilterAppDogsInterestedIn);

								pdfFormFields.SetField("Veterinarian.NameOffice", app.ApplicantVeterinarian.NameOffice);
								pdfFormFields.SetField("Veterinarian.NameDr", app.ApplicantVeterinarian.NameDr);
								pdfFormFields.SetField("Veterinarian.PhoneNumber", app.ApplicantVeterinarian.PhoneNumber);

								var count = 1;
								foreach (var animal in app.ApplicantOwnedAnimal)
								{
									if (count > 4) break;
									if (!string.IsNullOrEmpty(animal.Name))
									{
										var num = count.ToString();
										pdfFormFields.SetField("AdopterAnimal.Name" + num, animal.Name);
										pdfFormFields.SetField("AdopterAnimal.Breed" + num, animal.Breed);
										pdfFormFields.SetField("AdopterAnimal.Gender" + num, context.Enum_Gender.Find(animal.Gender).Value);
										pdfFormFields.SetField("AdopterAnimal.Age" + num, animal.AgeMonths);
										pdfFormFields.SetField("AdopterAnimal.OwnershipLengthMonths" + num, animal.OwnershipLengthMonths);
										pdfFormFields.SetField("AdopterAnimal.IsAltered" + num, IsTrueFalse(animal.IsAltered));
										pdfFormFields.SetField("AdopterAnimal.AlteredReason" + num, animal.AlteredReason);
										pdfFormFields.SetField("AdopterAnimal.IsHwPrevention" + num, IsTrueFalse(animal.IsHwPrevention));
										pdfFormFields.SetField("AdopterAnimal.HwPreventionReason" + num, animal.HwPreventionReason);
										pdfFormFields.SetField("AdopterAnimal.IsFullyVaccinated" + num, IsTrueFalse(animal.IsFullyVaccinated));
										pdfFormFields.SetField("AdopterAnimal.FullyVaccinatedReason" + num, animal.FullyVaccinatedReason);
										pdfFormFields.SetField("AdopterAnimal.IsStillOwned" + num, IsTrueFalse(animal.IsStillOwned));
										pdfFormFields.SetField("AdopterAnimal.IsStillOwnedReason" + num, animal.IsStillOwnedReason);
									}
									count++;
								}
							}
							pdfFormFields = null;
						}
						catch (DocumentException docEx)
						{
							// handle pdf document exception if any
							_logger.Error("ApplicantGen - DocumentException " + docEx.Message, docEx);
						}
						catch (IOException ioEx)
						{
							// handle IO exception
							_logger.Error("ApplicantGen - IOException " + ioEx.Message, ioEx);
						}
						catch (Exception ex)
						{
							// handle other exception
							_logger.Error("ApplicantGen - GeneralException " + ex.Message, ex);
						}
						finally
						{
							pdfStamper.FormFlattening = true;
						}
					}
					pdfReader.Close();
					pdfReader = null;
				}
			}
			catch (Exception ex)
			{
				_logger.Error("App PDF Gen Error", ex);
			}

			return pdfNewFilePath;
		}

		/// <summary>
		/// return string literal "true" or "false" from object true or false
		/// </summary>
		/// <param name="value">Boolean true or false</param>
		/// <returns>string "true" or "false"</returns>
		private string IsTrueFalse(bool? value)
		{
			return value == true ? "true" : "false";
		}

		/// <summary>
		/// return string literal "yes" or "no" from object true or false
		/// </summary>
		/// <param name="value">Boolean true or false</param>
		/// <returns>string "yes" or "no"</returns>
		private string IsYesNo(bool? value)
		{
			return value == true ? "Yes" : "No";
		}
	}
}
