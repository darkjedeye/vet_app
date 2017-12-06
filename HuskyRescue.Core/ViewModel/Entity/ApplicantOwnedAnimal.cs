using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HuskyRescue.Core.ViewModel.Attributes;

namespace HuskyRescue.Core.ViewModel.Entity
{
	public class ApplicantOwnedAnimal
	{
		#region properties
		public Guid ID { get; set; }
		
		public Guid PersonID { get; set; }

		public Guid ApplicantID { get; set; }

		[DisplayName("Name"), DataType(DataType.Text), StringLength(50), FoundationAbidePattern("length_50")]
		public string Name { get; set; }

		[DisplayName("Breed"), DataType(DataType.Text), StringLength(20), FoundationAbidePattern("length_20")]
		public string Breed { get; set; }

		/// <summary>
		/// Age (X years Y months)
		/// </summary>
		[DisplayName("Age"), DataType(DataType.Text), StringLength(100), FoundationAbidePattern("length_100")]
		public string AgeMonths { get; set; }

		[DisplayName("Length of ownership"), DataType(DataType.Text), StringLength(100), FoundationAbidePattern("length_100")]
		public string OwnershipLengthMonths { get; set; }

		/// <summary>
		/// Male or Female
		/// </summary>
		[DisplayName("Sex")]
		public IEnumerable<SelectListItem> GenderList { get; set; }

		[Required]
		public string Gender { get; set; }

		#region medical information
		[DisplayName("Altered (spay/neuter)?"), Required]
		public bool? IsAltered { get; set; }

		[DisplayName("If no, please explain why"), DataType(DataType.Text), Required, StringLength(200), FoundationAbidePattern("length_200")]
		public string AlteredReason { get; set; }

		[DisplayName("On HW Preventative?"), Required]
		public bool? IsHwPrevention { get; set; }

		[DisplayName("If no, please explain why"), DataType(DataType.Text), Required, StringLength(200), FoundationAbidePattern("length_200")]
		public string HwPreventionReason { get; set; }

		[DisplayName("Fully Vaccinated?"), Required]
		public bool? IsFullyVaccinated { get; set; }

		[DisplayName("If no, please explain why"), DataType(DataType.Text), Required, StringLength(200), FoundationAbidePattern("length_200")]
		public string FullyVaccinatedReason { get; set; }
		#endregion

		[DisplayName("Do you still own this animal?"), Required]
		public bool? IsStillOwned { get; set; }

		[DisplayName("If no, please explain why"), DataType(DataType.Text), Required, StringLength(200), FoundationAbidePattern("length_200")]
		public string IsStillOwnedReason { get; set; }

		public bool Delete { get; set; }

		public int Number { get; set; }
		#endregion

		#region methods
		public ApplicantOwnedAnimal()
		{
			this.GenderList = new List<SelectListItem>();
		}
		#endregion
	}
}
