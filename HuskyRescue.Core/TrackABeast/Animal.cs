namespace HuskyRescue.Core.TrackABeast
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	//using System.ComponentModel.DataAnnotations;
	using System.Web.Mvc;

	public partial class Animal {
		#region Constructors
		/// <summary>
		/// Create animal
		/// </summary>
		/// <param name="name">Name</param>
		/// <param name="gender">Male or Female</param>
		/// <param name="age">Age (X years Y months)</param>
		public Animal( string name, string gender, string age ) {
			this.Name = name;
			this.Gender = gender;
			this.Age = age;
			this.IsCatFriendly = false;
			this.IsKidFriendly = false;
			this.IsSpecialNeeds = false;
		}

		/// <summary>
		/// Create animal
		/// </summary>
		/// <param name="name">Name</param>
		/// <param name="gender">Male or Female</param>
		/// <param name="age">Age (X years Y months)</param>
		/// <param name="cat">Is the animal friendly with cats</param>
		/// <param name="kid">Is the animal friendly with kids</param>
		/// <param name="special">Does the animal require special care and have special needs</param>
		public Animal( string name, string gender, string age, bool cat, bool kid, bool special, bool trial, bool foster ) {
			this.Name = name;
			this.Gender = gender;
			this.Age = age;
			this.IsCatFriendly = cat;
			this.IsKidFriendly = kid;
			this.IsSpecialNeeds = special;
			this.IsOnTrial = trial;
			this.IsFosterNeeded = foster;
		}
		#endregion

		/// <summary>
		/// Is a foster needed for this animal?
		/// </summary>
		public bool? IsFosterNeeded { get; set; }

		public System.Guid uid { get; set; }

		/// <summary>
		/// Age (X years Y months)
		/// </summary>
		//[DisplayName( "Age" )]
		public string Age { get; set; }

		/// <summary>
		/// Rescue Group ID
		/// </summary>
		public int GroupID { get; set; }

		/// <summary>
		/// Date Animal entered into system
		/// </summary>
		//[DataType( DataType.Date )]
		//[DisplayFormat( ApplyFormatInEditMode = true, DataFormatString = "{0:d}" )]
		public System.DateTime DateEntered { get; set; }

		/// <summary>
		/// Name of animal
		/// </summary>
		//[DisplayName( "Name" )]
		//[DataType( DataType.Text )]
		//[StringLength( 50 )]
		//[Required( ErrorMessage = "Required" )]
		public string Name { get; set; }

		/// <summary>
		/// Type of Animal
		/// </summary>
		public int Type { get; set; }

		/// <summary>
		/// Breed of the animal
		/// </summary>
		//[DisplayName( "Breed" )]
		//[Required( ErrorMessage = "Required" )]
		public int Breed { get; set; }

		/// <summary>
		/// Gender: Male/Female
		/// </summary>
		//[DataType( DataType.Text )]
		//[StringLength( 1 )]
		public string Gender { get; set; }

		//[DisplayName( "Date of Birth" )]
		//[Required( ErrorMessage = "Required" )]
		//[DataType( DataType.Date )]
		//[DisplayFormat( ApplyFormatInEditMode = true, DataFormatString = "{0:d}" )]
		public DateTime? DateOfBirth { get; set; }

		public int WeightOz { get; set; }

		public int HairColor { get; set; }

		public int EyeColor { get; set; }

		public bool? IsActive { get; set; }

		public bool? IsAdoptionReady { get; set; }

		//[DisplayName( "Spayed/Neutered" )]
		public bool? IsAltered { get; set; }

		public bool? IsRabiesVac { get; set; }

		public bool? IsHouseTrained { get; set; }

		public bool? IsCrateTrained { get; set; }

		public bool? IsTrained { get; set; }

		/// <summary>
		/// Is the animal friendly with cats
		/// </summary>
		//[DisplayName( "Is the dog cat friendly?" )]
		public bool? IsCatFriendly { get; set; }

		/// <summary>
		/// Is the animal friendly with kids
		/// </summary>
		//[DisplayName( "Is the dog kid friendly?" )]
		public bool? IsKidFriendly { get; set; }

		/// <summary>
		/// Does the animal require special care
		/// </summary>
		//[DisplayName( "Does the dog have speical needs?" )]
		public bool? IsSpecialNeeds { get; set; }

		//[DisplayName( "Is the dog on trial?" )]
		public bool? IsOnTrial { get; set; }

		public System.Guid CurrentLocation { get; set; }

		public int CurrentLocationStatus { get; set; }

		public Nullable<System.Guid> OriginationLocation { get; set; }

		public int OriginationLocationStatus { get; set; }

		//[DataType( DataType.Text )]
		//[StringLength( 50 )]
		public string MicrochipID { get; set; }

		//[DataType( DataType.Text )]
		//[StringLength( 50 )]
		public string ImpoundID { get; set; }

		//[DataType( DataType.Text )]
		//[StringLength( 50 )]
		public string RabiesID { get; set; }

		//[DataType( DataType.MultilineText )]
		//[StringLength( 4000 )]
		public string Biography { get; set; }

		//[DataType( DataType.MultilineText )]
		//[StringLength( 4000 )]
		public string Comments { get; set; }
	}
}
