﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuskyRescue.Core.PetFinder
{
	using System.Xml.Serialization;


	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class petfinder
	{

		private petfinderHeaderType headerField;

		private string lastOffsetField;

		private object itemField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderHeaderType header
		{
			get
			{
				return this.headerField;
			}
			set
			{
				this.headerField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string lastOffset
		{
			get
			{
				return this.lastOffsetField;
			}
			set
			{
				this.lastOffsetField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("auth", typeof(petfinderAuthData), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlElementAttribute("breeds", typeof(petfinderBreedList), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlElementAttribute("pet", typeof(petfinderPetRecord), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlElementAttribute("petIds", typeof(petfinderPetIdList), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlElementAttribute("pets", typeof(petfinderPetRecordList), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlElementAttribute("shelter", typeof(petfinderShelterRecord), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlElementAttribute("shelters", typeof(petfinderShelterRecordList), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public object Item
		{
			get
			{
				return this.itemField;
			}
			set
			{
				this.itemField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderHeaderType
	{

		private string versionField;

		private System.DateTime timestampField;

		private petfinderHeaderTypeStatus statusField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public System.DateTime timestamp
		{
			get
			{
				return this.timestampField;
			}
			set
			{
				this.timestampField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderHeaderTypeStatus status
		{
			get
			{
				return this.statusField;
			}
			set
			{
				this.statusField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class petfinderHeaderTypeStatus
	{

		private string codeField;

		private string messageField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "positiveInteger")]
		public string code
		{
			get
			{
				return this.codeField;
			}
			set
			{
				this.codeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string message
		{
			get
			{
				return this.messageField;
			}
			set
			{
				this.messageField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderShelterRecordList
	{

		private petfinderShelterRecord[] shelterField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("shelter", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderShelterRecord[] shelter
		{
			get
			{
				return this.shelterField;
			}
			set
			{
				this.shelterField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderShelterRecord
	{

		private string idField;

		private string nameField;

		private string address1Field;

		private string address2Field;

		private string cityField;

		private string stateField;

		private string zipField;

		private string countryField;

		private decimal latitudeField;

		private decimal longitudeField;

		private string phoneField;

		private string faxField;

		private string emailField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string address1
		{
			get
			{
				return this.address1Field;
			}
			set
			{
				this.address1Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string address2
		{
			get
			{
				return this.address2Field;
			}
			set
			{
				this.address2Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string city
		{
			get
			{
				return this.cityField;
			}
			set
			{
				this.cityField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string state
		{
			get
			{
				return this.stateField;
			}
			set
			{
				this.stateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string zip
		{
			get
			{
				return this.zipField;
			}
			set
			{
				this.zipField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string country
		{
			get
			{
				return this.countryField;
			}
			set
			{
				this.countryField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public decimal latitude
		{
			get
			{
				return this.latitudeField;
			}
			set
			{
				this.latitudeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public decimal longitude
		{
			get
			{
				return this.longitudeField;
			}
			set
			{
				this.longitudeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string phone
		{
			get
			{
				return this.phoneField;
			}
			set
			{
				this.phoneField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string fax
		{
			get
			{
				return this.faxField;
			}
			set
			{
				this.faxField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string email
		{
			get
			{
				return this.emailField;
			}
			set
			{
				this.emailField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderPetRecordList
	{

		private petfinderPetRecord[] petField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("pet", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderPetRecord[] pet
		{
			get
			{
				return this.petField;
			}
			set
			{
				this.petField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderPetRecord
	{

		private string idField;

		private string shelterIdField;

		private string shelterPetIdField;

		private string nameField;

		private animalType animalField;

		private petfinderBreedList breedsField;

		private petfinderPetRecordMix mixField;

		private petAgeType ageField;

		private petGenderType sexField;

		private petSizeType sizeField;

		private petOptionType[] optionsField;

		private string descriptionField;

		private System.DateTime lastUpdateField;

		private petStatusType statusField;

		private petfinderPetRecordMedia mediaField;

		private petContactType contactField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "positiveInteger")]
		public string id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string shelterId
		{
			get
			{
				return this.shelterIdField;
			}
			set
			{
				this.shelterIdField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string shelterPetId
		{
			get
			{
				return this.shelterPetIdField;
			}
			set
			{
				this.shelterPetIdField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public animalType animal
		{
			get
			{
				return this.animalField;
			}
			set
			{
				this.animalField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderBreedList breeds
		{
			get
			{
				return this.breedsField;
			}
			set
			{
				this.breedsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderPetRecordMix mix
		{
			get
			{
				return this.mixField;
			}
			set
			{
				this.mixField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petAgeType age
		{
			get
			{
				return this.ageField;
			}
			set
			{
				this.ageField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petGenderType sex
		{
			get
			{
				return this.sexField;
			}
			set
			{
				this.sexField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petSizeType size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("option", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
		public petOptionType[] options
		{
			get
			{
				return this.optionsField;
			}
			set
			{
				this.optionsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public System.DateTime lastUpdate
		{
			get
			{
				return this.lastUpdateField;
			}
			set
			{
				this.lastUpdateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petStatusType status
		{
			get
			{
				return this.statusField;
			}
			set
			{
				this.statusField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderPetRecordMedia media
		{
			get
			{
				return this.mediaField;
			}
			set
			{
				this.mediaField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petContactType contact
		{
			get
			{
				return this.contactField;
			}
			set
			{
				this.contactField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	public enum animalType
	{

		/// <remarks/>
		Dog,

		/// <remarks/>
		Cat,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Small&Furry")]
		SmallFurry,

		/// <remarks/>
		BarnYard,

		/// <remarks/>
		Bird,

		/// <remarks/>
		Horse,

		/// <remarks/>
		Pig,

		/// <remarks/>
		Rabbit,

		/// <remarks/>
		Reptile,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderBreedList
	{

		private petfinderBreedType[] breedField;

		private string animalField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("breed", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public petfinderBreedType[] breed
		{
			get
			{
				return this.breedField;
			}
			set
			{
				this.breedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string animal
		{
			get
			{
				return this.animalField;
			}
			set
			{
				this.animalField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	public enum petfinderBreedType
	{

		/// <remarks/>
		Unknown,

		/// <remarks/>
		Affenpinscher,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Afghan Hound")]
		AfghanHound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Airedale Terrier")]
		AiredaleTerrier,

		/// <remarks/>
		Akbash,

		/// <remarks/>
		Akita,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Alaskan Malamute")]
		AlaskanMalamute,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Bulldog")]
		AmericanBulldog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Eskimo Dog")]
		AmericanEskimoDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Hairless Terrier")]
		AmericanHairlessTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Staffordshire Terrier")]
		AmericanStaffordshireTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Water Spaniel")]
		AmericanWaterSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Anatolian Shepherd")]
		AnatolianShepherd,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Appenzell Mountain Dog")]
		AppenzellMountainDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Australian Cattle Dog/Blue Heeler")]
		AustralianCattleDogBlueHeeler,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Australian Kelpie")]
		AustralianKelpie,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Australian Shepherd")]
		AustralianShepherd,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Australian Terrier")]
		AustralianTerrier,

		/// <remarks/>
		Basenji,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Basset Hound")]
		BassetHound,

		/// <remarks/>
		Beagle,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bearded Collie")]
		BeardedCollie,

		/// <remarks/>
		Beauceron,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bedlington Terrier")]
		BedlingtonTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Belgian Shepherd Dog Sheepdog")]
		BelgianShepherdDogSheepdog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Belgian Shepherd Laekenois")]
		BelgianShepherdLaekenois,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Belgian Shepherd Malinois")]
		BelgianShepherdMalinois,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Belgian Shepherd Tervuren")]
		BelgianShepherdTervuren,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bernese Mountain Dog")]
		BerneseMountainDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bichon Frise")]
		BichonFrise,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Black and Tan Coonhound")]
		BlackandTanCoonhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Black Labrador Retriever")]
		BlackLabradorRetriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Black Mouth Cur")]
		BlackMouthCur,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Black Russian Terrier")]
		BlackRussianTerrier,

		/// <remarks/>
		Bloodhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Blue Lacy")]
		BlueLacy,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bluetick Coonhound")]
		BluetickCoonhound,

		/// <remarks/>
		Boerboel,

		/// <remarks/>
		Bolognese,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Border Collie")]
		BorderCollie,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Border Terrier")]
		BorderTerrier,

		/// <remarks/>
		Borzoi,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Boston Terrier")]
		BostonTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bouvier des Flanders")]
		BouvierdesFlanders,

		/// <remarks/>
		Boxer,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Boykin Spaniel")]
		BoykinSpaniel,

		/// <remarks/>
		Briard,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Brittany Spaniel")]
		BrittanySpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Brussels Griffon")]
		BrusselsGriffon,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bull Terrier")]
		BullTerrier,

		/// <remarks/>
		Bullmastiff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Cairn Terrier")]
		CairnTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Canaan Dog")]
		CanaanDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Cane Corso Mastiff")]
		CaneCorsoMastiff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Carolina Dog")]
		CarolinaDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Catahoula Leopard Dog")]
		CatahoulaLeopardDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Cattle Dog")]
		CattleDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Caucasian Sheepdog (Caucasian Ovtcharka)")]
		CaucasianSheepdogCaucasianOvtcharka,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Cavalier King Charles Spaniel")]
		CavalierKingCharlesSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Chesapeake Bay Retriever")]
		ChesapeakeBayRetriever,

		/// <remarks/>
		Chihuahua,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Chinese Crested Dog")]
		ChineseCrestedDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Chinese Foo Dog")]
		ChineseFooDog,

		/// <remarks/>
		Chinook,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Chocolate Labrador Retriever")]
		ChocolateLabradorRetriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Chow Chow")]
		ChowChow,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Cirneco dell\'Etna")]
		CirnecodellEtna,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Clumber Spaniel")]
		ClumberSpaniel,

		/// <remarks/>
		Cockapoo,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Cocker Spaniel")]
		CockerSpaniel,

		/// <remarks/>
		Collie,

		/// <remarks/>
		Coonhound,

		/// <remarks/>
		Corgi,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Coton de Tulear")]
		CotondeTulear,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Curly-Coated Retriever")]
		CurlyCoatedRetriever,

		/// <remarks/>
		Dachshund,

		/// <remarks/>
		Dalmatian,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Dandi Dinmont Terrier")]
		DandiDinmontTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Doberman Pinscher")]
		DobermanPinscher,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Dogo Argentino")]
		DogoArgentino,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Dogue de Bordeaux")]
		DoguedeBordeaux,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Dutch Shepherd")]
		DutchShepherd,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Bulldog")]
		EnglishBulldog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Cocker Spaniel")]
		EnglishCockerSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Coonhound")]
		EnglishCoonhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Pointer")]
		EnglishPointer,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Setter")]
		EnglishSetter,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Shepherd")]
		EnglishShepherd,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Springer Spaniel")]
		EnglishSpringerSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Toy Spaniel")]
		EnglishToySpaniel,

		/// <remarks/>
		Entlebucher,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Eskimo Dog")]
		EskimoDog,

		/// <remarks/>
		Feist,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Field Spaniel")]
		FieldSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Fila Brasileiro")]
		FilaBrasileiro,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Finnish Lapphund")]
		FinnishLapphund,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Finnish Spitz")]
		FinnishSpitz,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Flat-coated Retriever")]
		FlatcoatedRetriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Fox Terrier")]
		FoxTerrier,

		/// <remarks/>
		Foxhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("French Bulldog")]
		FrenchBulldog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Galgo Spanish Greyhound")]
		GalgoSpanishGreyhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("German Pinscher")]
		GermanPinscher,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("German Shepherd Dog")]
		GermanShepherdDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("German Shorthaired Pointer")]
		GermanShorthairedPointer,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("German Spitz")]
		GermanSpitz,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("German Wirehaired Pointer")]
		GermanWirehairedPointer,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Giant Schnauzer")]
		GiantSchnauzer,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Glen of Imaal Terrier")]
		GlenofImaalTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Golden Retriever")]
		GoldenRetriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Gordon Setter")]
		GordonSetter,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Great Dane")]
		GreatDane,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Great Pyrenees")]
		GreatPyrenees,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Greater Swiss Mountain Dog")]
		GreaterSwissMountainDog,

		/// <remarks/>
		Greyhound,

		/// <remarks/>
		Harrier,

		/// <remarks/>
		Havanese,

		/// <remarks/>
		Hound,

		/// <remarks/>
		Hovawart,

		/// <remarks/>
		Husky,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Ibizan Hound")]
		IbizanHound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Illyrian Sheepdog")]
		IllyrianSheepdog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Irish Setter")]
		IrishSetter,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Irish Terrier")]
		IrishTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Irish Water Spaniel")]
		IrishWaterSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Irish Wolfhound")]
		IrishWolfhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Italian Greyhound")]
		ItalianGreyhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Italian Spinone")]
		ItalianSpinone,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Jack Russell Terrier")]
		JackRussellTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Jack Russell Terrier (Parson Russell Terrier)")]
		JackRussellTerrierParsonRussellTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Japanese Chin")]
		JapaneseChin,

		/// <remarks/>
		Jindo,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Kai Dog")]
		KaiDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Karelian Bear Dog")]
		KarelianBearDog,

		/// <remarks/>
		Keeshond,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Kerry Blue Terrier")]
		KerryBlueTerrier,

		/// <remarks/>
		Kishu,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Klee Kai")]
		KleeKai,

		/// <remarks/>
		Komondor,

		/// <remarks/>
		Kuvasz,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Kyi Leo")]
		KyiLeo,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Labrador Retriever")]
		LabradorRetriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Lakeland Terrier")]
		LakelandTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Lancashire Heeler")]
		LancashireHeeler,

		/// <remarks/>
		Leonberger,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Lhasa Apso")]
		LhasaApso,

		/// <remarks/>
		Lowchen,

		/// <remarks/>
		Maltese,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Manchester Terrier")]
		ManchesterTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Maremma Sheepdog")]
		MaremmaSheepdog,

		/// <remarks/>
		Mastiff,

		/// <remarks/>
		McNab,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Miniature Pinscher")]
		MiniaturePinscher,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Mountain Cur")]
		MountainCur,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Mountain Dog")]
		MountainDog,

		/// <remarks/>
		Munsterlander,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Neapolitan Mastiff")]
		NeapolitanMastiff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("New Guinea Singing Dog")]
		NewGuineaSingingDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Newfoundland Dog")]
		NewfoundlandDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Norfolk Terrier")]
		NorfolkTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Norwegian Buhund")]
		NorwegianBuhund,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Norwegian Elkhound")]
		NorwegianElkhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Norwegian Lundehund")]
		NorwegianLundehund,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Norwich Terrier")]
		NorwichTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Nova Scotia Duck-Tolling Retriever")]
		NovaScotiaDuckTollingRetriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Old English Sheepdog")]
		OldEnglishSheepdog,

		/// <remarks/>
		Otterhound,

		/// <remarks/>
		Papillon,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Patterdale Terrier (Fell Terrier)")]
		PatterdaleTerrierFellTerrier,

		/// <remarks/>
		Pekingese,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Peruvian Inca Orchid")]
		PeruvianIncaOrchid,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Petit Basset Griffon Vendeen")]
		PetitBassetGriffonVendeen,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Pharaoh Hound")]
		PharaohHound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Pit Bull Terrier")]
		PitBullTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Plott Hound")]
		PlottHound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Podengo Portugueso")]
		PodengoPortugueso,

		/// <remarks/>
		Pointer,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Polish Lowland Sheepdog")]
		PolishLowlandSheepdog,

		/// <remarks/>
		Pomeranian,

		/// <remarks/>
		Poodle,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Portuguese Water Dog")]
		PortugueseWaterDog,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Presa Canario")]
		PresaCanario,

		/// <remarks/>
		Pug,

		/// <remarks/>
		Puli,

		/// <remarks/>
		Pumi,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Rat Terrier")]
		RatTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Redbone Coonhound")]
		RedboneCoonhound,

		/// <remarks/>
		Retriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Rhodesian Ridgeback")]
		RhodesianRidgeback,

		/// <remarks/>
		Rottweiler,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Saint Bernard St. Bernard")]
		SaintBernardStBernard,

		/// <remarks/>
		Saluki,

		/// <remarks/>
		Samoyed,

		/// <remarks/>
		Sarplaninac,

		/// <remarks/>
		Schipperke,

		/// <remarks/>
		Schnauzer,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Scottish Deerhound")]
		ScottishDeerhound,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Scottish Terrier Scottie")]
		ScottishTerrierScottie,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Sealyham Terrier")]
		SealyhamTerrier,

		/// <remarks/>
		Setter,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Shar Pei")]
		SharPei,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Sheep Dog")]
		SheepDog,

		/// <remarks/>
		Shepherd,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Shetland Sheepdog Sheltie")]
		ShetlandSheepdogSheltie,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Shiba Inu")]
		ShibaInu,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Shih Tzu")]
		ShihTzu,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Siberian Husky")]
		SiberianHusky,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Silky Terrier")]
		SilkyTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Skye Terrier")]
		SkyeTerrier,

		/// <remarks/>
		Sloughi,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Smooth Fox Terrier")]
		SmoothFoxTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("South Russian Ovtcharka")]
		SouthRussianOvtcharka,

		/// <remarks/>
		Spaniel,

		/// <remarks/>
		Spitz,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Staffordshire Bull Terrier")]
		StaffordshireBullTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Standard Poodle")]
		StandardPoodle,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Sussex Spaniel")]
		SussexSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Swedish Vallhund")]
		SwedishVallhund,

		/// <remarks/>
		Terrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Thai Ridgeback")]
		ThaiRidgeback,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tibetan Mastiff")]
		TibetanMastiff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tibetan Spaniel")]
		TibetanSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tibetan Terrier")]
		TibetanTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tosa Inu")]
		TosaInu,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Toy Fox Terrier")]
		ToyFoxTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Treeing Walker Coonhound")]
		TreeingWalkerCoonhound,

		/// <remarks/>
		Vizsla,

		/// <remarks/>
		Weimaraner,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Welsh Corgi")]
		WelshCorgi,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Welsh Springer Spaniel")]
		WelshSpringerSpaniel,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Welsh Terrier")]
		WelshTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("West Highland White Terrier Westie")]
		WestHighlandWhiteTerrierWestie,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Wheaten Terrier")]
		WheatenTerrier,

		/// <remarks/>
		Whippet,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("White German Shepherd")]
		WhiteGermanShepherd,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Wire Fox Terrier")]
		WireFoxTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Wire-haired Pointing Griffon")]
		WirehairedPointingGriffon,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Wirehaired Terrier")]
		WirehairedTerrier,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Xoloitzcuintle/Mexican Hairless")]
		XoloitzcuintleMexicanHairless,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Yellow Labrador Retriever")]
		YellowLabradorRetriever,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Yorkshire Terrier Yorkie")]
		YorkshireTerrierYorkie,

		/// <remarks/>
		Abyssinian,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Curl")]
		AmericanCurl,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Shorthair")]
		AmericanShorthair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Wirehair")]
		AmericanWirehair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Applehead Siamese")]
		AppleheadSiamese,

		/// <remarks/>
		Balinese,

		/// <remarks/>
		Bengal,

		/// <remarks/>
		Birman,

		/// <remarks/>
		Bobtail,

		/// <remarks/>
		Bombay,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("British Shorthair")]
		BritishShorthair,

		/// <remarks/>
		Burmese,

		/// <remarks/>
		Burmilla,

		/// <remarks/>
		Calico,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Canadian Hairless")]
		CanadianHairless,

		/// <remarks/>
		Chartreux,

		/// <remarks/>
		Chausie,

		/// <remarks/>
		Chinchilla,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Cornish Rex")]
		CornishRex,

		/// <remarks/>
		Cymric,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Devon Rex")]
		DevonRex,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Dilute Calico")]
		DiluteCalico,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Dilute Tortoiseshell")]
		DiluteTortoiseshell,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair")]
		DomesticLongHair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair - brown")]
		DomesticLongHairbrown,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair - buff")]
		DomesticLongHairbuff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair - buff and white")]
		DomesticLongHairbuffandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair - gray and white")]
		DomesticLongHairgrayandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair - orange")]
		DomesticLongHairorange,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair - orange and white")]
		DomesticLongHairorangeandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair-black")]
		DomesticLongHairblack,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair-black and white")]
		DomesticLongHairblackandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair-gray")]
		DomesticLongHairgray,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Long Hair-white")]
		DomesticLongHairwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair")]
		DomesticMediumHair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair - brown")]
		DomesticMediumHairbrown,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair - buff")]
		DomesticMediumHairbuff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair - buff and white")]
		DomesticMediumHairbuffandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair - gray and white")]
		DomesticMediumHairgrayandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair - orange and white")]
		DomesticMediumHairorangeandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair-black")]
		DomesticMediumHairblack,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair-black and white")]
		DomesticMediumHairblackandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair-gray")]
		DomesticMediumHairgray,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair-orange")]
		DomesticMediumHairorange,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Medium Hair-white")]
		DomesticMediumHairwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair")]
		DomesticShortHair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair - brown")]
		DomesticShortHairbrown,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair - buff")]
		DomesticShortHairbuff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair - buff and white")]
		DomesticShortHairbuffandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair - gray and white")]
		DomesticShortHairgrayandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair - orange and white")]
		DomesticShortHairorangeandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair-black")]
		DomesticShortHairblack,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair-black and white")]
		DomesticShortHairblackandwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair-gray")]
		DomesticShortHairgray,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair-mitted")]
		DomesticShortHairmitted,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair-orange")]
		DomesticShortHairorange,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Domestic Short Hair-white")]
		DomesticShortHairwhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Egyptian Mau")]
		EgyptianMau,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Exotic Shorthair")]
		ExoticShorthair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Extra-Toes Cat (Hemingway Polydactyl)")]
		ExtraToesCatHemingwayPolydactyl,

		/// <remarks/>
		Havana,

		/// <remarks/>
		Himalayan,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Japanese Bobtail")]
		JapaneseBobtail,

		/// <remarks/>
		Javanese,

		/// <remarks/>
		Korat,

		/// <remarks/>
		LaPerm,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Maine Coon")]
		MaineCoon,

		/// <remarks/>
		Manx,

		/// <remarks/>
		Munchkin,

		/// <remarks/>
		Nebelung,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Norwegian Forest Cat")]
		NorwegianForestCat,

		/// <remarks/>
		Ocicat,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Oriental Long Hair")]
		OrientalLongHair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Oriental Short Hair")]
		OrientalShortHair,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Oriental Tabby")]
		OrientalTabby,

		/// <remarks/>
		Persian,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Pixie-Bob")]
		PixieBob,

		/// <remarks/>
		Ragamuffin,

		/// <remarks/>
		Ragdoll,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Russian Blue")]
		RussianBlue,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Scottish Fold")]
		ScottishFold,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Selkirk Rex")]
		SelkirkRex,

		/// <remarks/>
		Siamese,

		/// <remarks/>
		Siberian,

		/// <remarks/>
		Silver,

		/// <remarks/>
		Singapura,

		/// <remarks/>
		Snowshoe,

		/// <remarks/>
		Somali,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Sphynx (hairless cat)")]
		Sphynxhairlesscat,

		/// <remarks/>
		Tabby,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tabby - black")]
		Tabbyblack,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tabby - Brown")]
		TabbyBrown,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tabby - buff")]
		Tabbybuff,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tabby - Grey")]
		TabbyGrey,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tabby - Orange")]
		TabbyOrange,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tabby - white")]
		Tabbywhite,

		/// <remarks/>
		Tiger,

		/// <remarks/>
		Tonkinese,

		/// <remarks/>
		Torbie,

		/// <remarks/>
		Tortoiseshell,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Turkish Angora")]
		TurkishAngora,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Turkish Van")]
		TurkishVan,

		/// <remarks/>
		Tuxedo,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Pot Bellied")]
		PotBellied,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Vietnamese Pot Bellied")]
		VietnamesePotBellied,

		/// <remarks/>
		Appaloosa,

		/// <remarks/>
		Arabian,

		/// <remarks/>
		Belgian,

		/// <remarks/>
		Clydesdale,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Curly Horse")]
		CurlyHorse,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Donkey/Mule")]
		DonkeyMule,

		/// <remarks/>
		Draft,

		/// <remarks/>
		Gaited,

		/// <remarks/>
		Grade,

		/// <remarks/>
		Lipizzan,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Miniature Horse")]
		MiniatureHorse,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Missouri Foxtrotter")]
		MissouriFoxtrotter,

		/// <remarks/>
		Morgan,

		/// <remarks/>
		Mustang,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Paint/Pinto")]
		PaintPinto,

		/// <remarks/>
		Palomino,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Paso Fino")]
		PasoFino,

		/// <remarks/>
		Percheron,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Peruvian Paso")]
		PeruvianPaso,

		/// <remarks/>
		Pony,

		/// <remarks/>
		Quarterhorse,

		/// <remarks/>
		Saddlebred,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Shetland Pony")]
		ShetlandPony,

		/// <remarks/>
		Standardbred,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Tennessee Walker")]
		TennesseeWalker,

		/// <remarks/>
		Thoroughbred,

		/// <remarks/>
		Warmblood,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Chinchilla")]
		Chinchilla1,

		/// <remarks/>
		Degu,

		/// <remarks/>
		Ferret,

		/// <remarks/>
		Gerbil,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Guinea Pig")]
		GuineaPig,

		/// <remarks/>
		Hamster,

		/// <remarks/>
		Hedgehog,

		/// <remarks/>
		Mouse,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Prairie Dog")]
		PrairieDog,

		/// <remarks/>
		Rat,

		/// <remarks/>
		Skunk,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Sugar Glider")]
		SugarGlider,

		/// <remarks/>
		Tarantula,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("African Grey")]
		AfricanGrey,

		/// <remarks/>
		Amazon,

		/// <remarks/>
		Brotogeris,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Budgie/Budgerigar")]
		BudgieBudgerigar,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Button Quail")]
		ButtonQuail,

		/// <remarks/>
		Caique,

		/// <remarks/>
		Canary,

		/// <remarks/>
		Chicken,

		/// <remarks/>
		Cockatiel,

		/// <remarks/>
		Cockatoo,

		/// <remarks/>
		Conure,

		/// <remarks/>
		Dove,

		/// <remarks/>
		Duck,

		/// <remarks/>
		Eclectus,

		/// <remarks/>
		Emu,

		/// <remarks/>
		Finch,

		/// <remarks/>
		Goose,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Guinea fowl")]
		Guineafowl,

		/// <remarks/>
		Kakariki,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Lory/Lorikeet")]
		LoryLorikeet,

		/// <remarks/>
		Lovebird,

		/// <remarks/>
		Macaw,

		/// <remarks/>
		Mynah,

		/// <remarks/>
		Ostrich,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Parakeet (Other)")]
		ParakeetOther,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Parrot (Other)")]
		ParrotOther,

		/// <remarks/>
		Parrotlet,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Peacock/Pea fowl")]
		PeacockPeafowl,

		/// <remarks/>
		Pheasant,

		/// <remarks/>
		Pigeon,

		/// <remarks/>
		Pionus,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Poicephalus/Senegal")]
		PoicephalusSenegal,

		/// <remarks/>
		Quail,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Quaker Parakeet")]
		QuakerParakeet,

		/// <remarks/>
		Rhea,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Ringneck/Psittacula")]
		RingneckPsittacula,

		/// <remarks/>
		Rosella,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Softbill (Other)")]
		SoftbillOther,

		/// <remarks/>
		Alpaca,

		/// <remarks/>
		Cow,

		/// <remarks/>
		Goat,

		/// <remarks/>
		Llama,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Pig (Farm)")]
		PigFarm,

		/// <remarks/>
		Sheep,

		/// <remarks/>
		American,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Fuzzy Lop")]
		AmericanFuzzyLop,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("American Sable")]
		AmericanSable,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Angora Rabbit")]
		AngoraRabbit,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Belgian Hare")]
		BelgianHare,

		/// <remarks/>
		Beveren,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Britannia Petite")]
		BritanniaPetite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Bunny Rabbit")]
		BunnyRabbit,

		/// <remarks/>
		Californian,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Champagne D\'Argent")]
		ChampagneDArgent,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Checkered Giant")]
		CheckeredGiant,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Chinchilla")]
		Chinchilla2,

		/// <remarks/>
		Cinnamon,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Creme D\'Argent")]
		CremeDArgent,

		/// <remarks/>
		Dutch,

		/// <remarks/>
		Dwarf,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Dwarf Eared")]
		DwarfEared,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Lop")]
		EnglishLop,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("English Spot")]
		EnglishSpot,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Flemish Giant")]
		FlemishGiant,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Florida White")]
		FloridaWhite,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("French-Lop")]
		FrenchLop,

		/// <remarks/>
		Harlequin,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Havana")]
		Havana1,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Himalayan")]
		Himalayan1,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Holland Lop")]
		HollandLop,

		/// <remarks/>
		Hotot,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Jersey Wooly")]
		JerseyWooly,

		/// <remarks/>
		Lilac,

		/// <remarks/>
		Lionhead,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Lop Eared")]
		LopEared,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Mini Rex")]
		MiniRex,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Mini-Lop")]
		MiniLop,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Netherland Dwarf")]
		NetherlandDwarf,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("New Zealand")]
		NewZealand,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Palomino")]
		Palomino1,

		/// <remarks/>
		Polish,

		/// <remarks/>
		Rex,

		/// <remarks/>
		Rhinelander,

		/// <remarks/>
		Satin,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Silver")]
		Silver1,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Silver Fox")]
		SilverFox,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Silver Marten")]
		SilverMarten,

		/// <remarks/>
		Tan,

		/// <remarks/>
		Fish,

		/// <remarks/>
		Frog,

		/// <remarks/>
		Gecko,

		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("Hermit Crab")]
		HermitCrab,

		/// <remarks/>
		Iguana,

		/// <remarks/>
		Lizard,

		/// <remarks/>
		Snake,

		/// <remarks/>
		Turtle,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum petfinderPetRecordMix
	{

		/// <remarks/>
		yes,

		/// <remarks/>
		no,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	public enum petAgeType
	{

		/// <remarks/>
		Baby,

		/// <remarks/>
		Young,

		/// <remarks/>
		Adult,

		/// <remarks/>
		Senior,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	public enum petGenderType
	{

		/// <remarks/>
		M,

		/// <remarks/>
		F,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	public enum petSizeType
	{

		/// <remarks/>
		S,

		/// <remarks/>
		M,

		/// <remarks/>
		L,

		/// <remarks/>
		XL,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	public enum petOptionType
	{

		/// <remarks/>
		specialNeeds,

		/// <remarks/>
		noDogs,

		/// <remarks/>
		noCats,

		/// <remarks/>
		noKids,

		/// <remarks/>
		noClaws,

		/// <remarks/>
		hasShots,

		/// <remarks/>
		housebroken,

		/// <remarks/>
		altered,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	public enum petStatusType
	{

		/// <remarks/>
		A,

		/// <remarks/>
		H,

		/// <remarks/>
		P,

		/// <remarks/>
		X,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class petfinderPetRecordMedia
	{

		private petPhotoType[] photosField;

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		[System.Xml.Serialization.XmlArrayItemAttribute("photo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
		public petPhotoType[] photos
		{
			get
			{
				return this.photosField;
			}
			set
			{
				this.photosField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petPhotoType
	{

		private string idField;

		private petPhotoTypeSize sizeField;

		private bool sizeFieldSpecified;

		private string valueField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
		public string id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public petPhotoTypeSize size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool sizeSpecified
		{
			get
			{
				return this.sizeFieldSpecified;
			}
			set
			{
				this.sizeFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public enum petPhotoTypeSize
	{

		/// <remarks/>
		x,

		/// <remarks/>
		t,

		/// <remarks/>
		pn,

		/// <remarks/>
		pnt,

		/// <remarks/>
		fpm,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petContactType
	{

		private string nameField;

		private string address1Field;

		private string address2Field;

		private string stateField;

		private string zipField;

		private string phoneField;

		private string faxField;

		private string emailField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string address1
		{
			get
			{
				return this.address1Field;
			}
			set
			{
				this.address1Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string address2
		{
			get
			{
				return this.address2Field;
			}
			set
			{
				this.address2Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string state
		{
			get
			{
				return this.stateField;
			}
			set
			{
				this.stateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string zip
		{
			get
			{
				return this.zipField;
			}
			set
			{
				this.zipField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string phone
		{
			get
			{
				return this.phoneField;
			}
			set
			{
				this.phoneField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string fax
		{
			get
			{
				return this.faxField;
			}
			set
			{
				this.faxField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string email
		{
			get
			{
				return this.emailField;
			}
			set
			{
				this.emailField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderPetIdList
	{

		private string[] idField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "positiveInteger")]
		public string[] id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17379")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class petfinderAuthData
	{

		private string keyField;

		private string tokenField;

		private string expiresField;

		private System.DateTime expiresStringField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string key
		{
			get
			{
				return this.keyField;
			}
			set
			{
				this.keyField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public string token
		{
			get
			{
				return this.tokenField;
			}
			set
			{
				this.tokenField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "positiveInteger")]
		public string expires
		{
			get
			{
				return this.expiresField;
			}
			set
			{
				this.expiresField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public System.DateTime expiresString
		{
			get
			{
				return this.expiresStringField;
			}
			set
			{
				this.expiresStringField = value;
			}
		}
	}

}
