using HuskyRescue.Core.ViewModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Entity
{
	[HandleError]
	public class Applicant
	{
		public Applicant()
		{
			ApplicantVeterinarian = new ApplicantVeterinarian();
			ApplicantOwnedAnimal = new List<ApplicantOwnedAnimal>();
			AppAddressStateList = new List<SelectListItem>();
			ResidencePetDepositCoverageList = new List<SelectListItem>();
			ResidenceOwnershipList = new List<SelectListItem>();
			ResidenceTypeList = new List<SelectListItem>();
			StudentTypeList = new List<SelectListItem>();
			ApplicantType = "A";
			ApplicantTypeList = new List<SelectListItem>();
			ApplicantTypeList.Add(new SelectListItem() { Selected = false, Text = "Adopt", Value = "A" });
			ApplicantTypeList.Add(new SelectListItem() { Selected = false, Text = "Foster", Value = "F" });
		}

		#region Filter Properties
		[DisplayName("Date App Submitted Max"), DataType(DataType.Date)]
		public DateTime? DateSubmittedMax { get; set; }

		[DisplayName("Date App Submitted Min"), DataType(DataType.Date)]
		public DateTime? DateSubmittedMin { get; set; }
		#endregion

		#region Properties
		public ApplicantVeterinarian ApplicantVeterinarian { get; set; }

		public List<ApplicantOwnedAnimal> ApplicantOwnedAnimal { get; set; }

		public Guid ID { get; set; }

		public Guid PersonID { get; set; }

		public Guid ApplicantVeterinariansID { get; set; }

		[DataType(DataType.Text), StringLength(1)]
		public string ApplicantType { get; set; }
		public List<SelectListItem> ApplicantTypeList { get; set; }

		[DisplayName("Today's Date"), DataType(DataType.Date)]
		public DateTime? DateSubmitted { get; set; }

		public string AppFullName
		{
			get
			{
				return AppNameFirst + " " + AppNameLast;
			}
		}

		public bool? IsCompleted { get; set; }
		public bool? IsDeleted { get; set; }

		#region Applicant Contact Information
		[DisplayName("Applicant First Name"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string AppNameFirst { get; set; }

		[DisplayName("Last Name"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string AppNameLast { get; set; }

		[DisplayName("Co-applicant First Name"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string AppSpouseNameFirst { get; set; }

		[DisplayName("Last Name"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string AppSpouseNameLast { get; set; }

		[DisplayName("Cell Phone Number"), DataType(DataType.PhoneNumber), StringLength(14), FoundationAbidePattern("phone", "Must be a phone number")]
		public string AppCellPhone { get; set; }

		[DisplayName("Home Phone Number"), DataType(DataType.PhoneNumber), StringLength(14), FoundationAbidePattern("phone", "Must be a phone number")]
		public string AppHomePhone { get; set; }

		public string AppAddressFull { get { return AppAddressStreet1 + ", " + AppAddressCity + ", " + AppAddressStateId + ", " + AppAddressZIP; } }

		public string AppAddressCityStateZip { get { return AppAddressCity + ", " + AppAddressStateId + ", " + AppAddressZIP; } }

		[DisplayName("Street Address"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string AppAddressStreet1 { get; set; }

		[DisplayName("City"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string AppAddressCity { get; set; }

		[DisplayName("State"), Required]
		public IEnumerable<SelectListItem> AppAddressStateList { get; set; }

		[DisplayName("State"), Required]
		public string AppAddressStateId { get; set; }

		[DisplayName("ZIP"), DataType(DataType.PostalCode), Required, StringLength(10), FoundationAbidePattern("number")]
		public string AppAddressZIP { get; set; }

		[DisplayName("Email Address"), DataType(DataType.EmailAddress), Required, StringLength(200), FoundationAbidePattern("length_200")]
		public string AppEmail { get; set; }

		[DisplayName("Date of Birth"), DataType(DataType.Date), Required, FoundationAbidePattern("month_day_year")]
		public DateTime? AppDateBirth { get; set; }

		[DisplayName("Employer"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string AppEmployer { get; set; }
		#endregion

		#region Residence Information

		[DisplayName("Do you own or rent?"), Required]
		public IEnumerable<SelectListItem> ResidenceOwnershipList { get; set; }

		[DisplayName("Do you own or rent?"), Required]
		public int ResidenceOwnershipID { get; set; }

		[DisplayName("Residence type?"), Required]
		public IEnumerable<SelectListItem> ResidenceTypeList { get; set; }

		[DisplayName("Residence type?"), Required]
		public int ResidenceTypeID { get; set; }

		/// <summary>
		/// Does your landlord allow pets? YES NO
		/// </summary>
		[DisplayName("Does your landlord allow pets?"), Required]
		public bool? ResidenceIsPetAllowed { get; set; }

		/// <summary>
		/// Is a pet deposit required? YES NO
		/// </summary>
		[DisplayName("Is a pet deposit required?"), Required]
		public bool? ResidenceIsPetDepositRequired { get; set; }

		/// <summary>
		/// How much is the pet deposit?
		/// </summary>
		[DisplayName("How much is the deposit?"), Required]
		//[Range(0.01, 10000.00, ErrorMessage = "Amount must be greater than zero.")]
		//[DataType(DataType.Currency)]
		public decimal ResidencePetDepositAmount { get; set; }

		[DisplayName("Has the deposit been paid?"), Required]
		public bool? ResidenceIsPetDepositPaid { get; set; }

		[DisplayName("Is the deposit"), Required]
		public IEnumerable<SelectListItem> ResidencePetDepositCoverageList { get; set; }

		[DisplayName("Is the deposit"), Required]
		public int ResidencePetDepositCoverageID { get; set; }

		/// <summary>
		/// per pet or per household
		/// </summary>
		[DataType(DataType.Text), StringLength(20)]
		public string ResidencePetDepositCoverage { get; set; }

		/// <summary>
		/// Size/Weight Limit? YES NO
		/// </summary>
		[DisplayName("Pet size/weight Limit?"), Required]
		public bool? ResidenceIsPetSizeWeightLimit { get; set; }

		/// <summary>
		/// Name of Apartment Complex or Landlord: 
		/// </summary>
		[DisplayName("Name of Apartment Complex or Landlord"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_100")]
		public string ResidenceLandlordName { get; set; }

		/// <summary>
		/// Complex/Landlord Phone number
		/// </summary>
		[DisplayName("Complex/Landlord Phone number"), DataType(DataType.PhoneNumber), Required, StringLength(50), FoundationAbidePattern("phone", "Must be a phone number")]
		public string ResidenceLandlordNumber { get; set; }

		/// <summary>
		/// How long have you lived at your current residence?
		/// </summary>
		[DisplayName("How long have you lived at your current residence?"), DataType(DataType.Text), Required, StringLength(30), FoundationAbidePattern("length_30")]
		public string ResidenceLengthOfResidence { get; set; }
		#endregion

		#region Filtering Information
		/// <summary>
		/// Are you or your spouse a student? YES NO
		/// </summary>
		[DisplayName("Are you or your spouse a student?"), Required]
		public bool? IsAppOrSpouseStudent { get; set; }

		[DisplayName("Student Type"), Required]
		public IEnumerable<SelectListItem> StudentTypeList { get; set; }

		[DisplayName("Student Type"), Required]
		public int StudentTypeID { get; set; }

		/// <summary>
		/// Do you or your spouse travel frequently? YES NO
		/// </summary>
		[DisplayName("Do you or your spouse travel frequently?"), Required]
		public bool? IsAppTravelFrequent { get; set; }

		/// <summary>
		/// If yes, how often?
		/// </summary>
		[DisplayName("If yes, how often?"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string AppTravelFrequency { get; set; }

		/// <summary>
		/// Where would your pet stay while you are out of town?
		/// </summary>
		[DisplayName("Where would your pet stay while you are out of town?"), DataType(DataType.MultilineText), Required, StringLength(4000), FoundationAbidePattern("length_4000")]
		public string WhatIfTravelPetPlacement { get; set; }

		/// <summary>
		/// If you had to move, what would you do with your pets?
		/// </summary>
		[DisplayName("If you had to move, what would you do with your pets?"), DataType(DataType.MultilineText), Required, StringLength(4000), FoundationAbidePattern("length_4000")]
		public string WhatIfMovingPetPlacement { get; set; }

		/// <summary>
		/// How many people live in your household
		/// </summary>
		[DisplayName("How many people live in your household"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string ResidenceNumberOccupants { get; set; }

		/// <summary>
		/// Ages of Children
		/// </summary>
		[DisplayName("Ages of children"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string ResidenceAgesOfChildren { get; set; }

		/// <summary>
		/// Do you have a fenced yard?
		/// </summary>
		[DisplayName("Do you have a fenced yard?"), Required]
		public bool? ResidenceIsYardFenced { get; set; }

		[DisplayName("Type of fence?"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string ResidenceFenceType { get; set; }

		[DisplayName("Height of the fence?"), DataType(DataType.Text), Required, StringLength(50), FoundationAbidePattern("length_50")]
		public string ResidenceFenceHeight { get; set; }

		/// <summary>
		/// This pet will be kept: Totally Inside Mostly Inside Totally Outside Mostly Outside
		/// </summary>
		[DisplayName("This pet will be kept..."), DataType(DataType.Text), Required, StringLength(200), FoundationAbidePattern("length_200")]
		public string PetKeptLocationInOutDoors { get; set; }

		[DisplayName("Totally Inside")]
		public bool IsPetKeptLocationInOutDoorsTotallyInside { get; set; }
		[DisplayName("Mostly Inside")]
		public bool IsPetKeptLocationInOutDoorsMostlyInside { get; set; }
		[DisplayName("Totally Outside")]
		public bool IsPetKeptLocationInOutDoorsTotallyOutside { get; set; }
		[DisplayName("Mostly Outside")]
		public bool IsPetKeptLocationInOutDoorMostlyOutsides { get; set; }

		[DisplayName("Reason"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string PetKeptLocationInOutDoorsExplain { get; set; }

		[DisplayName("Number of hours a day"), DataType(DataType.Text), Required, StringLength(20), FoundationAbidePattern("length_20")]
		public string PetLeftAloneHours { get; set; }

		[DisplayName("Number of days a week"), DataType(DataType.Text), Required, StringLength(20), FoundationAbidePattern("length_20")]
		public string PetLeftAloneDays { get; set; }

		/// <summary>
		/// Where will this pet be kept while you are at work or away from home?
		/// Loose indoors Garage Outside kennel or dog run Crated indoors Crated Outdoors
		/// Loose in Backyard Tied Up outdoors Basement other (please explain)
		/// </summary>
		[DisplayName("Where will this pet be kept while you are at work or away from home?")]
		[Required(ErrorMessage = "Required")]
		public string PetKeptLocationAloneRestriction { get; set; }
		[DisplayName("Loose indoors")]
		public bool IsPetKeptLocationAloneRestrictionLooseIndoors { get; set; }
		[DisplayName("Garage")]
		public bool IsPetKeptLocationAloneRestrictionGarage { get; set; }
		[DisplayName("Outside kennel or dog run")]
		public bool IsPetKeptLocationAloneRestrictionOutsideKennel { get; set; }
		[DisplayName("Crated indoors")]
		public bool IsPetKeptLocationAloneRestrictionCratedIndoors { get; set; }
		[DisplayName("Crated Outdoors")]
		public bool IsPetKeptLocationAloneRestrictionCratedOutdoors { get; set; }
		[DisplayName("Loose in Backyard")]
		public bool IsPetKeptLocationAloneRestrictionLooseInBackyard { get; set; }
		[DisplayName("Tied Up Outdoors")]
		public bool IsPetKeptLocationAloneRestrictionTiedUpOutdoors { get; set; }
		[DisplayName("Basement")]
		public bool IsPetKeptLocationAloneRestrictionBasement { get; set; }
		[DisplayName("Other")]
		public bool IsPetKeptLocationAloneRestrictionOther { get; set; }

		[DisplayName("Reason"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string PetKeptLocationAloneRestrictionExplain { get; set; }

		/// <summary>
		/// Where will this pet sleep at night?
		/// Loose indoors Garage Outside kennel or dog run Crated indoors Crated Outdoors
		/// Loose in Backyard Tied Up outdoors Basement In bed with owner other (please explain)
		/// </summary>
		[DisplayName("Where will this pet sleep at night?"), Required]
		public string PetKeptLocationSleepingRestriction { get; set; }
		[DisplayName("Loose indoors")]
		public bool IsPetKeptLocationSleepingRestrictionLooseIndoors { get; set; }
		[DisplayName("Garage")]
		public bool IsPetKeptLocationSleepingRestrictionGarage { get; set; }
		[DisplayName("Outside kennel or dog run")]
		public bool IsPetKeptLocationSleepingRestrictionOutsideKennel { get; set; }
		[DisplayName("Crated indoors")]
		public bool IsPetKeptLocationSleepingRestrictionCratedIndoors { get; set; }
		[DisplayName("Crated Outdoors")]
		public bool IsPetKeptLocationSleepingRestrictionCratedOutdoors { get; set; }
		[DisplayName("Loose in Backyard")]
		public bool IsPetKeptLocationSleepingRestrictionLooseInBackyard { get; set; }
		[DisplayName("Tied Up Outdoors")]
		public bool IsPetKeptLocationSleepingRestrictionTiedUpOutdoors { get; set; }
		[DisplayName("Basement")]
		public bool IsPetKeptLocationSleepingRestrictionBasement { get; set; }
		[DisplayName("In bed with owner")]
		public bool IsPetKeptLocationSleepingRestrictionInBedOwner { get; set; }
		[DisplayName("Other")]
		public bool IsPetKeptLocationSleepingRestrictionOther { get; set; }

		[DisplayName("Reason"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string PetKeptLocationSleepingRestrictionExplain { get; set; }

		/// <summary>
		/// Why do you want to adopt a husky at this time (check all that applies)?
		/// House Pet Guard Dog Watch Dog Gift Companion for Child
		/// Companion for Pet Jogging partner other (please explain):
		/// </summary>
		[DisplayName("Why do you want to adopt a husky at this time?"), DataType(DataType.MultilineText), Required, StringLength(4000), FoundationAbidePattern("length_4000")]
		public string PetAdoptionReason { get; set; }

		[DisplayName("House Pet")]
		public bool IsPetAdoptionReasonHousePet { get; set; }
		[DisplayName("Guard Dog")]
		public bool IsPetAdoptionReasonGuardDog { get; set; }
		[DisplayName("Watch Dog")]
		public bool IsPetAdoptionReasonWatchDog { get; set; }
		[DisplayName("Gift")]
		public bool IsPetAdoptionReasonGift { get; set; }
		[DisplayName("Companion for Child")]
		public bool IsPetAdoptionReasonCompanionChild { get; set; }
		[DisplayName("Companion for Pet")]
		public bool IsPetAdoptionReasonCompanionPet { get; set; }
		[DisplayName("Jogging partner")]
		public bool IsPetAdoptionReasonJoggingPartner { get; set; }
		[DisplayName("Other")]
		public bool IsPetAdoptionReasonOther { get; set; }

		[DisplayName("Reason"), DataType(DataType.MultilineText), StringLength(4000), FoundationAbidePattern("length_4000")]
		public string PetAdoptionReasonExplain { get; set; }

		/// <summary>
		/// Have you ever owned a husky? YES NO
		/// </summary>
		[DisplayName("Have you ever owned a husky?"), Required]
		public bool? FilterAppHasOwnedHuskyBefore { get; set; }

		/// <summary>
		/// What traits are you looking for in a Husky? (Active, lazy, likes kids, agility, etc.)
		/// </summary>
		[DisplayName("What traits are you looking for in a Husky (active, lazy, kid friendly, cat friendly agility, etc.)? Be specific so we can find a husky that best fits your lifestyle."), DataType(DataType.MultilineText), Required, StringLength(4000), FoundationAbidePattern("length_4000")]
		public string FilterAppTraitsDesired { get; set; }

		/// <summary>
		/// Do you currently own any cats? YES NO
		/// </summary>
		[DisplayName("Do you currently own any cats?"), Required]
		public bool? FilterAppIsCatOwner { get; set; }

		[DisplayName("If yes, how many?"), DataType(DataType.Text), Required, StringLength(20), FoundationAbidePattern("length_20")]
		public string FilterAppCatsOwnedCount { get; set; }

		[DisplayName("Are you aware huskies are diggers, escape artists, heavy shedders, and may not be cat friendly?"), Required]
		public bool? FilterAppIsAwareHuskyAttributes { get; set; }

		[DisplayName("Are all adults in agreement about the adoption?"), Required]
		public bool? IsAllAdultsAgreedOnAdoption { get; set; }

		[DisplayName("If no, why?"), DataType(DataType.MultilineText), Required, StringLength(4000), FoundationAbidePattern("length_4000")]
		public string IsAllAdultsAgreedOnAdoptionReason { get; set; }

		/// <summary>
		/// What dog are you interested in: (list all if more than one)
		/// </summary>
		[DisplayName("Which of our huskies are you interested in?"), DataType(DataType.MultilineText), Required, StringLength(4000), FoundationAbidePattern("length_4000")]
		public string FilterAppDogsInterestedIn { get; set; }
		#endregion

		#endregion

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("AppNameFirst: " + this.AppNameFirst);
			sb.AppendLine("AppNameLast: " + this.AppNameLast);
			sb.AppendLine("AppSpouseNameFirst: " + this.AppSpouseNameFirst);
			sb.AppendLine("AppSpouseNameLast: " + this.AppSpouseNameLast);
			sb.AppendLine("AppAddressStreet1: " + this.AppAddressStreet1);
			sb.AppendLine("AppAddressCity: " + this.AppAddressCity);
			sb.AppendLine("AppAddressStateId: " + this.AppAddressStateId);
			sb.AppendLine("AppAddressZIP: " + this.AppAddressZIP);
			sb.AppendLine("AppEmail: " + this.AppEmail);
			sb.AppendLine("AppCellPhone: " + this.AppCellPhone);
			sb.AppendLine("AppHomePhone: " + this.AppHomePhone);
			sb.AppendLine("AppDateBirth: " + this.AppDateBirth);
			sb.AppendLine("AppEmployer: " + this.AppEmployer);
			sb.AppendLine("IsAppTravelFrequent: " + this.IsAppTravelFrequent);
			sb.AppendLine("AppTravelFrequency: " + this.AppTravelFrequency);
			sb.AppendLine("IsAppOrSpouseStudent: " + this.IsAppOrSpouseStudent);
			sb.AppendLine("StudentTypeID: " + this.StudentTypeID);
			sb.AppendLine("IsAllAdultsAgreedOnAdoption: " + this.IsAllAdultsAgreedOnAdoption);
			sb.AppendLine("IsAllAdultsAgreedOnAdoptionReason: " + this.IsAllAdultsAgreedOnAdoptionReason);
			sb.AppendLine("FilterAppIsCatOwner: " + this.FilterAppIsCatOwner);
			sb.AppendLine("FilterAppCatsOwnedCount: " + this.FilterAppCatsOwnedCount);
			sb.AppendLine("ResidenceOwnershipID: " + this.ResidenceOwnershipID);
			sb.AppendLine("ResidenceTypeID: " + this.ResidenceTypeID);
			sb.AppendLine("ResidenceIsPetAllowed: " + this.ResidenceIsPetAllowed);
			sb.AppendLine("ResidenceIsPetSizeWeightLimit: " + this.ResidenceIsPetSizeWeightLimit);
			sb.AppendLine("ResidenceIsPetDepositRequired: " + this.ResidenceIsPetDepositRequired);
			sb.AppendLine("ResidencePetDepositAmount: " + this.ResidencePetDepositAmount);
			sb.AppendLine("ResidencePetDepositCoverageID: " + this.ResidencePetDepositCoverageID);
			sb.AppendLine("ResidenceIsPetDepositPaid: " + this.ResidenceIsPetDepositPaid);
			sb.AppendLine("ResidenceLandlordName: " + this.ResidenceLandlordName);
			sb.AppendLine("ResidenceLandlordNumber: " + this.ResidenceLandlordNumber);
			sb.AppendLine("ResidenceLengthOfResidence: " + this.ResidenceLengthOfResidence);
			sb.AppendLine("ResidenceNumberOccupants: " + this.ResidenceNumberOccupants);
			sb.AppendLine("ResidenceAgesOfChildren: " + this.ResidenceAgesOfChildren);
			sb.AppendLine("ResidenceIsYardFenced: " + this.ResidenceIsYardFenced);
			sb.AppendLine("ResidenceFenceHeight: " + this.ResidenceFenceHeight);
			sb.AppendLine("ResidenceFenceType: " + this.ResidenceFenceType);
			sb.AppendLine("FilterAppDogsInterestedIn: " + this.FilterAppDogsInterestedIn);
			sb.AppendLine("WhatIfMovingPetPlacement: " + this.WhatIfMovingPetPlacement);
			sb.AppendLine("WhatIfTravelPetPlacement: " + this.WhatIfTravelPetPlacement);
			sb.AppendLine("PetLeftAloneHours: " + this.PetLeftAloneHours);
			sb.AppendLine("PetLeftAloneDays: " + this.PetLeftAloneDays);
			sb.AppendLine("IsPetKeptLocationInOutDoorsTotallyInside: " + this.IsPetKeptLocationInOutDoorsTotallyInside);
			sb.AppendLine("IsPetKeptLocationInOutDoorsTotallyOutside: " + this.IsPetKeptLocationInOutDoorsTotallyOutside);
			sb.AppendLine("IsPetKeptLocationInOutDoorsMostlyInside: " + this.IsPetKeptLocationInOutDoorsMostlyInside);
			sb.AppendLine("IsPetKeptLocationInOutDoorMostlyOutsides: " + this.IsPetKeptLocationInOutDoorMostlyOutsides);
			sb.AppendLine("PetKeptLocationInOutDoorsExplain: " + this.PetKeptLocationInOutDoorsExplain);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionBasement: " + this.IsPetKeptLocationAloneRestrictionBasement);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionCratedIndoors: " + this.IsPetKeptLocationAloneRestrictionCratedIndoors);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionCratedOutdoors: " + this.IsPetKeptLocationAloneRestrictionCratedOutdoors);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionGarage: " + this.IsPetKeptLocationAloneRestrictionGarage);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionLooseInBackyard: " + this.IsPetKeptLocationAloneRestrictionLooseInBackyard);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionLooseIndoors: " + this.IsPetKeptLocationAloneRestrictionLooseIndoors);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionOutsideKennel: " + this.IsPetKeptLocationAloneRestrictionOutsideKennel);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionTiedUpOutdoors: " + this.IsPetKeptLocationAloneRestrictionTiedUpOutdoors);
			sb.AppendLine("IsPetKeptLocationAloneRestrictionOther: " + this.IsPetKeptLocationAloneRestrictionOther);
			sb.AppendLine("PetKeptLocationAloneRestrictionExplain: " + this.PetKeptLocationAloneRestrictionExplain);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionBasement: " + this.IsPetKeptLocationSleepingRestrictionBasement);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionCratedIndoors: " + this.IsPetKeptLocationSleepingRestrictionCratedIndoors);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionCratedOutdoors: " + this.IsPetKeptLocationSleepingRestrictionCratedOutdoors);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionGarage: " + this.IsPetKeptLocationSleepingRestrictionGarage);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionInBedOwner: " + this.IsPetKeptLocationSleepingRestrictionInBedOwner);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionLooseInBackyard: " + this.IsPetKeptLocationSleepingRestrictionLooseInBackyard);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionLooseIndoors: " + this.IsPetKeptLocationSleepingRestrictionLooseIndoors);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionOutsideKennel: " + this.IsPetKeptLocationSleepingRestrictionOutsideKennel);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionTiedUpOutdoors: " + this.IsPetKeptLocationSleepingRestrictionTiedUpOutdoors);
			sb.AppendLine("IsPetKeptLocationSleepingRestrictionOther: " + this.IsPetKeptLocationSleepingRestrictionOther);
			sb.AppendLine("PetKeptLocationSleepingRestrictionExplain: " + this.PetKeptLocationSleepingRestrictionExplain);
			if (this.ApplicantVeterinarian != null)
			{
				sb.AppendLine("ApplicantVeterinarian.NameDr: " + this.ApplicantVeterinarian.NameDr);
				sb.AppendLine("ApplicantVeterinarian.NameOffice: " + this.ApplicantVeterinarian.NameOffice);
				sb.AppendLine("ApplicantVeterinarian.PhoneNumber: " + this.ApplicantVeterinarian.PhoneNumber);
			}
			if (this.ApplicantOwnedAnimal != null)
			{
				foreach (var a in this.ApplicantOwnedAnimal)
				{
					sb.AppendLine("Name: " + a.Name);
					sb.AppendLine("Breed: " + a.Breed);
					sb.AppendLine("Gender: " + a.Gender);
					sb.AppendLine("AgeMonths: " + a.AgeMonths);
					sb.AppendLine("OwnershipLengthMonths: " + a.OwnershipLengthMonths);
					sb.AppendLine("IsAltered: " + a.IsAltered);
					sb.AppendLine("AlteredReason: " + a.AlteredReason);
					sb.AppendLine("IsHwPrevention: " + a.IsHwPrevention);
					sb.AppendLine("HwPreventionReason: " + a.HwPreventionReason);
					sb.AppendLine("IsFullyVaccinated: " + a.IsFullyVaccinated);
					sb.AppendLine("IsFullyVaccinated: " + a.IsFullyVaccinated);
					sb.AppendLine("IsStillOwned: " + a.IsStillOwned);
					sb.AppendLine("IsStillOwnedReason: " + a.IsStillOwnedReason);
				}
			}

			return sb.ToString();
		}
	}
}