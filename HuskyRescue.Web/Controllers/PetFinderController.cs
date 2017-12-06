using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HuskyRescue.Core.PetFinder;
using HuskyRescue.Core.ViewModel;
using NLog.Mvc;

namespace HuskyRescue.Web.Controllers
{
	public class PetFinderController : BaseController
	{
		private readonly ILogger _logger;
		public PetFinderController(ILogger logger)
		{
			_logger = logger;
		}

		//
		// GET: /PetFinder/
		/*
		public ActionResult Index()
		{
			_logger.Trace("/PetFinder/Index (get) called");

			PetFinderProcessing.ShelterID = "TX1326";
			var pf = new PetFinderProcessing();

			pf.GetShelter();

			var pfList = pf.GetShelterPets();

			var petRecords = new List<PetFinder_PetRecord>();
			foreach (var record in pfList.pet)
			{
				petRecords.Add(new PetFinder_PetRecord
							   {
								   ID = record.id,
								   ShelterPetID = record.shelterPetId,
								   Age = record.age.ToString(),
								   Description = record.description,
								   Name = record.name,
								   Sex = record.sex.ToString(),
								   Size = record.size.ToString(),
								   IsAltered = record.options.Contains(petOptionType.altered),
								   IsCatFriendly = !record.options.Contains(petOptionType.noCats),
								   IsDogFriendly = !record.options.Contains(petOptionType.noDogs),
								   //IsMix = record.mix.ToString(),
								   IsSpecialNeeds = record.options.Contains(petOptionType.specialNeeds),
								   IsHousebroken = record.options.Contains(petOptionType.housebroken),
								   HasShots = record.options.Contains(petOptionType.hasShots),
								   NeedsFoster = record.name.ToLower().Contains("foster"),
								   PictureUrlsFull = record.media.photos.Select(x => x.Value).Where(y => !string.IsNullOrEmpty(y)).ToList()
							   });
			}
			return View();
		}
		*/
		public ActionResult FosterNeeded()
		{
			_logger.Trace("/PetFinder/FosterNeeded (get) called");
			PetFinder_PetRecord pet = null;

			PetFinderProcessing.ShelterID = "TX1326";
			var pf = new PetFinderProcessing();
			pf.AuthGetToken();

			var pfList = pf.GetShelterPets();

			var petRecords = new List<PetFinder_PetRecord>();
			if (pfList.pet != null)
			{
				foreach (var record in pfList.pet)
				{
					if (!record.name.ToLower().Contains("foster") || record.name.ToLower().Equals("foster homes need")) continue;
					if (record.media.photos != null)
					{
						petRecords.Add(new PetFinder_PetRecord
									   {
										   ID = record.id,
										   ShelterPetID = record.shelterPetId,
										   Age = record.age.ToString(),
										   Description = record.description,
										   ShortDescription = record.description.Length > 325 ? record.description.Substring(0, 325) : record.description,
										   Link = @"http://www.petfinder.com/petdetail/" + record.id,
										   Name = record.name.Split('-')[0],
										   Sex = record.sex.ToString(),
										   Size = record.size.ToString(),
										   IsAltered = record.options.Contains(petOptionType.altered),
										   IsCatFriendly = !record.options.Contains(petOptionType.noCats),
										   IsDogFriendly = !record.options.Contains(petOptionType.noDogs),
										   //IsMix = record.mix.ToString(),
										   IsSpecialNeeds = record.options.Contains(petOptionType.specialNeeds),
										   IsHousebroken = record.options.Contains(petOptionType.housebroken),
										   HasShots = record.options.Contains(petOptionType.hasShots),
										   NeedsFoster = true,
										   PictureUrlsFull = record.media.photos.Where(pic => pic.size == petPhotoTypeSize.fpm).Select(x => x.Value).Where(y => !string.IsNullOrEmpty(y)).ToList(),
										   PictureUrlsThumb = record.media.photos.Where(pic => pic.size == petPhotoTypeSize.pnt).Select(x => x.Value).Where(y => !string.IsNullOrEmpty(y)).ToList()
									   });
					}
				}
			}
			if (petRecords.Count > 1)
			{
				var rnd = new Random();
				pet = petRecords.OrderBy(x => rnd.Next(petRecords.Count)).First();
			}
			else if (petRecords.Count == 1)
			{
				pet = petRecords.First();
			}

			return PartialView("FosterNeeded", pet);
		}

	}
}
