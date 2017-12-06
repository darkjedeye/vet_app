using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HuskyRescue.Core.ViewModel.RescueGroups
{
	public class RootAnimal
	{
		public string status { get; set; }
		public Messages messages { get; set; }
		public int foundRows { get; set; }
		public List<Animal> data { get; set; }
	}

	public class Animal
	{
		public string animalID { get; set; }
		public string animalAltered { get; set; }
		public string animalBirthdate { get; set; }
		public string animalBreed { get; set; }
		public string animalColor { get; set; }
		public string animalCratetrained { get; set; }
		public string animalDescription { get; set; }
		public string animalEnergyLevel { get; set; }
		public string animalExerciseNeeds { get; set; }
		public string animalEyeColor { get; set; }
		public string animalGeneralAge { get; set; }
		public string animalHousetrained { get; set; }
		public string animalLeashtrained { get; set; }
		public string animalMixedBreed { get; set; }
		public string animalName { get; set; }
		public string animalNeedsFoster { get; set; }
		public string animalOKWithAdults { get; set; }
		public string animalOKWithCats { get; set; }
		public string animalOKWithDogs { get; set; }
		public string animalOKWithKids { get; set; }
		public string animalOrgID { get; set; }
		public string animalOthernames { get; set; }
		public string animalRescueID { get; set; }
		public string animalSex { get; set; }
		public string animalSpecialneeds { get; set; }
		public string animalSpecialneedsDescription { get; set; }
		public string animalStatus { get; set; }
		public string animalSummarypublic { get; set; }
		public string animalThumbnailUrl { get; set; }
		public List<AnimalPicture> animalPictures { get; set; }

		public Animal()
		{
			animalPictures = new List<AnimalPicture>();
		}
	}

	public class AnimalPicture
	{
		public string mediaID { get; set; }
		public string fileSize { get; set; }
		public string resolutionX { get; set; }
		public string resolutionY { get; set; }
		public string mediaOrder { get; set; }
		public string fileNameFullsize { get; set; }
		public string fileNameThumbnail { get; set; }
		public string urlSecureFullsize { get; set; }
		public string urlSecureThumbnail { get; set; }
		public string urlInsecureFullsize { get; set; }
		public string urlInsecureThumbnail { get; set; }
	}

	public class Messages
	{
		public List<object> generalMessages { get; set; }
		public List<object> recordMessages { get; set; }
	}

	/*
	public class Fields2
	{
		public AnimalID2 animalID { get; set; }
		public AnimalOrgID animalOrgID { get; set; }
		public AnimalActivityLevel animalActivityLevel { get; set; }
		public AnimalAdoptionFee animalAdoptionFee { get; set; }
		public AnimalAltered animalAltered { get; set; }
		public AnimalAvailableDate animalAvailableDate { get; set; }
		public AnimalBirthdate animalBirthdate { get; set; }
		public AnimalBirthdateExact animalBirthdateExact { get; set; }
		public AnimalBreed animalBreed { get; set; }
		public AnimalCoatLength animalCoatLength { get; set; }
		public AnimalColor animalColor { get; set; }
		public AnimalColorID animalColorID { get; set; }
		public AnimalColorDetails animalColorDetails { get; set; }
		public AnimalCourtesy animalCourtesy { get; set; }
		public AnimalDeclawed animalDeclawed { get; set; }
		public AnimalDescription animalDescription { get; set; }
		public AnimalDescriptionPlain animalDescriptionPlain { get; set; }
		public AnimalDistinguishingMarks animalDistinguishingMarks { get; set; }
		public AnimalEarType animalEarType { get; set; }
		public AnimalEnergyLevel animalEnergyLevel { get; set; }
		public AnimalExerciseNeeds animalExerciseNeeds { get; set; }
		public AnimalEyeColor animalEyeColor { get; set; }
		public AnimalFence animalFence { get; set; }
		public AnimalFound animalFound { get; set; }
		public AnimalFoundDate animalFoundDate { get; set; }
		public AnimalFoundPostalcode animalFoundPostalcode { get; set; }
		public AnimalGeneralAge animalGeneralAge { get; set; }
		public AnimalGeneralSizePotential animalGeneralSizePotential { get; set; }
		public AnimalGroomingNeeds animalGroomingNeeds { get; set; }
		public AnimalHousetrained animalHousetrained { get; set; }
		public AnimalIndoorOutdoor animalIndoorOutdoor { get; set; }
		public AnimalKillDate animalKillDate { get; set; }
		public AnimalKillReason animalKillReason { get; set; }
		public AnimalLocation animalLocation { get; set; }
		public AnimalLocationDistance animalLocationDistance { get; set; }
		public AnimalLocationCitystate animalLocationCitystate { get; set; }
		public AnimalMicrochipped animalMicrochipped { get; set; }
		public AnimalMixedBreed animalMixedBreed { get; set; }
		public AnimalName animalName { get; set; }
		public AnimalSpecialneeds animalSpecialneeds { get; set; }
		public AnimalSpecialneedsDescription animalSpecialneedsDescription { get; set; }
		public AnimalNeedsFoster animalNeedsFoster { get; set; }
		public AnimalNewPeople animalNewPeople { get; set; }
		public AnimalNotHousetrainedReason animalNotHousetrainedReason { get; set; }
		public AnimalObedienceTraining animalObedienceTraining { get; set; }
		public AnimalOKWithAdults animalOKWithAdults { get; set; }
		public AnimalOKWithCats animalOKWithCats { get; set; }
		public AnimalOKWithDogs animalOKWithDogs { get; set; }
		public AnimalOKWithKids animalOKWithKids { get; set; }
		public AnimalOthernames animalOthernames { get; set; }
		public AnimalOwnerExperience animalOwnerExperience { get; set; }
		public AnimalPattern animalPattern { get; set; }
		public AnimalPatternID animalPatternID { get; set; }
		public AnimalAdoptionPending animalAdoptionPending { get; set; }
		public AnimalPrimaryBreed animalPrimaryBreed { get; set; }
		public AnimalPrimaryBreedID animalPrimaryBreedID { get; set; }
		public AnimalRescueID animalRescueID { get; set; }
		public AnimalSearchString animalSearchString { get; set; }
		public AnimalSecondaryBreed animalSecondaryBreed { get; set; }
		public AnimalSecondaryBreedID animalSecondaryBreedID { get; set; }
		public AnimalSex animalSex { get; set; }
		public AnimalShedding animalShedding { get; set; }
		public AnimalSizeCurrent animalSizeCurrent { get; set; }
		public AnimalSizePotential animalSizePotential { get; set; }
		public AnimalSizeUOM animalSizeUOM { get; set; }
		public AnimalSpecies animalSpecies { get; set; }
		public AnimalSpeciesID animalSpeciesID { get; set; }
		public AnimalSponsorable animalSponsorable { get; set; }
		public AnimalSponsors animalSponsors { get; set; }
		public AnimalSponsorshipDetails animalSponsorshipDetails { get; set; }
		public AnimalSponsorshipMinimum animalSponsorshipMinimum { get; set; }
		public AnimalStatus animalStatus { get; set; }
		public AnimalStatusID animalStatusID { get; set; }
		public AnimalSummary animalSummary { get; set; }
		public AnimalTailType animalTailType { get; set; }
		public AnimalThumbnailUrl animalThumbnailUrl { get; set; }
		public AnimalUptodate animalUptodate { get; set; }
		public AnimalUpdatedDate animalUpdatedDate { get; set; }
		public AnimalUrl animalUrl { get; set; }
		public AnimalVocal animalVocal { get; set; }
		public AnimalYardRequired animalYardRequired { get; set; }
		public AnimalAffectionate animalAffectionate { get; set; }
		public AnimalApartment animalApartment { get; set; }
		public AnimalCratetrained animalCratetrained { get; set; }
		public AnimalDrools animalDrools { get; set; }
		public AnimalEagerToPlease animalEagerToPlease { get; set; }
		public AnimalEscapes animalEscapes { get; set; }
		public AnimalEventempered animalEventempered { get; set; }
		public AnimalFetches animalFetches { get; set; }
		public AnimalGentle animalGentle { get; set; }
		public AnimalGoodInCar animalGoodInCar { get; set; }
		public AnimalGoofy animalGoofy { get; set; }
		public AnimalHasAllergies animalHasAllergies { get; set; }
		public AnimalHearingImpaired animalHearingImpaired { get; set; }
		public AnimalHypoallergenic animalHypoallergenic { get; set; }
		public AnimalIndependent animalIndependent { get; set; }
		public AnimalIntelligent animalIntelligent { get; set; }
		public AnimalLap animalLap { get; set; }
		public AnimalLeashtrained animalLeashtrained { get; set; }
		public AnimalNeedsCompanionAnimal animalNeedsCompanionAnimal { get; set; }
		public AnimalNoCold animalNoCold { get; set; }
		public AnimalNoFemaleDogs animalNoFemaleDogs { get; set; }
		public AnimalNoHeat animalNoHeat { get; set; }
		public AnimalNoLargeDogs animalNoLargeDogs { get; set; }
		public AnimalNoMaleDogs animalNoMaleDogs { get; set; }
		public AnimalNoSmallDogs animalNoSmallDogs { get; set; }
		public AnimalObedient animalObedient { get; set; }
		public AnimalOKForSeniors animalOKForSeniors { get; set; }
		public AnimalOKWithFarmAnimals animalOKWithFarmAnimals { get; set; }
		public AnimalOlderKidsOnly animalOlderKidsOnly { get; set; }
		public AnimalOngoingMedical animalOngoingMedical { get; set; }
		public AnimalPlayful animalPlayful { get; set; }
		public AnimalPlaysToys animalPlaysToys { get; set; }
		public AnimalPredatory animalPredatory { get; set; }
		public AnimalProtective animalProtective { get; set; }
		public AnimalSightImpaired animalSightImpaired { get; set; }
		public AnimalSkittish animalSkittish { get; set; }
		public AnimalSpecialDiet animalSpecialDiet { get; set; }
		public AnimalSwims animalSwims { get; set; }
		public AnimalTimid animalTimid { get; set; }
		public FosterEmail fosterEmail { get; set; }
		public FosterFirstname fosterFirstname { get; set; }
		public FosterLastname fosterLastname { get; set; }
		public FosterName fosterName { get; set; }
		public FosterPhoneCell fosterPhoneCell { get; set; }
		public FosterPhoneHome fosterPhoneHome { get; set; }
		public FosterSalutation fosterSalutation { get; set; }
		public LocationAddress locationAddress { get; set; }
		public LocationCity locationCity { get; set; }
		public LocationCountry locationCountry { get; set; }
		public LocationUrl locationUrl { get; set; }
		public LocationName locationName { get; set; }
		public LocationPhone locationPhone { get; set; }
		public LocationState locationState { get; set; }
		public LocationPostalcode locationPostalcode { get; set; }
		public AnimalPictures animalPictures { get; set; }
		public AnimalVideos animalVideos { get; set; }
		public AnimalVideoUrls animalVideoUrls { get; set; }
	}
*/
}
