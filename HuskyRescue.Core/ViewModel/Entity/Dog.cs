using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class Dog
	{
		public Dog()
		{
			BreedTypeList = new List<SelectListItem>();
			ColorList = new List<SelectListItem>();
			GenderList = new List<SelectListItem>();
			MicrochipTypeList = new List<SelectListItem>();
			MicrochipTypeList = new List<SelectListItem>();
			PlacementStatusList = new List<SelectListItem>();
			SizeList = new List<SelectListItem>();

			DogPictures = new List<DogImage>();
		}

		public List<DogImage> DogPictures { get; set; }

		public int ID { get; set; }

		[DisplayName("Biography")]
		[DataType(DataType.MultilineText)]
		public string Biography { get; set; }

		[DisplayName("Breed Type ID")]
		public int? BreedTypeID { get; set; }

		[DisplayName("Breed")]
		public IEnumerable<SelectListItem> BreedTypeList { get; set; }

		[DisplayName("Color ID")]
		public int? ColorID { get; set; }

		[DisplayName("Color")]
		public IEnumerable<SelectListItem> ColorList { get; set; }

		[DisplayName("Date Entered")]
		[DataType(DataType.Date)]
		public DateTime DateEntered { get; set; }

		[DisplayName("Date OF Birth")]
		[DataType(DataType.Text)]
		public DateTime? DateOfBirth { get; set; }

		[DisplayName("Dog Type ID")]
		public int DogTypeID { get; set; }

		/// <summary>
		/// Male or Female
		/// </summary>
		[DisplayName("Sex")]
		[Required(ErrorMessage = "Required")]
		public IEnumerable<SelectListItem> GenderList { get; set; }

		public string Gender { get; set; }

		[DisplayName("Active?")]
		[Required(ErrorMessage = "Required")]
		public bool IsActive { get; set; }

		[DisplayName("Adoptable?")]
		[Required(ErrorMessage = "Required")]
		public bool IsAdoptable { get; set; }

		[DisplayName("Foster Needed?")]
		public bool? IsFosterNeeded { get; set; }

		[DisplayName("Altered?")]
		public bool? IsAltered { get; set; }

		[DisplayName("Fully Vetted?")]
		public bool? IsFullyVetted { get; set; }

		[DisplayName("List on sites?")]
		[Required(ErrorMessage = "Required")]
		public bool IsListedable { get; set; }

		[DisplayName("Rabies Up to Date?")]
		[Required(ErrorMessage = "Required")]
		public bool? IsRabiesUTD { get; set; }

		public Guid? LocationCurrentID { get; set; }

		public Guid? LocationOriginID { get; set; }

		[DisplayName("Microchip ID")]
		[DataType(DataType.Text)]
		public string MicrochipID { get; set; }

		public string MicrochipTypeID { get; set; }

		[DisplayName("Microchip Type")]
		public IEnumerable<SelectListItem> MicrochipTypeList { get; set; }

		[DisplayName("Name")]
		[DataType(DataType.Text)]
		[Required(ErrorMessage = "Required")]
		public string Name { get; set; }

		public int? PlacementStatusID { get; set; }

		[DisplayName("Placement Status")]
		public IEnumerable<SelectListItem> PlacementStatusList { get; set; }

		[DisplayName("Rabies ID")]
		[DataType(DataType.Text)]
		public string RabiesID { get; set; }

		public int? SizeID { get; set; }

		[DisplayName("Size")]
		public IEnumerable<SelectListItem> SizeList { get; set; }

		[DisplayName("Weight")]
		[DataType(DataType.Text)]
		public decimal? Weight { get; set; }
	}
}