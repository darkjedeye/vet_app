using System;
using System.Collections.Generic;
using System.Globalization;
using LINQtoCSV;

namespace HuskyRescue.Core.TrackABeast
{
	/// <summary>
	/// Parse animals from TrackABeast
	/// </summary>
	public class AnimalParser {
		public IEnumerable<TABAnimal> ParseCSV(string file, char separator) {
			CsvFileDescription inputFileDescription = new CsvFileDescription {
				SeparatorChar = separator,
				FirstLineHasColumnNames = true
			};
			CsvContext cc = new CsvContext();

			IEnumerable<TABAnimal> animals = cc.Read<TABAnimal>(file, inputFileDescription);

			return animals;
		}
	}

	public class TABAnimal {
		/// <summary>
		/// TrackABeast Unique ID
		/// </summary>
		[CsvColumn(Name = "TrackID", NumberStyle = NumberStyles.Integer, FieldIndex = 1)]
		public int TrackID { get; set; }

		/// <summary>
		/// Animal name
		/// </summary>
		[CsvColumn(Name = "Name", FieldIndex = 2)]
		public string Name { get; set; }

		/// <summary>
		/// Animal Type (Dog/cat/horse/etc)
		/// </summary>
		[CsvColumn(Name = "Type", FieldIndex = 3)]
		public string Type { get; set; }

		/// <summary>
		/// Date entered into system
		/// </summary>
		[CsvColumn(Name = "Entry Date", FieldIndex = 4)]
		public DateTime EntryDate { get; set; }

		/// <summary>
		/// Is the dog active - still has "work" to be done (adoptable/adopted)
		/// </summary>
		[CsvColumn(Name = "Active", FieldIndex = 5)]
		public string Active { get; set; }

		/// <summary>
		/// Is Adoption ready?
		/// </summary>
		[CsvColumn(Name = "Ad Ready", FieldIndex = 6)]
		public string AdReady { get; set; }

		/// <summary>
		/// is Spayed/Neutered
		/// </summary>
		[CsvColumn(Name = "Spay", FieldIndex = 7)]
		public string Spay { get; set; }

		/// <summary>
		/// is fully vaccinated
		/// </summary>
		[CsvColumn(Name = "Fully Vacc", FieldIndex = 8)]
		public string FullyVacc { get; set; }

		/// <summary>
		/// Feline Leuk 
		/// </summary>
		[CsvColumn(Name = "Fel Leuk", FieldIndex = 9)]
		public string FelLeuk { get; set; }

		/// <summary>
		/// is rabies done
		/// </summary>
		[CsvColumn(Name = "Rabies", FieldIndex = 10)]
		public string Rabies { get; set; }

		/// <summary>
		/// current location
		/// </summary>
		[CsvColumn(Name = "Current Loc", FieldIndex = 11)]
		public string CurrentLoc { get; set; }

		/// <summary>
		/// location placement status (foster/boarding/adopted)
		/// </summary>
		[CsvColumn(Name = "Placement Status", FieldIndex = 12)]
		public string PlacementStatus { get; set; }

		/// <summary>
		/// where did the animal come from
		/// </summary>
		[CsvColumn(Name = "Origin", FieldIndex = 13)]
		public string Origin { get; set; }

		/// <summary>
		/// Total medical charges
		/// </summary>
		[CsvColumn(Name = "Med Charges", FieldIndex = 14)]
		public decimal MedCharges { get; set; }

		/// <summary>
		/// Total supply cost for this animal
		/// </summary>
		[CsvColumn(Name = "Supplies", FieldIndex = 15)]
		public decimal Supplies { get; set; }

		/// <summary>
		/// Total Boarding fees
		/// </summary>
		[CsvColumn(Name = "Boarding", FieldIndex = 16)]
		public decimal Boarding { get; set; }

		/// <summary>
		/// Total training fees
		/// </summary>
		[CsvColumn(Name = "Training", FieldIndex = 17)]
		public decimal Training { get; set; }

		/// <summary>
		/// Adoption fees
		/// </summary>
		[CsvColumn(Name = "Ad Fees", FieldIndex = 18)]
		public decimal AdFees { get; set; }

		/// <summary>
		/// Type of rescue (owner surrender/stray/etc)
		/// </summary>
		[CsvColumn(Name = "Rescue Type", FieldIndex = 19)]
		public string RescueType { get; set; }

		/// <summary>
		/// Animal bred
		/// </summary>
		[CsvColumn(Name = "Breed", FieldIndex = 20)]
		public string Breed { get; set; }

		/// <summary>
		/// Date of birth
		/// </summary>
		[CsvColumn(Name = "Birthdate", FieldIndex = 21)]
		public DateTime Birthdate { get; set; }

		/// <summary>
		/// Impound (animal control) ID
		/// </summary>
		[CsvColumn(Name = "Impound", FieldIndex = 22)]
		public string Impound { get; set; }

		/// <summary>
		/// Rescue Group animal ID
		/// </summary>
		[CsvColumn(Name = "Rescue Group Animal Id", FieldIndex = 23)]
		public string RescueGroupAnimalId { get; set; }

		/// <summary>
		/// Microchip ID
		/// </summary>
		[CsvColumn(Name = "Microchip", FieldIndex = 24)]
		public string Microchip { get; set; }

		/// <summary>
		/// Tattoo ID
		/// </summary>
		[CsvColumn(Name = "Tattoo", FieldIndex = 25)]
		public string Tattoo { get; set; }

		/// <summary>
		/// Rabies ID
		/// </summary>
		[CsvColumn(Name = "Registration", FieldIndex = 26)]
		public string Registration { get; set; }

		/// <summary>
		/// ???
		/// </summary>
		[CsvColumn(Name = "Initial Rescue", FieldIndex = 27)]
		public string InitialRescue { get; set; }

		/// <summary>
		/// Gender of the animal (male/female)
		/// </summary>
		[CsvColumn(Name = "Sex", FieldIndex = 28)]
		public string Sex { get; set; }

		/// <summary>
		/// Size: XLarge, Large, Medium, Small
		/// </summary>
		[CsvColumn(Name = "Size", FieldIndex = 29)]
		public string Size { get; set; }

		/// <summary>
		/// Weight of the animal (pounds.ounces)
		/// </summary>
		[CsvColumn(Name = "Weight", FieldIndex = 30)]
		public string Weight { get; set; }

		/// <summary>
		/// <para>Special needs comments (this is NOT an indication of a special needs animal.</para>
		/// <para>This may only be special instructions</para>
		/// </summary>
		[CsvColumn(Name = "Special Needs", FieldIndex = 31)]
		public string SpecialNeeds { get; set; }

		/// <summary>
		/// Biography of the animal
		/// </summary>
		[CsvColumn(Name = "Biography", FieldIndex = 32)]
		public string Biography { get; set; }

		/// <summary>
		/// description of the animal
		/// </summary>
		[CsvColumn(Name = "Description", FieldIndex = 33)]
		public string Description { get; set; }

		/// <summary>
		/// file name of the animal biography picture
		/// </summary>
		[CsvColumn(Name = "File Name", FieldIndex = 34)]
		public string FileName { get; set; }

		/// <summary>
		/// Color of the animal
		/// </summary>
		[CsvColumn(Name = "Color", FieldIndex = 35)]
		public string Color { get; set; }

		/// <summary>
		/// Last date of placement change
		/// </summary>
		[CsvColumn(Name = "Placement Date", FieldIndex = 36)]
		public DateTime PlacementDate { get; set; }

		public TABAnimal() {

		}
	}
}
