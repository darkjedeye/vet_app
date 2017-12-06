using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class DonationItems
	{
		public DonationItems()
		{
			Quantity = 1;
			Name = string.Empty;
			DonationItemType = 0;
			HasBeenReceived = false;
		}

		public Guid Id { get; set; }
		public Guid EventId { get; set; }
		public Guid PersonId { get; set; }
		public Guid BusinessId { get; set; }

		[DisplayName("Quantity")]
		[DataAnnotationsExtensions.Integer(ErrorMessage = "Enter a number greater than zero")]
		[Required(ErrorMessage = "Enter the number of items donated", AllowEmptyStrings = false)]
		[Range(1, 10000)]
		public int Quantity { get; set; }

		[DisplayName("Name/Description")]
		[StringLength(500)]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Provide a name or description for the doanted item(s)")]
		public string Name { get; set; }

		[DisplayName("Cost per item donated (optional)")]
		[DataType(DataType.Currency)]
		public decimal? CostPerItem { get; set; }

		[HiddenInput(DisplayValue = false)]
		public int DonationItemType { get; set; }

		[DisplayName("Item(s) to be used for...")]
		[Required(ErrorMessage = "Required")]
		public IEnumerable<SelectListItem> DonatedItemTypeList { get; set; }

		[HiddenInput(DisplayValue = false)]
		public int? EventPurposeID { get; set; }

		[DisplayName("Purpose of item for event")]
		[Required(ErrorMessage = "Required")]
		public IEnumerable<SelectListItem> EventPurposeTypeList { get; set; }

		[DisplayName("Has the donated item(s) been received?")]
		public bool HasBeenReceived { get; set; }

		[DisplayName("Date Received")]
		[DataType(DataType.Date)]
		public DateTime? DateReceived { get; set; }

		[DisplayName("Donating Person")]
		public List<SelectListItem> People { get; set; }

		[DisplayName("Donating Organisation")]
		public List<SelectListItem> Businesses { get; set; }

		[DisplayName("Event to use donation for")]
		public List<SelectListItem> EventList { get; set; }
	}
}