using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using HuskyRescue.Core.ViewModel.Entity;
using NLog.Mvc;

namespace HuskyRescue.Core.ViewModel.Logging
{
	public class LogUserActivity
	{
		public int ID { get; set; }
		public DateTime TimeStamp { get; set; }
		public Guid UserID { get; set; }
		public int EventTypeID { get; set; }
		public int? EntityTypeID { get; set; }
		public string Note { get; set; }

		public string UserName
		{
			get
			{
				var name = string.Empty;
				try
				{
					name = Membership.GetUser(UserID).UserName;
				}
				catch (ArgumentNullException ex)
				{
					ILogger log = new Logger();
					log.Error("User Not Found in LogUserActivity.UserName", ex);
					name = "[User Not Found]";
				}
				return name;
			}
		}
		public List<SelectListItem> EntityTypeList { get; set; }
		public List<SelectListItem> ActivityEventTypeList { get; set; }

		public LogUserActivity()
		{
			TimeStamp = DateTime.Now;
			EntityTypeList = new List<SelectListItem>();
			ActivityEventTypeList = new List<SelectListItem>();
		}

		public enum EventType
		{
			CREATE = 1,
			DELETE_SOFT = 2,
			DELETE_HARD = 3,
			UPDATE = 4,
			GET_ONE = 5,
			GET_ALL = 6
		}

		public enum EntityType
		{
			AdoptionApp = 1,
			AdoptionAppAnimal = 2,
			AdoptionAppVet = 3,
			BlogComment = 4,
			BlogPost = 5,
			BlogTag = 6,
			EntityAddress = 7,
			EntityBase = 8,
			EntityDog = 9,
			EntityDogIntake = 10,
			EntityDogPlacement = 11,
			EntityDonationItem = 12,
			EntityEmailAddress = 13,
			EntityFile = 14,
			EntityOrganisation = 15,
			EntityOrganisationContacts = 16,
			EntityOrganisationServices = 17,
			EntityPerson = 18,
			EntityPersonProfile = 19,
			EntityPersonSkills = 20,
			EntityPhoneNumber = 21,
			EntitySupplies = 22,
			EntitySupplyPlacement = 23,
			EntitySupplyType = 24,
			EventAttendee = 25,
			EventRegistration = 26,
			EventSponsor = 27,
			EventSponsorshipLevel = 28,
			EventSponsorshipLevelType = 29,
			Event = 30
		}

		public void SetNote(Object objectVm)
		{
			Note = UserName + " ";

			switch ((EventType)EventTypeID)
			{
				case EventType.CREATE:
					Note += "Created";
					break;
				case EventType.DELETE_SOFT:
					Note += "Soft Deleted";
					break;
				case EventType.DELETE_HARD:
					Note += "Hard Deleted";
					break;
				case EventType.GET_ONE:
					Note += "Retrieved";
					break;
				case EventType.GET_ALL:
					Note += "Retrieved All";
					break;
			}
			Note += " ";
			switch ((EntityType)EntityTypeID)
			{
				case EntityType.AdoptionApp:
					var adoptionApp = (Applicant)objectVm;
					if ((EventType)EventTypeID == EventType.GET_ALL)
					{
						Note += "Adoption Applications";
					}
					else
					{
						Note += "Adoption Application for " + adoptionApp.AppFullName + " (ID: " + adoptionApp.ID + ")";
					}
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Adoption Application" });
					break;
				case EntityType.AdoptionAppAnimal:
					Note += "Adoption App Animal";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Adoption App Animal" });
					break;
				case EntityType.AdoptionAppVet:
					Note += "Adoption App Vet";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Adoption App Vet" });
					break;
				case EntityType.BlogComment:
					Note += "Blog Comment";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Blog Comment" });
					break;
				case EntityType.BlogPost:
					Note += "Blog Post";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Blog Post" });
					break;
				case EntityType.BlogTag:
					Note += "Blog Tag";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Blog Tag" });
					break;
				case EntityType.EntityAddress:
					var address = (Address)objectVm;
					Note += "Street Address: " + address.AddressFull + " (ID: " + address.ID + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Street Address" });
					break;
				case EntityType.EntityBase:
					Note += "Base Object (references to Address/Phone/Email for a person or organisation)";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Base Object (references to Address/Phone/Email for a person or organisation)" });
					break;
				case EntityType.EntityDog:
					Note += "Dog";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Dog" });
					break;
				case EntityType.EntityDogIntake:
					Note += "Dog In Intake";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Dog In Intake" });
					break;
				case EntityType.EntityDogPlacement:
					Note += "Dog Placement";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Dog Placement" });
					break;
				case EntityType.EntityDonationItem:
					Note += "Donation Item";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Donation Item" });
					break;
				case EntityType.EntityEmailAddress:
					var email = (EmailAddress)objectVm;
					Note += "Email Address: " + email.Address + " (ID: " + email.ID + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Email Address" });
					break;
				case EntityType.EntityFile:
					var file = (File)objectVm;
					Note += "File: " + file.FileName + " (ID: " + file.ID + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "File" });
					break;
				case EntityType.EntityOrganisation:
					var business = (Business)objectVm;
					Note += "Business: " + business.BusinessName + " (ID: " + business.ID + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Business" });
					break;
				case EntityType.EntityOrganisationContacts:
					Note += "Organisation Contact";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Organisation Contact" });
					break;
				case EntityType.EntityOrganisationServices:
					Note += "Organisation Service";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Organisation Service" });
					break;
				case EntityType.EntityPerson:
					var person = (Person)objectVm;
					Note += "Person: " + person.FullName + " (ID: " + person.ID + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Person" });
					break;
				case EntityType.EntityPersonProfile:
					Note += "Person Profile";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Person Profile" });
					break;
				case EntityType.EntityPersonSkills:
					Note += "Person Skill";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Person Skill" });
					break;
				case EntityType.EntityPhoneNumber:
					var phone = (PhoneNumber)objectVm;
					Note += "Phone Number: " + phone.Number + " (ID: " + phone.ID + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Phone Number" });
					break;
				case EntityType.EntitySupplies:
					Note += "Supplies";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Supplies" });
					break;
				case EntityType.EntitySupplyPlacement:
					Note += "Supply Placement";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Supply Placement" });
					break;
				case EntityType.EntitySupplyType:
					Note += "Supply Type";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Supply Type" });
					break;
				case EntityType.EventAttendee:
					var attendee = (EventAttendee)objectVm;
					Note += "Event Attendee: " + attendee.Person.FullName + " (ID: " + attendee.Id + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Event Attendee" });
					break;
				case EntityType.EventRegistration:
					var eventReg = (EventRegistration)objectVm;
					var at = string.Join(",", eventReg.Attendees.Select(a => a.Person.FullName).ToArray());
					Note += "Event Registration: " + at + " for event " + eventReg.Event.Name + " (ID: " + eventReg.Id + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Event Registration" });
					break;
				case EntityType.EventSponsor:
					var sponsor = (EventSponsor)objectVm;
					Note += "Event Sponsor: " + sponsor.Business.BusinessName + " (ID: " + sponsor.Id + ")";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Event Sponsor" });
					break;
				case EntityType.EventSponsorshipLevel:
					Note += "EventSponsorshipLevel";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "EventSponsorshipLevel" });
					break;
				case EntityType.EventSponsorshipLevelType:
					Note += "EventSponsorshipLevelType";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "EventSponsorshipLevelType" });
					break;
				case EntityType.Event:
					Note += "Event";
					ActivityEventTypeList.Add(new SelectListItem() { Text = "Event" });
					break;
			}
		}

	}

}
